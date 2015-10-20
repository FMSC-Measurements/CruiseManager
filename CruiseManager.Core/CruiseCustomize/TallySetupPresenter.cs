using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseDAL.Enums;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class TallySetupPresenter : Presentor, ISaveHandler
    {
        bool _isInitialized;

        public new ViewInterfaces.ITallySetupView View
        {
            get { return (ViewInterfaces.ITallySetupView)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }

        public List<TallySetupStratum> TallySetupStrata { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return TallySetupStrata.Any(x => x.SampleGroups.Any(y => y.HasTallyEdits));
            }
        }

        public TallySetupPresenter(ApplicationControllerBase appController) 
            :base(appController)
        {

        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            try
            {
                this.TallySetupStrata = this.Database.Read<TallySetupStratum>("Stratum", null);

                foreach (TallySetupStratum stratum in this.TallySetupStrata)
                {
                    this.LoadSampleGroups(stratum);
                }
                //TallyPresets = this.Database.Read<TallyVM>("Tally", null);
                _isInitialized = true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
            this.View.UpdateTallySetupView();
        }

        public bool CanDefintTallys(StratumDO stratum)
        {
            return StratumDO.CanDefineTallys(stratum);
        }

        protected void LoadSampleGroups(TallySetupStratum stratum)
        {
            if (stratum.SampleGroups != null) { return; }//if we have already created initialized this stratum, 

            stratum.SampleGroups = Database.Read<TallySetupSampleGroup>("SampleGroup", "WHERE Stratum_CN = ?", stratum.Stratum_CN);
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

        public bool ValidateTallySettup(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
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

        public string[] GetAvalibleHotKeysInStratum(TallySetupStratum st)
        {
            var useHotKeys = (from StratumDO stratum in this.TallySetupStrata
                              select stratum.Hotkey).Union(st.ListHotKeysInuse());
            var avalibleHotHeys = Strings.HOTKEYS.Except(useHotKeys).ToArray();
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
            return Strings.HOTKEYS.Except(usedHotKeys).ToArray();
            //return CSM.Utility.R.Strings.HOTKEYS;
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
                    if (hk == char.MinValue)
                    {
                        errorBuilder.AppendFormat("Missing Hot Key in SG:{0} Stratum:{1}\r\n", sgVM.ToString(), st.Code);
                    }
                    else if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                    {
                        //ERROR stratum already has hot-key
                        errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", sgVM.SgTallie.Hotkey, sgVM.ToString(), st.Code);
                        success = false;
                    }
                    else
                    {
                        //SUCCESS add hot key to list of in use hot keys
                        usedHotKeys.Add(hk);
                    }
                }
                else if ((sgVM.TallyMethod & TallyMode.BySpecies) == TallyMode.BySpecies)
                {
                    foreach (TallyVM t in sgVM.Tallies.Values)
                    {
                        char hk = HotKeyToChar(t.Hotkey);
                        if (hk == char.MinValue)
                        {
                            errorBuilder.AppendFormat("Missing Hot Key in SG:{0} Stratum:{1}\r\n", sgVM.ToString(), st.Code);
                        }
                        if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                        {
                            //ERROR stratum already has hot-key
                            errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", t.Hotkey, sgVM.ToString(), st.Code);
                            success = false;
                        }
                        else
                        {
                            //SUCCESS add hot key to list of in use hot keys
                            usedHotKeys.Add(hk);
                        }
                    }
                }
            }

            return success;
        }

        public static char HotKeyToChar(string str)//TODO move method somewhere more useful
        {
            if (String.IsNullOrEmpty(str))
            {
                return char.MinValue;
            }
            return char.ToUpper(str[0]);
        }

        public bool HandleSave()
        {
            return this.Save();
        }

        private bool Save()
        {
            var errorBuilder = new StringBuilder();
            if(!ValidateTallySettup(ref errorBuilder))
            {
                this.View.ShowErrorMessage("Validation Errors", errorBuilder.ToString());
                return false;
            }
            else if(!SaveTallies(ref errorBuilder))
            {
                this.View.ShowErrorMessage("Save Errors", errorBuilder.ToString());
                return false;
            }
            else
            { return true; }
        }

        private bool SaveTallies(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
            bool success = true;

            this.Database.BeginTransaction();
            try
            {

                this.Database.Execute(
@"CREATE TEMP TRIGGER IF NOT EXISTS IgnoreConflictsOnCountTree 
BEFORE INSERT
ON CountTree
WHEN Exists
(
    SELECT 1 FROM CountTree WHERE CountTree.CuttingUnit_CN = new.CuttingUnit_CN
    AND CountTree.SampleGroup_CN = new.SampleGroup_CN
    AND ifnull(CountTree.TreeDefaultValue_CN, 0) = ifnull(new.TreeDefaultValue_CN, 0)
    AND ifnull(CountTree.Component_CN, 0) = ifnull(new.Component_CN, 0)
)
BEGIN
SELECT RAISE(IGNORE);
END;"
                    );

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

                this.Database.EndTransaction();
                return success;
            }
            catch (Exception e)
            {
                this.Database.CancelTransaction();
                throw e;
            }
        }

        private bool SaveTallies(TallySetupSampleGroup sgVM, ref StringBuilder errorBuilder)
        {
            try
            { 
                //if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
                //{
                //    string delCommand = String.Format("DELETE FROM CountTree WHERE SampleGroup_CN = {0}", sgVM.SampleGroup_CN);
                //    Controller.Database.Execute(delCommand); //cleaned any existing count records. 
                //}

                if ((sgVM.TallyMethod & TallyMode.BySampleGroup) == TallyMode.BySampleGroup)
                {
                    SaveTallyBySampleGroup(sgVM);
                }
                else if ((sgVM.TallyMethod & TallyMode.BySpecies) == TallyMode.BySpecies)
                {
                    SaveTallyBySpecies(sgVM);
                }
                sgVM.HasTallyEdits = false;
                return true;
            }
            catch (Exception e)
            {
                errorBuilder.AppendFormat("{2}: failed to setup tallies for SampleGroup({0} ) in Stratum ({1})", sgVM.Code, sgVM.Stratum.Code, e.GetType().Name);
                return false;
            }
        }

        private void SaveTallyBySampleGroup(TallySetupSampleGroup sgVM)
        {
            this.Database.BeginTransaction();
            try
            {
                if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
                {
                    //remove any possible tally by species records
                    string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) != 0;";
                    this.Database.Execute(command, sgVM.SampleGroup_CN);

                    string user = this.Database.User;
                    String makeCountsCommand = String.Format(@"INSERT  OR Ignore INTO CountTree (CuttingUnit_CN, SampleGroup_CN,  CreatedBy)
                            Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN,  '{0}' AS CreatedBy
                            From SampleGroup 
                            INNER JOIN CuttingUnitStratum 
                            ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN 
                            WHERE SampleGroup.SampleGroup_CN = {1};", user, sgVM.SampleGroup_CN);

                    this.Database.Execute(makeCountsCommand);
                }
                TallyVM tally = this.Database.ReadSingleRow<TallyVM>("Tally", "WHERE Description = ? AND HotKey = ?", sgVM.SgTallie.Description, sgVM.SgTallie.Hotkey);
                if (tally == null)
                {
                    tally = new TallyVM(this.Database) { Description = sgVM.SgTallie.Description, Hotkey = sgVM.SgTallie.Hotkey };
                    //tally = sgVM.SgTallie;
                    tally.Save();
                }

                String setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1};",
                    tally.Tally_CN, sgVM.SampleGroup_CN);

                this.Database.Execute(setTallyCommand);
                this.Database.EndTransaction();
            }
            catch(Exception)
            {
                this.Database.CancelTransaction();
                throw;
            }
        }

        private void SaveTallyBySpecies(TallySetupSampleGroup sgVM)
        {
            this.Database.BeginTransaction();
            try
            {
                if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
                {
                    //remove any preexisting tally by sg entries
                    string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) = 0;";
                    this.Database.Execute(command, sgVM.SampleGroup_CN);

                    string user = this.Database.User;
                    String makeCountsCommand = String.Format(@"INSERT  OR IGNORE INTO CountTree (CuttingUnit_CN, SampleGroup_CN, TreeDefaultValue_CN, CreatedBy)
                        Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN, SampleGroupTreeDefaultValue.TreeDefaultValue_CN, '{0}' AS CreatedBy 
                        From SampleGroup 
                        INNER JOIN CuttingUnitStratum 
                        ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN 
                        INNER JOIN SampleGroupTreeDefaultValue 
                        ON SampleGroupTreeDefaultValue.SampleGroup_CN = SampleGroup.SampleGroup_CN 
                        WHERE SampleGroup.SampleGroup_CN = {1};",
                            user, sgVM.SampleGroup_CN);



                    this.Database.Execute(makeCountsCommand);
                }
                foreach (KeyValuePair<TreeDefaultValueDO, TallyVM> pair in sgVM.Tallies)
                {
                    TallyVM tally = this.Database.ReadSingleRow<TallyVM>("Tally", "WHERE Description = ? AND HotKey = ?", pair.Value.Description, pair.Value.Hotkey);
                    if (tally == null)
                    {
                        tally = new TallyVM(this.Database) { Description = pair.Value.Description, Hotkey = pair.Value.Hotkey };
                        //tally = pair.Value;
                        //tally.DAL = Controller.Database;
                        tally.Save();
                    }

                    string setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1} AND TreeDefaultValue_CN = {2}",
                        tally.Tally_CN, sgVM.SampleGroup_CN, pair.Key.TreeDefaultValue_CN);

                    this.Database.Execute(setTallyCommand);
                }

                this.Database.EndTransaction();
            }
            catch(Exception)
            {
                this.Database.CancelTransaction();
                throw;
            }

        }


    }
}
