using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;
using CSM.Logic;
using System.ComponentModel;
using CruiseDAL.Enums;
using CSM.Common;

namespace CSM.Winforms.CruiseCustomize
{
    public class CustomizeCruisePresenter : IPresentor, ISaveHandler
    {
        private bool _isFieldSetupInitialized = false;
        private bool _isLogMatrixInitialized = false;
        private bool _isTreeAuditsInitialized = false;
        private bool _isTallySetupInitialized = false;

        public DAL Database { get { return this.WindowPresenter.Database; } }
        public IWindowPresenter WindowPresenter { get; set; }
        public CruiseCustomizeView View { get; set; }
        //public List<StratumDO> Strata { get; set; }
        //public List<StratumCustomizeViewModel> StrataVM { get; set; }

        public List<FieldSetupStratum> FieldSetupStrata { get; set; }
        public List<TallySetupStratum> TallySetupStrata { get; set; }
        

        public List<TreeDefaultValueDO> TreeDefaults { get; set; }
        public List<TreeAuditValueDO> TreeAudits { get; set; }

        public List<TreeFieldSetupDO> TreeFields { get; set; }
        //public List<TreeFieldSetupDefaultDO> TreeFieldDefaults { get; set; }
        public List<LogFieldSetupDO> LogFields { get; set; }
        public List<TallyVM> TallyPresets { get; set; }
        public List<LogMatrixDO> LogMatrix { get; set; }

        public bool IsLogGradingEnabled { get; protected set; }

        public CustomizeCruisePresenter(IWindowPresenter presenter)
        {
            WindowPresenter = presenter;
                        
            this.IsLogGradingEnabled = this.WindowPresenter.Database.Read<SaleDO>("Sale", null)[0].LogGradingEnabled;

        }

        public void UpdateView()
        {
            
                        
        }
        
        public void InitializeFieldSetup()
        {
            if (_isFieldSetupInitialized) { return; }


            try
            {
                //initialize list of all tree and log fields 
                this.TreeFields = this.WindowPresenter.AppState.SetupServ.GetTreeFieldSetups();
                this.LogFields = this.WindowPresenter.AppState.SetupServ.GetLogFieldSetups();

                this.FieldSetupStrata = this.Database.Read<FieldSetupStratum>("Stratum", null);
                foreach (FieldSetupStratum st in FieldSetupStrata)
                {
                    //initialize each stratum object  
                    st.SelectedLogFields = GetSelectedLogFields(st);
                    st.SelectedTreeFields = GetSelectedTreeFields(st);
                    if (st.SelectedTreeFields.Count() <= 0)
                    {
                        // if blank, use default values for cruise method
                        st.SelectedTreeFields = GetSelectedTreeFieldsDefault(st);
                    }

                    //compare selected tree/log fields to all tree.log fields to create a list of unselected tree/log fields
                    List<TreeFieldSetupDO> unselectedTreeFields =
                        (from tfs in this.TreeFields.Except(st.SelectedTreeFields, CSM.Models.TreeFieldComparer.Instance)
                         select new TreeFieldSetupDO(tfs)).ToList();
                    List<LogFieldSetupDO> unselectedLogFields = (
                        from lfs in this.LogFields.Except(st.SelectedLogFields, CSM.Models.LogFieldComparer.Instance)
                        select new LogFieldSetupDO(lfs)).ToList();

                    st.UnselectedLogFields = unselectedLogFields;
                    st.UnselectedTreeFields = unselectedTreeFields;
                }

            }
            catch (Exception e)
            {
                throw new NotImplementedException(null, e);
            }
            finally
            {
                //dal.ExitConnectionHold();
            }

            this.View.UpdateFieldSetupViews();            
        }
        
        public void InitializeLogMatrix()
        {
            if (_isLogMatrixInitialized) { return; }
            try
            {
                this.LogMatrix = this.Database.Read<LogMatrixDO>("LogMatrix", null);
                _isLogMatrixInitialized = true; 
            }
            catch (Exception e)
            {
                throw new NotImplementedException(null, e);
            }
            this.View.UpdateLogMatrix();
        }
        
        public void InitializeTreeAudits()
        {
            if (_isTreeAuditsInitialized) { return; }
            try
            {
                TreeDefaults = this.Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
                TreeAudits = this.Database.Read<TreeAuditValueDO>("TreeAuditValue", "Order By Field");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(null, e);
            }
            this.View.UpdateTreeAudits();
            this.View.UpdateTreeDefaults();

        }
        
        public void InitializeTallySetup()
        {
            if (_isTallySetupInitialized) { return; }
            try
            {
                this.TallySetupStrata = this.Database.Read<TallySetupStratum>("Stratum", null);

                foreach (TallySetupStratum stratum in this.TallySetupStrata)
                {
                    this.LoadSampleGroups(stratum);
                }
                TallyPresets = this.Database.Read<TallyVM>("Tally", null);
                this.View.UpdateTallySetupView();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(null,e);
            }
        }

        #region Tally Setup

        public bool CanDefintTallys(StratumDO stratum)
        {
            return StratumDO.CanDefineTallys(stratum);
        }

        //called when the view is initialized, for eash stratum 
        //initialized a list containing information about sampleGroups
        public void LoadSampleGroups(TallySetupStratum stratum)
        {
            if (stratum.SampleGroups != null) { return; }//if we have already created initialized this stratum, 

            stratum.SampleGroups = WindowPresenter.Database.Read<TallySetupSampleGroup>("SampleGroup", "WHERE Stratum_CN = ?", stratum.Stratum_CN);
            foreach (TallySetupSampleGroup sg in stratum.SampleGroups)
            {
                //TODO compare what we see as the tally mode vs. the stored mode on the sample group
                sg.TallyMethod = sg.GetSampleGroupTallyMode();
                sg.LoadTallieData();

                if (stratum.Method == CruiseDAL.Schema.Constants.CruiseMethods.STR && sg.TallyMethod == TallyMode.None)
                {
                    sg.TallyMethod = TallyMode.BySampleGroup;
                }
                if (CruiseDAL.Schema.Constants.CruiseMethods.THREE_P_METHODS.Contains(stratum.Method) && sg.TallyMethod == TallyMode.None)
                {
                    sg.TallyMethod = TallyMode.BySpecies;
                }
            }
        }


        ////called when a samplegroup is selected from the dropdown list in tally setup
        //public void LoadTallies(SampleGroupViewModel sg)
        //{
        //    if (sg.TallyMethod != TallyMode.Unknown) { return; }//assume we have already loaded this samplegroup before, dont reload it

        //    //TODO compare what we see as the tally mode vs. the stored mode on the sample group
        //    sg.TallyMethod = GetSampleGroupTallyMode(sg);

        //    //initialize a tally entity for use with tally by sample group
        //    TallyDO sgTally = Controller.Database.ReadSingleRow<TallyDO>("Tally", 
        //        "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND ifnull(CountTree.TreeDefaultValue_CN, 0) = 0", 
        //        sg.SampleGroup_CN);

        //    if (sgTally == null)
        //    {
        //        sg.SgTallie = new TallyDO(Controller.Database);
        //        sg.SgTallie.Description = sg.Code;
        //    }
        //    else
        //    {
        //        sg.SgTallie = sgTally;
        //    }
            

        //    //initialize a list of tallys for use with tally by species 
        //    sg.Tallies = new Dictionary<TreeDefaultValueDO, TallyDO>();
        //    sg.TreeDefaultValues.Populate();
        //    foreach (TreeDefaultValueDO tdv in sg.TreeDefaultValues)
        //    {
        //        TallyDO tally = Controller.Database.Read<TallyDO>("Tally", "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND CountTree.TreeDefaultValue_CN = ?",  sg.SampleGroup_CN, tdv.TreeDefaultValue_CN).FirstOrDefault();
        //        if (tally == null)
        //        {
        //            tally = new TallyDO(Controller.Database);
        //            tally.Description = tdv.Species + ((tdv.LiveDead == "D") ? "D" : "");
        //        }
        //        sg.Tallies.Add(tdv, tally);
        //    }
        //}

        protected void CopyTreeFields(FieldSetupStratum from, FieldSetupStratum to)
        {
            //TODO comeback
            //foreach (TreeFieldSetupDO tf in from.SelectedTreeFields)
            //{
            //    if (!to.SelectedTreeFields.Contains(tf, TreeFieldComparer.GetInstance()))
            //    {
            //        TreeFieldSetupDO match = to.UnselectedTreeFields.Find((TreeFieldSetupDO t) => t.Field = tf.Field);
            //        if (match == null) continue;
            //        to.SelectedTreeFields.Add(match);
            //        to.UnselectedTreeFields.Remove(match);
            //    }
            //}
            //foreach (TreeFieldSetupDO tf in from.UnselectedTreeFields)
            //{
            //    if (!to.UnselectedTreeFields.Contains(tf, TreeFieldComparer.GetInstance()))
            //    {
            //        TreeFieldSetupDO match = to.SelectedTreeFields.Find((TreeFieldSetupDO t) => t.Field = tf.Field);
            //        if (match == null) continue;
            //        to.UnselectedTreeFields.Add(match);
            //        to.SelectedTreeFields.Remove(match);
            //    }
            //}

        }

        

        public string[] GetAvalibleHotKeysInStratum(TallySetupStratum st)
        {
            var useHotKeys = (from StratumDO stratum in this.TallySetupStrata
                              select stratum.Hotkey).Union(st.ListHotKeysInuse());
            var avalibleHotHeys = CSM.Utility.R.Strings.HOTKEYS.Except(useHotKeys).ToArray();
            return avalibleHotHeys;
            //return CSM.Utility.R.Strings.HOTKEYS;
        }        

        public string[] GetAvalibleStratumHotKeys(TallySetupStratum stratum)
        {
            var usedHotKeys = (from StratumDO st in this.TallySetupStrata
                               where st != stratum 
                               select st.Hotkey);
            foreach (TallySetupStratum straum in this.TallySetupStrata)
            {
                usedHotKeys = usedHotKeys.Union(straum.ListHotKeysInuse());
            }
            return CSM.Utility.R.Strings.HOTKEYS.Except(usedHotKeys).ToArray();
            //return CSM.Utility.R.Strings.HOTKEYS;
        }

        public static char HotKeyToChar(string str)//TODO move method somewhere more useful
        {
            if(String.IsNullOrEmpty(str))
            {
                return char.MinValue;
            }
            return char.ToUpper(str[0]);
        }



        private bool ValidateHotKeys(TallySetupStratum st, ref StringBuilder errorBuilder)
        {
            bool success = true; 
            List<char> usedHotKeys = new List<char>();
            //StringBuilder errorBuilder = new StringBuilder();

            foreach (TallySetupSampleGroup sgVM in st.SampleGroups)
            {
                if ((sgVM.TallyMethod & TallyMode.BySampleGroup) == TallyMode.BySampleGroup)
                {
                    char hk = HotKeyToChar(sgVM.SgTallie.Hotkey);
                    if (hk == char.MinValue) { continue; } //no hot key set, SKIP
                    if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                    {
                        //ERROR stratum already has hotkey
                        errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", sgVM.SgTallie.Hotkey, sgVM.ToString(), st.Code);
                        success = false;
                    }
                    else
                    {
                        //SUCCESS add hot key to list of in ues hot keys
                        usedHotKeys.Add(hk);
                    }
                }
                else if ((sgVM.TallyMethod & TallyMode.BySpecies) == TallyMode.BySpecies)
                {
                    foreach (TallyVM t in sgVM.Tallies.Values)
                    {
                        char hk = HotKeyToChar(t.Hotkey);
                        if (hk == char.MinValue) { continue; } //not hot key set, SKIP
                        if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                        {
                            //ERROR stratum already has hotkey
                            errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", t.Hotkey, sgVM.ToString(), st.Code);
                            success = false; 
                        }
                        else
                        {
                            //SUCCESS add hot key to list of in ues hot keys
                            usedHotKeys.Add(hk);
                        }
                    }
                }
            }

            return success;
        }

        #endregion

        #region Tree / Log Field Setup
        public List<TreeFieldSetupDO> GetSelectedTreeFields(StratumDO stratum)
        {
            return this.WindowPresenter.Database.Read<TreeFieldSetupDO>("TreeFieldSetup", "WHERE Stratum_CN = ? ORDER BY FieldOrder", stratum.Stratum_CN);
        }

        public List<TreeFieldSetupDO> GetSelectedTreeFieldsDefault(StratumDO stratum)
        {
           //select from TreeFieldSetupDefault where method = stratum.method
           List<TreeFieldSetupDefaultDO> treeFieldDefaults = WindowPresenter.Database.Read<TreeFieldSetupDefaultDO>("TreeFieldSetupDefault", "WHERE Method = ? ORDER BY FieldOrder", stratum.Method);
           
           List<TreeFieldSetupDO> treeFields = new List<TreeFieldSetupDO>();
           
           foreach (TreeFieldSetupDefaultDO tfd in treeFieldDefaults)
           {
              TreeFieldSetupDO tfs = new TreeFieldSetupDO();
              tfs.Stratum_CN = stratum.Stratum_CN;
              tfs.Field = tfd.Field;
              tfs.FieldOrder = tfd.FieldOrder;
              tfs.ColumnType = tfd.ColumnType;
              tfs.Heading = tfd.Heading;
              tfs.Width = tfd.Width;
              tfs.Format = tfd.Format;
              tfs.Behavior = tfd.Behavior;
              
              treeFields.Add(tfs);
           }
           return treeFields;
        }

        public List<LogFieldSetupDO> GetSelectedLogFields(StratumDO stratum)
        {
            return this.WindowPresenter.Database.Read<LogFieldSetupDO>("LogFieldSetup", "WHERE Stratum_CN = ? ORDER BY FieldOrder", stratum.Stratum_CN);
        }

        #endregion



        public bool ValidateTallySettup(ref StringBuilder errorBuilder)
        {
            if (!_isTallySetupInitialized) { return true; }
            bool isValid = true;
            foreach (TallySetupStratum st in this.TallySetupStrata)
            {
                isValid = this.ValidateHotKeys(st, ref errorBuilder) && isValid;
                
                if (CruiseDAL.Schema.Constants.CruiseMethods.MANDITORY_TALLY_METHODS.Contains(st.Method))
                {
                    foreach (TallySetupSampleGroup sg in st.SampleGroups)
                    {
                        if (sg.TallyMethod == TallyMode.Unknown || (sg.TallyMethod & TallyMode.None) == TallyMode.None)
                        {
                            errorBuilder.AppendFormat("Sample Group {0} in Stratum {1} needs tally configuration\r\n", sg.Code, st.Code);
                            isValid = false;
                        }
                    }
                }
            }
            return isValid;
        }
        
        private bool Save(ref StringBuilder errorBuilder)
        {
            bool success = true;
            View.EndEdits();

            success = this.SaveFieldSetup(ref errorBuilder);
            
            success =  SaveLogMatrix(ref errorBuilder) && success;

            success = SaveTreeAudits(ref errorBuilder) && success;

            if (!ValidateTallySettup(ref errorBuilder))
            {
                return false;
            }

            success = this.SaveTallies(ref errorBuilder) && success;

            return success;
        }

        private bool SaveTreeAudits(ref StringBuilder errorBuilder)
        {
            if (!_isTreeAuditsInitialized) { return true; }
            try
            {
                this.WindowPresenter.Database.BeginTransaction();
                foreach (TreeAuditValueDO tav in TreeAudits)
                {
                    if (tav.DAL == null)
                    {
                        tav.DAL = this.WindowPresenter.Database;
                    }
                    tav.Save();
                    tav.TreeDefaultValues.Save();
                }
                this.WindowPresenter.Database.EndTransaction();
                return true;
            }
            catch (Exception ex)
            {
                errorBuilder.AppendFormat("File save error. Tree Audit Rules was not saved. <Error details: {0}>", ex.ToString());
                this.WindowPresenter.Database.CancelTransaction();
                return false;
            }

        }

        private bool SaveLogMatrix(ref StringBuilder errorBuilder)
        {
            if (!_isLogMatrixInitialized) { return true; }
            try
            {
                this.WindowPresenter.Database.BeginTransaction();

                foreach (LogMatrixDO lm in this.LogMatrix)
                {
                    if (lm.IsPersisted == false)
                    {
                        lm.DAL = this.WindowPresenter.Database;
                    }
                    lm.Save();
                }
                this.WindowPresenter.Database.EndTransaction();
                return true;
            }
            catch (Exception ex)
            {
                errorBuilder.AppendFormat("File save error. Log Matrix data was not saved. <Error details: {0}>", ex.ToString());
                this.WindowPresenter.Database.CancelTransaction();
                return false;
            }
        }

        private bool SaveFieldSetup(ref StringBuilder errorBuilder)
        {
            if (!_isFieldSetupInitialized) { return true; }
            try
            {
                //begin transaction for saving strata and their field set up info
                this.WindowPresenter.Database.BeginTransaction();
                foreach (FieldSetupStratum stratum in this.FieldSetupStrata)
                {

                    //ensure any canges to stratum are saved 
                    stratum.Save();

                    //ensure all unselected tree fields are removed 
                    foreach (TreeFieldSetupDO tf in stratum.UnselectedTreeFields)
                    {
                        if (tf.IsPersisted == true)
                        {
                            tf.Delete();
                        }
                    }

                    //ensure all unselected log fields are removed 
                    foreach (LogFieldSetupDO lf in stratum.UnselectedLogFields)
                    {
                        if (lf.IsPersisted == true)
                        {
                            lf.Delete();
                        }
                    }


                    foreach (TreeFieldSetupDO tf in stratum.SelectedTreeFields)
                    {
                        if (tf.IsPersisted == false)
                        {
                            tf.DAL = this.WindowPresenter.Database;
                            tf.Stratum = stratum;
                        }
                        tf.Save();
                    }
                    foreach (LogFieldSetupDO lf in stratum.SelectedLogFields)
                    {
                        if (lf.IsPersisted == false)
                        {
                            lf.DAL = this.WindowPresenter.Database;
                            lf.Stratum = stratum;
                        }
                        lf.Save();
                    }
                }//end foreach
                this.WindowPresenter.Database.EndTransaction();
                return true;
            }
            catch (Exception ex)
            {
                errorBuilder.AppendFormat("Field setup was not saved. <Error details: {0}>", ex.ToString());
                this.WindowPresenter.Database.CancelTransaction();
                return false;
            }
        }

        private bool SaveTallies(ref StringBuilder errorBuilder)
        {
            if (!_isTallySetupInitialized) { return true; }
            bool success = true;
            foreach (TallySetupStratum stratum in TallySetupStrata)
            {
                if (stratum.SampleGroups != null)
                {
                    foreach (TallySetupSampleGroup sgVM in stratum.SampleGroups)
                    {
                        sgVM.Save();
                        if (sgVM.HasTallyEdits == true)
                        {
                            success = SaveTallies(sgVM, ref errorBuilder) && success;
                        }
                    }
                }
            }
            return success;
        }

        private bool SaveTallies(TallySetupSampleGroup sgVM, ref StringBuilder errorBuilder)
        {
            try
            {
                WindowPresenter.Database.BeginTransaction();

                //if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
                //{
                //    string delCommand = String.Format("DELETE FROM CountTree WHERE SampleGroup_CN = {0}", sgVM.SampleGroup_CN);
                //    Controller.Database.Execute(delCommand); //clead any existing count records. 
                //}

                if ((sgVM.TallyMethod & TallyMode.BySampleGroup) == TallyMode.BySampleGroup)
                {
                    SaveTallyBySampleGroup(sgVM);
                }
                else if ((sgVM.TallyMethod & TallyMode.BySpecies) == TallyMode.BySpecies)
                {
                    SaveTallyBySpecies(sgVM);
                }
                WindowPresenter.Database.EndTransaction();
                sgVM.HasTallyEdits = false;
                return true;
            }
            catch (Exception)
            {
                WindowPresenter.Database.CancelTransaction();
                errorBuilder.AppendFormat("Error: failed to setup tallies for SampleGroup({0} ) in Stratum ({1})", sgVM.Code, sgVM.Stratum.Code);
                return false;
            }
        }

        private void SaveTallyBySampleGroup(TallySetupSampleGroup sgVM)
        {
            if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
            {
                string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) != 0;";
                WindowPresenter.Database.Execute(command, sgVM.SampleGroup_CN);

                string user = WindowPresenter.Database.User;
                String makeCountsCommand = String.Format(@"INSERT  OR Fail INTO CountTree (CuttingUnit_CN, SampleGroup_CN,  CreatedBy)
                            Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN,  '{0}' AS CreatedBy
                            From SampleGroup 
                            INNER JOIN CuttingUnitStratum 
                            ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN 
                            WHERE SampleGroup.SampleGroup_CN = {1};", user, sgVM.SampleGroup_CN);

                WindowPresenter.Database.Execute(makeCountsCommand);
            }
            TallyVM tally = WindowPresenter.Database.ReadSingleRow<TallyVM>("Tally", "WHERE Description = ? AND HotKey = ?", sgVM.SgTallie.Description, sgVM.SgTallie.Hotkey);
            if (tally == null)
            {
                tally = new TallyVM(WindowPresenter.Database) { Description = sgVM.SgTallie.Description, Hotkey = sgVM.SgTallie.Hotkey };
                //tally = sgVM.SgTallie;
                tally.Save();
            }

            String setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1};",
                tally.Tally_CN, sgVM.SampleGroup_CN);

            WindowPresenter.Database.Execute(setTallyCommand);
        }

        private void SaveTallyBySpecies(TallySetupSampleGroup sgVM)
        {
            if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
            {
                string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) = 0;";
                WindowPresenter.Database.Execute(command, sgVM.SampleGroup_CN);

                string user = WindowPresenter.Database.User;
                String makeCountsCommand = String.Format(@"INSERT  OR IGNORE INTO CountTree (CuttingUnit_CN, SampleGroup_CN, TreeDefaultValue_CN, CreatedBy)
                        Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN, SampleGroupTreeDefaultValue.TreeDefaultValue_CN, '{0}' AS CreatedBy 
                        From SampleGroup 
                        INNER JOIN CuttingUnitStratum 
                        ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN 
                        INNER JOIN SampleGroupTreeDefaultValue 
                        ON SampleGroupTreeDefaultValue.SampleGroup_CN = SampleGroup.SampleGroup_CN 
                        WHERE SampleGroup.SampleGroup_CN = {1};",
                        user, sgVM.SampleGroup_CN);


                WindowPresenter.Database.Execute(makeCountsCommand);
            }
            foreach (KeyValuePair<TreeDefaultValueDO, TallyVM> pair in sgVM.Tallies)
            {
                TallyVM tally = WindowPresenter.Database.ReadSingleRow<TallyVM>("Tally", "WHERE Description = ? AND HotKey = ?", pair.Value.Description, pair.Value.Hotkey);
                if (tally == null)
                {
                    tally = new TallyVM(WindowPresenter.Database) { Description = pair.Value.Description, Hotkey = pair.Value.Hotkey };
                    //tally = pair.Value;
                    //tally.DAL = Controller.Database;
                    tally.Save();
                }

                string setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1} AND TreeDefaultValue_CN = {2}",
                    tally.Tally_CN, sgVM.SampleGroup_CN, pair.Key.TreeDefaultValue_CN);

                WindowPresenter.Database.Execute(setTallyCommand);
            }
        }

        #region ISaveHandler Members

        public bool HandleSave()
        {
            StringBuilder errorBuilder = new StringBuilder();
            if (!Save(ref errorBuilder))
            {
                this.WindowPresenter.ShowSimpleErrorMessage(errorBuilder.ToString());
                return false; 
            }
            return true; 

        }

        public void HandleAppClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            StringBuilder errorBuilder = new StringBuilder();
            if (!Save(ref errorBuilder))
            {
                this.WindowPresenter.ShowSimpleErrorMessage(errorBuilder.ToString());
                e.Cancel = true;
            }
        }

        public bool CanHandleSave
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //Dispose(true);
            //GC.SuppressFinalize(this);
        }

     
        #endregion
    }
}
