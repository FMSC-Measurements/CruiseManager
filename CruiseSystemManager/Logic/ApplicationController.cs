using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSM.Utility;
using CruiseDAL;
using CruiseDAL.DataObjects;

namespace CSM.Logic
{
    public class ApplicationController
    {
        public const string Version = "2015.05.01";

        private CSM.Utility.COConverter _converter;
        private string _convertedFilePath;

        public IWindowPresenter WindowPresenter { get; protected set; }

        public DAL Database { get; protected set; }

        //the current save handler is the active locical component of the program that is 
        //responceable for saving the user's data 
        public ISaveHandler SaveHandler { get { return ActivePresentor; } }
        private IPresentor _activePresentor;
        public IPresentor ActivePresentor
        {
            get
            {
                return _activePresentor;
            }
            set
            {

                if (_activePresentor != null)
                {
                    _activePresentor.HandleSave();
                    _activePresentor.Dispose();
                }
                _activePresentor = value;
                this.WindowPresenter.OnActivePresentorChanged();
                //if (value == null)
                //{
                //    this.MainWindow.EnableSave = false;
                //}
                //else
                //{
                //    this.MainWindow.EnableSave = value.CanHandleSave;
                //}
            }
        }

        #region UserSettings
        public string CruiseSaveLocation
        {
            get
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.DefaultCruiseSaveLocation))
                {
                    Properties.Settings.Default.DefaultCruiseSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles";
                    Properties.Settings.Default.Save();
                }
                return Properties.Settings.Default.DefaultCruiseSaveLocation;
            }
            set
            {
                if (Properties.Settings.Default.DefaultCruiseSaveLocation == value) { return; }
                Properties.Settings.Default.DefaultCruiseSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }

        public string TemplateSaveLocation
        {
            get
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.DefaultTemplateSaveLocation))
                {
                    Properties.Settings.Default.DefaultTemplateSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CruiseFiles\\Templates";
                    Properties.Settings.Default.Save();
                }
                return Properties.Settings.Default.DefaultTemplateSaveLocation;
            }
            set
            {
                if (Properties.Settings.Default.DefaultTemplateSaveLocation == value) { return; }
                Properties.Settings.Default.DefaultTemplateSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }
        #endregion 

        public bool HasUnfinishedCruiseFile()
        {
            string tempPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.LocalUserAppDataPath) + "\\~temp.cruise";
            return System.IO.File.Exists(tempPath);
        }

        /// <summary>
        /// opens file for use, handles various exceptions that can ocure whild opening file,
        /// determins if a cruise file/template file/or legacy cruise file
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenFile(String filePath)
        {
            bool hasError = false;
            try
            {
                //start wait cursor incase this takes a long time 
                this.WindowPresenter.ShowWaitCursor();
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case R.Strings.CRUISE_FILE_EXTENTION:
                        {
                            this.Database = new DAL(filePath);
                            String[] errors;
                            if (this.Database.HasCruiseErrors(out errors))
                            {
                                MessageBox.Show(String.Join("\r\n", errors));
                            }
                            ShowCruiseLandingLayout();
                            break;
                        }
                    case R.Strings.CRUISE_TEMPLATE_FILE_EXTENTION:
                        {
                            this.Database = new DAL(filePath);
                            ShowTemplateLandingLayout();
                            break;
                        }
                    case R.Strings.LEGACY_CRUISE_FILE_EXTENTION:
                        {
                            _converter = new COConverter();
                            _convertedFilePath = System.IO.Path.ChangeExtension(filePath, R.Strings.CRUISE_FILE_EXTENTION);

                            _converter.BenginConvert(filePath, _convertedFilePath, null, HandleConvertDone);

                            break;
                        }
                    default:
                        MessageBox.Show("Invalid file name");
                        return;
                }
            }
            catch (CruiseDAL.DatabaseShareException)
            {
                hasError = true;
                MessageBox.Show("File can not be opened in multiple applications");
            }
            catch (CruiseDAL.ReadOnlyException)
            {
                hasError = true;
                MessageBox.Show("Unable to open file becaus it is read only");
            }
            catch (CruiseDAL.IncompatibleSchemaException ex)
            {
                hasError = true;
                MessageBox.Show("File is not compatible with this version of Cruise Manager: " + ex.Message);
            }
            catch (CruiseDAL.DatabaseExecutionException ex)
            {
                hasError = true;
                MessageBox.Show("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.IO.IOException ex)
            {
                hasError = true;
                MessageBox.Show("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.Exception e)
            {
                Trace.TraceError(e.ToString());
                throw e;
            }
            finally
            {
                if (hasError)
                {
                    this.ShowHomeLayout();
                }

                this.MainWindow.EnableSaveAs = this.Database != null;

                this.WindowPresenter.HideWaitCursor();
            }
        }//end OpenFile

        

        public bool SaveAs(String path)
        {
            if (this.Database.CopyAs(path))
            {
                if (this.SaveHandler != null) { this.SaveHandler.HandleSave(); }
                //TODO update main window title 
                return true;
            }
            return false;
        }

        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                this.Database = new DAL(_convertedFilePath);
                this.WindowPresenter.ShowCruiseLandingLayout();                
            }
            else
            {
                WindowPresenter.ShowMessage("error unable to convert file", null);//TODO better error messages
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }

        public void HandleAppClosing(object sender, FormClosingEventArgs e)
        {
            if (this.SaveHandler != null)
            {
                SaveHandler.HandleAppClosing(sender, e);
            }
        }

        #region Common Database methods
        public List<string> GetCruiseMethods(bool reconMethodsOnly)
        {
            return this.GetCruiseMethods(this.Database, reconMethodsOnly);
        }

        public List<String> GetCruiseMethods(DAL database, bool reconMethodsOnly)
        {
            if (reconMethodsOnly)
            {
                return new List<string>(CruiseDAL.Schema.Constants.CruiseMethods.RECON_METHODS);
            }
            List<string> cruiseMethods = null;
            try
            {
                cruiseMethods = new List<string>(CruiseMethodsDO.ReadCruiseMethodStr(database, reconMethodsOnly));
            }
            catch { }
            if (cruiseMethods == null || cruiseMethods.Count == 0)
            {
                cruiseMethods = new List<string>(CruiseDAL.Schema.Constants.CruiseMethods.SUPPORTED_METHODS);
            }

            return cruiseMethods;
        }

        public object GetTreeTDVList(TreeVM tree)
        {
            if (tree == null) { return Constants.EMPTY_SPECIES_LIST; }
            if (tree.Stratum == null)
            {
                if (this.Database.GetRowCount("CuttingUnitStratum", "WHERE CuttingUnit_CN = ?", tree.CuttingUnit_CN) == 1)
                {
                    tree.Stratum = this.Database.ReadSingleRow<StratumVM>("Stratum", "JOIN CuttingUnitStratum USING (Stratum_CN) WHERE CuttingUnit_CN = ?", tree.CuttingUnit_CN);
                }
                else
                {
                    return Constants.EMPTY_SPECIES_LIST;
                }
            }

            if (tree.SampleGroup == null)
            {
                if (this.Database.GetRowCount("SampleGroup", "WHERE Stratum_CN = ?", tree.Stratum_CN) == 1)
                {
                    tree.SampleGroup = this.Database.ReadSingleRow<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", tree.Stratum_CN);
                }
                if (tree.SampleGroup == null)
                {
                    return Constants.EMPTY_SPECIES_LIST;
                }
            }



            if (tree.SampleGroup.TreeDefaultValues.IsPopulated == false)
            {
                tree.SampleGroup.TreeDefaultValues.Populate();
            }
            return tree.SampleGroup.TreeDefaultValues;

        }

        public object GetSampleGroupsByStratum(long? st_cn)
        {
            if (st_cn == null)
            {
                return new SampleGroupDO[0];
            }
            return this.Database.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", st_cn);
        }
        #endregion

        #region Static Methods
        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
        #endregion

    }
}
