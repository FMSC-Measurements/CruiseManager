using CruiseDAL;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class TallySetupPresenter : Presentor, ISaveHandler
    {
        private bool _isInitialized;

        public new ViewInterfaces.ITallySetupView View
        {
            get { return (ViewInterfaces.ITallySetupView)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }

        public List<TallySetupStratum_Base> TallySetupStrata { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return TallySetupStrata.Any(x => x.HasChangesToSave);
            }
        }

        public TallySetupPresenter(IApplicationController appController)
            : base(appController)
        {
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            try
            {
                TallySetupStrata = new List<TallySetupStratum_Base>();

                var standardStata = Database.From<TallySetupStratum>()
                    .Where("Method != '" + CruiseDAL.Schema.CruiseMethods.FIXCNT + "'")
                    .Query();

                var fixCNTStrata = Database.From<FixCNTTallySetupStratum>()
                    .Where("Method = '" + CruiseDAL.Schema.CruiseMethods.FIXCNT + "'")
                    .Query();

                foreach (var stratum in standardStata)
                {
                    stratum.Initialize();
                    TallySetupStrata.Add(stratum);
                }

                foreach (var stratum in fixCNTStrata)
                {
                    stratum.Initialize();
                    TallySetupStrata.Add(stratum);
                }

                _isInitialized = true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
            this.View.UpdateTallySetupView();
        }

        public bool ValidateStrata(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
            bool isValid = true;
            foreach (TallySetupStratum_Base st in this.TallySetupStrata)
            {
                if (!st.Validate())
                {
                    errorBuilder.AppendLine("Stratum " + st.Code + ":");
                    errorBuilder.AppendLine(st.Errors);
                    isValid = false;
                }
            }
            return isValid;
        }

        /// <summary>
        /// returns all hot-keys that can be assigned as tally hot keys
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public string[] GetAvalibleTallyHotKeys(TallySetupStratum st, string curHotKey)
        {
            var usedHotKeys = (from stratum in this.TallySetupStrata
                               select stratum.Hotkey);

            usedHotKeys = usedHotKeys.Union(st.ListUsedHotKeys());

            //remove current hot key from list of in use hot keys
            usedHotKeys = usedHotKeys.Except(new string[] { curHotKey });

            var avalibleHotHeys = Strings.HOTKEYS.Except(usedHotKeys).ToArray();
            return avalibleHotHeys;
        }

        /// <summary>
        /// returns all hot-keys that can be assigned as stratum hot-keys.
        /// </summary>
        /// <param name="stratum"></param>
        /// <returns></returns>
        public string[] GetAvalibleStratumHotKeys(TallySetupStratum_Base stratum)
        {
            IEnumerable<String> avalibleHotKeys = Strings.HOTKEYS;
            avalibleHotKeys = avalibleHotKeys.Except(from st in this.TallySetupStrata
                                                     where st != stratum
                                                     select st.Hotkey);

            foreach (var straum in TallySetupStrata.OfType<TallySetupStratum>())
            {
                avalibleHotKeys = avalibleHotKeys.Except(straum.ListUsedHotKeys());
            }
            return avalibleHotKeys.ToArray();
        }

        public bool HandleSave()
        {
            this.View.EndEdits();

            var errorBuilder = new StringBuilder();

            SaveStrata();

            if (!ValidateStrata(ref errorBuilder))
            {
                this.View.ShowErrorMessage("Validation Errors", errorBuilder.ToString());
                return false;
            }
            else if (!SaveTallies(ref errorBuilder))
            {
                this.View.ShowErrorMessage("Save Errors", errorBuilder.ToString());
                return false;
            }
            else
            { return true; }
        }

        private bool SaveStrata()
        {
            bool success = true;

            foreach (TallySetupStratum_Base st in TallySetupStrata)
            {
                try
                {
                    st.Save();
                }
                catch
                {
                    success = false;
                }
            }
            return success;
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

                foreach (TallySetupStratum_Base stratum in TallySetupStrata)
                {
                    stratum.SaveTallySetup(ref errorBuilder);
                }

                this.Database.CommitTransaction();
                return success;
            }
            catch (Exception e)
            {
                this.Database.RollbackTransaction();
                throw e;
            }
        }

        //private bool SaveTallies(TallySetupSampleGroup sgVM, ref StringBuilder errorBuilder)
        //{
        //    try
        //    {
        //        //if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
        //        //{
        //        //    string delCommand = String.Format("DELETE FROM CountTree WHERE SampleGroup_CN = {0}", sgVM.SampleGroup_CN);
        //        //    Controller.Database.Execute(delCommand); //cleaned any existing count records.
        //        //}

        //        if (sgVM.TallyMethod.HasFlag(TallyMode.BySampleGroup))
        //        {
        //            SaveTallyBySampleGroup(sgVM);
        //        }
        //        else if (sgVM.TallyMethod.HasFlag(TallyMode.BySpecies))
        //        {
        //            SaveTallyBySpecies(sgVM);
        //        }
        //        sgVM.HasTallyEdits = false;
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        errorBuilder.AppendFormat("{2}: failed to setup tallies for SampleGroup({0} ) in Stratum ({1})", sgVM.Code, sgVM.Stratum.Code, e.GetType().Name);
        //        return false;
        //    }
        //}

        //private void SaveTallyBySampleGroup(TallySetupSampleGroup sgVM)
        //{
        //    //this.Database.BeginTransaction();
        //    try
        //    {
        //        if (sgVM.IsTallyModeLocked)
        //        {
        //            //remove any possible tally by species records
        //            string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) != 0;";
        //            this.Database.Execute(command, sgVM.SampleGroup_CN);

        //            string user = this.Database.User;
        //            String makeCountsCommand = String.Format(@"INSERT  OR Ignore INTO CountTree (CuttingUnit_CN, SampleGroup_CN,  CreatedBy)
        //                    Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN,  '{0}' AS CreatedBy
        //                    From SampleGroup
        //                    INNER JOIN CuttingUnitStratum
        //                    ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN
        //                    WHERE SampleGroup.SampleGroup_CN = {1};", user, sgVM.SampleGroup_CN);

        //            this.Database.Execute(makeCountsCommand);
        //        }
        //        TallyVM tally = this.Database.From<TallyVM>()
        //            .Where("Description = ? AND HotKey = ?")
        //            .Query(sgVM.SgTallie.Description, sgVM.SgTallie.Hotkey)
        //            .FirstOrDefault();

        //        if (tally == null)
        //        {
        //            tally = new TallyVM(this.Database) { Description = sgVM.SgTallie.Description, Hotkey = sgVM.SgTallie.Hotkey };
        //            //tally = sgVM.SgTallie;
        //            tally.Save();
        //        }

        //        String setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1};",
        //            tally.Tally_CN, sgVM.SampleGroup_CN);

        //        this.Database.Execute(setTallyCommand);

        //        //this.Database.EndTransaction();
        //    }
        //    catch (Exception)
        //    {
        //        //this.Database.CancelTransaction();
        //        throw;
        //    }
        //}

        //private void SaveTallyBySpecies(TallySetupSampleGroup sgVM)
        //{
        //    //this.Database.BeginTransaction();
        //    try
        //    {
        //        if (sgVM.IsTallyModeLocked)
        //        {
        //            //remove any preexisting tally by sg entries
        //            string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) = 0;";
        //            this.Database.Execute(command, sgVM.SampleGroup_CN);

        //            string user = this.Database.User;
        //            String makeCountsCommand = String.Format(@"INSERT  OR IGNORE INTO CountTree (CuttingUnit_CN, SampleGroup_CN, TreeDefaultValue_CN, CreatedBy)
        //                Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN, SampleGroupTreeDefaultValue.TreeDefaultValue_CN, '{0}' AS CreatedBy
        //                From SampleGroup
        //                INNER JOIN CuttingUnitStratum
        //                ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN
        //                INNER JOIN SampleGroupTreeDefaultValue
        //                ON SampleGroupTreeDefaultValue.SampleGroup_CN = SampleGroup.SampleGroup_CN
        //                WHERE SampleGroup.SampleGroup_CN = {1};",
        //                    user, sgVM.SampleGroup_CN);

        //            this.Database.Execute(makeCountsCommand);
        //        }
        //        foreach (KeyValuePair<TreeDefaultValueDO, TallyVM> pair in sgVM.Tallies)
        //        {
        //            TallyVM tally = this.Database.From<TallyVM>()
        //                .Where("Description = ? AND HotKey = ?")
        //                .Query(pair.Value.Description, pair.Value.Hotkey)
        //                .FirstOrDefault();

        //            if (tally == null)
        //            {
        //                tally = new TallyVM(this.Database) { Description = pair.Value.Description, Hotkey = pair.Value.Hotkey };
        //                //tally = pair.Value;
        //                //tally.DAL = Controller.Database;
        //                tally.Save();
        //            }

        //            string setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1} AND TreeDefaultValue_CN = {2}",
        //                tally.Tally_CN, sgVM.SampleGroup_CN, pair.Key.TreeDefaultValue_CN);

        //            this.Database.Execute(setTallyCommand);
        //        }

        //        //this.Database.EndTransaction();
        //    }
        //    catch (Exception)
        //    {
        //        //this.Database.CancelTransaction();
        //        throw;
        //    }
        //}
    }
}