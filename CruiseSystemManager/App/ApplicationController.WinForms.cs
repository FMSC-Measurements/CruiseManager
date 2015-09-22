using CruiseDAL;
using CruiseManager.Core.App;
using CSM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.App
{
    public class WinFormsApplicationController : ApplicationController 
    {
        private CSM.Utility.COConverter _converter;
        private string _convertedFilePath;

        #region UserSettings 
        public override string CruiseSaveLocation
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

        public override string TemplateSaveLocation
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

        private string[] _recentFiles;
        public override string[] RecentFiles
        {
            get
            {
                if (_recentFiles == null)
                {
                    string raw = Properties.Settings.Default.RecentFiles ?? string.Empty;
                    _recentFiles = raw.Split(new char[] { ';' }, RECENT_FILE_LIST_SIZE, StringSplitOptions.RemoveEmptyEntries);
                }

                return _recentFiles;
            }
        }

        protected void AddRecentFile(String path)
        {
            string[] oldRecentFiles = this.RecentFiles;
            string[] newRecentFiles = null;
            if (oldRecentFiles.Length > 0)
            {
                string[] union = new String[oldRecentFiles.Length + 1];
                union[0] = path;
                Array.Copy(oldRecentFiles, 0, union, 1, oldRecentFiles.Length);
                newRecentFiles = union.Distinct().Take(RECENT_FILE_LIST_SIZE).ToArray();
            }
            else
            {
                newRecentFiles = new string[1] { path };
            }

            this._recentFiles = newRecentFiles;
            Properties.Settings.Default.RecentFiles = String.Join(";", this._recentFiles);
            Properties.Settings.Default.Save();


        }

        #endregion

        /// <summary>
        /// opens file for use, handles various exceptions that can ocure whild opening file,
        /// determins if a cruise file/template file/or legacy cruise file
        /// </summary>
        /// <param name="filePath"></param>
        public override void OpenFile(String filePath)
        {
            bool hasError = false;
            try
            {
                //start wait cursor incase this takes a long time 
                Cursor.Current = Cursors.WaitCursor;
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case R.Strings.CRUISE_FILE_EXTENTION:
                        {
                            this.AppState.Database = new DAL(filePath);
                            this.AddRecentFile(filePath);
                            String[] errors;
                            if (this.AppState.Database.HasCruiseErrors(out errors))
                            {
                                MessageBox.Show(String.Join("\r\n", errors));
                            }
                            ShowCruiseLandingLayout();
                            break;
                        }
                    case R.Strings.CRUISE_TEMPLATE_FILE_EXTENTION:
                        {
                            this.AppState.Database = new DAL(filePath);
                            this.AddRecentFile(filePath);
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
                throw;
            }
            finally
            {
                if (hasError)
                {
                    this.ShowHomeLayout();
                }

                this.MainWindow.EnableSaveAs = this.Database != null;

                Cursor.Current = Cursors.Default;
            }
        }

        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                this.AppState.Database = new DAL(_convertedFilePath);
                this.AddRecentFile(_convertedFilePath);
                if (MainWindow.InvokeRequired)
                {
                    Action act = this.ShowCruiseLandingLayout;
                    MainWindow.Invoke(act);
                }
                else
                {
                    this.ShowCruiseLandingLayout();
                }
            }
            else
            {
                MessageBox.Show("error unable to convert file");//TODO better error messages
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }
    }
}
