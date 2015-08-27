using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSM.UI;
using CruiseDAL;
using CruiseDAL.DataObjects;

namespace CSM.Logic
{



    public class MergeComponentsPresenter : IPresentor
    {
        

        public class ComponentFileVM : ComponentDO
        {
            //public String FileName { get; set; }
            public String FullPath { get; set; }
            public DAL Database { get; set; }
            public int TreeCount { get; set; }
            public int Edits { get; set; }
            //public string LastMod { get; set; }
            public int Warnings { get; set; }
            public int EstablishmentEdits { get; set; }
            public string Errors { get; set; }
            public int TreeEdits { get; set; }
            public int LogEdits { get; set; }
        }

        //public static readonly string COMP_ALIAS = "Comp";

        public MergeComponentView View { get; set; }

        public string[] ComponentFileNames
        {
            get
            {
                return new String[0];
            }
        }

        public List<ComponentFileVM> Components
        { get; set; }

        public DAL MasterDB { get { return Controller.Database; } }


        public MergeComponentsPresenter(IWindowPresenter controller)
        {
            this.Controller = controller;
        }

        public int TreesAdded { get; set; }
        public int TreesUpdated { get; set; }
        public int LogsAdded { get; set; }
        public int LogsUpdated { get; set; }
        public int PlotsAdded { get; set; }
        public int PlotsUpdated { get; set; }
        public int StemsAdded { get; set; }
        public int StemsUpdated { get; set; }

        public int TDVAdded { get; set; }
        public int SGAdded { get; set; }
        public int SGTDVAdded { get; set; }
        public string Errors { get; set; }



        public bool FindComponents(string searchDir, out List<String> missingFileList)
        {
            bool success = true;
            missingFileList = new List<string>();
            Components = Controller.Database.Read<ComponentFileVM>("Component", null);

            foreach(ComponentFileVM comp in Components)
            {
                if (comp.Database != null) { continue; }//if we already have a DAL for the copmonent assume that the file exists

                comp.FullPath = searchDir + "\\" + comp.FileName; 

                if(!InitializeComponent(comp))//try to initialize component, if initialization fails add to missing file list
                {
                    success = false;
                    missingFileList.Add(comp.FileName);
                }
            }
            return success;
        }

        private bool InitializeComponent(ComponentFileVM comp)
        {
            if (!System.IO.File.Exists(comp.FullPath))
            {
                comp.Errors = "File not found";
                return false;
            }

            try
            {
                comp.Database = new DAL(comp.FullPath);
                comp.TreeCount = GetTreeCount(comp.Database);
                comp.TreeEdits = GetTreeEdits(MasterDB, comp.Database);
                comp.EstablishmentEdits = GetEstablishmentEdits(MasterDB, comp.Database);
                //comp.LastMod = GetLastMergeDate(comp.DataBase);
                String[] errors;
                if (comp.Database.HasCruiseErrors(out errors))
                {
                    comp.Errors += string.Join("\r\n", errors);
                }
                return true;
            }
            catch(Exception e)
            {
                comp.Errors += e.Message;
                return false;
            }
        }

        public void BenginPreviewGenerate()
        {


        }

        public int GetNumComponents()
        {
            try
            {
                GlobalsDO info = MasterDB.ReadSingleRow<GlobalsDO>("Globals", "WHERE Block = 'Comp' AND Key = 'ChildComponents'");
                return Convert.ToInt32(info.Value);
            }
            catch
            {
                return 0;
            }
        }

        public int GetMasterTreeCount()
        {
            return GetTreeCount(MasterDB);
        }

        private int GetTreeCount(DAL database)
        {
            return (int)database.GetRowCount("Tree", null, null);
        }

        public string GetMasterLastMergeDate()
        {
            return GetLastMergeDate(MasterDB);
        }

        private static string GetLastMergeDate(DAL dataBase)
        {
            //GlobalsDO globalData = dataBase.ReadSingleRow<GlobalsDO>("Globals", "WHERE Block = 'Comp' AND Key = 'LastMerge'");

            //if (globalData != null)
            //{
            //    return globalData.Value;
            //}
            return string.Empty;
        }



        private static void SetLastMergeDate(DAL db, string dateStr)
        {
            GlobalsDO data = new GlobalsDO(db)
            {
                Block = "Comp",
                Key = "LastMerge",
                Value = dateStr
            };
            data.Save(OnConflictOption.Replace);
        }


        private int GetCountSum(CountTreeDO masterCopy)
        {
            int countSum = 0;
            foreach (ComponentFileVM comp in this.Components)
            {
                CountTreeDO compCount = comp.Database.ReadSingleRow<CountTreeDO>
                    ("CountTree", masterCopy.CountTree_CN);

                countSum += (int)compCount.TreeCount;

            }
            return countSum;
        }



        private static int GetTreeEdits(DAL masterDB, DAL componentDB)
        {
            int editCount = -1;
            try
            {
                masterDB.AttachDB(componentDB, "CompDB");
                //masterDB.BeginTransaction();
                
                editCount = (int)masterDB.GetRowCount("Tree", "JOIN CompDB.Tree AS CompTree ON Tree.Tree_CN = CompTree.Tree_CN WHERE Tree.ModifiedDate < CompTree.ModifiedDate");
            }
            catch { /*do nothing*/ }
            finally
            {
                
                //masterDB.CancelTransaction();
                masterDB.DetachDB("CompDB");
            }

            return editCount;
        }

        private static int GetTreeDeletions(DAL masterDB, DAL compDB)
        {
            int delCount = -1;
            try
            {
                masterDB.AttachDB(compDB, "CompDB");
                //masterDB.BeginTransaction();
                
                delCount = (int)masterDB.Execute("SELECT Tree_CN From main.Tree EXCEPT SELECT Tree_CN FROM CompDB.Tree;");
            }
            catch {}
            finally
            {
                //masterDB.CancelTransaction();
                masterDB.DetachDB("CompDB");
            }

            return delCount;
        }


        private static int GetCompTreeDeletions(DAL masterDB, DAL compDB)
        {
            return PerformCrossCheck(masterDB, compDB, "Tree", "JOIN CompDB.Tree AS CompTree ON Tree.Tree_CN = CompTree.Tree_CN WHERE CompTree.Tree_CN IS NULL");
        }

        private static int GetCompLogEdits(DAL masterDB, DAL compDB)
        {
            return PerformCrossCheck(masterDB, compDB, "Log", "JOIN CompDB.Log AS CompLog ON Log.Log_CN = CompLog WHERE Log.ModifiedDate < CompLog.ModifiedDate"); 
        }

        private static int GetCompLogDeletions(DAL masterDB, DAL compDB)
        {
            return PerformCrossCheck(masterDB, compDB, "Log", "JOIN CompDB.Log AS CompLog ON Log.Log_CN = CompLog.Log_CN WHERE CompLog.Log_CN IS NULL");
        }

        private static int GetEstablishmentEdits(DAL masterDB, DAL compDB)
        {
            int editCount = 0;
            editCount += PerformCrossCheck(masterDB, compDB,"Stratum", 
                    @"JOIN CompDB.Stratum AS CompStratum ON CompStratum.Stratum_CN = Stratum.Stratum_CN 
                    WHERE CompStratum.ModifiedDate > Stratum.ModifiedDate");
            
            editCount += PerformCrossCheck(masterDB, compDB, "CuttingUnit", 
                    @"JOIN CompDB.CuttingUnit AS compUnits ON compUnits.CuttingUnit_CN = CuttingUnit.CuttingUnit_CN 
                    WHERE compUnits.ModifiedDate > CuttingUnit.ModifiedDate");
            
            editCount += PerformCrossCheck(masterDB, compDB, "CuttingUnitStratum", 
                    @"JOIN CompDB.CuttingUnitStratum AS compMap 
                    ON compMap.CuttingUnit_CN = CuttingUnitStratum.CuttingUnit_CN 
                    AND compMap.Stratum_CN = CuttingUnitStratum.Stratum_CN 
                    WHERE compMap.RowID IS NULL OR CuttingUnitStratum.RowID IS NULL");

            editCount += PerformCrossCheck(masterDB, compDB, "SampleGroup",
                    @"JOIN CompDB.SampleGroup AS compSG ON compSG.SampleGroup_CN = SampleGroup.SampleGroup_CN 
                    WHERE compSG.ModifiedDate > SampleGroup.ModifiedDate");

//            editCount += PerformCrossCheck(masterDB, compDB, "TreeDefaultValue",
//                    @"JOIN CompDB.TreeDefaultValue AS compTDV
//                    ON compTDV.TreeDefaultValue_CN = TreeDefaultValue.TreeDefaultValue_CN
//                    WHERE compTDV.ModifiedDate > TreeDefaultValue.ModifiedDate");

            return editCount;
        }

        //private static void CopyTreeData(int startRowID, int endRowID, DAL masterDB, DAL compDB)
        //{
        //    try
        //    {
        //        masterDB.AttachDB(compDB, "CompDB");

        //        masterDB.BeginTransaction();
        //        //Copy new Tree data
        //        masterDB.Execute("INSERT OR IGNORE INTO Tree SELECT FROM CompDB.Tree;");

        //        //Copy data changes
        //        //...

        //    }
        //    finally
        //    {
        //        masterDB.EndTransaction();
        //        masterDB.DetachDB("CompDB");
        //    }
        //}

        private static int PerformCrossCheck(DAL masterDB, DAL compDB, string tableName, string selection)
        {
            int editCount = -1;
            try
            {
                masterDB.AttachDB(compDB, "CompDB");
                editCount = (int)masterDB.GetRowCount(tableName, selection);


            }
            catch { /*do nothing*/ }
            finally
            {
                masterDB.DetachDB("CompDB");
            }

            return editCount;



        }

        public void BeginMerge()
        {
            Merge();
        }

        private void Merge()
        {
            //reset merge stats
            TreesAdded = 0;
            TreesUpdated = 0;
            PlotsAdded = 0;
            PlotsUpdated = 0;
            LogsAdded = 0;
            LogsUpdated = 0;
            StemsAdded = 0;
            StemsUpdated = 0;

            SGAdded = 0;
            TDVAdded = 0;
            SGTDVAdded = 0;

            this.Errors = String.Empty;

            int totalSteps = Components.Count + 2; //total number of time we can expect StepProgressBar to be called
            View.InitializeAndShowProgress(totalSteps);
            try
            {
                MasterDB.BeginTransaction();


                View.StepProgressBar();//////////////////////////////////////////////

                //start merging files
                foreach(ComponentFileVM comp in Components)
                {
                    try
                    {

                        ExecuteSingleMerge(comp);
                        //update the last merge entry in the master
                        comp.LastMerge = DateTime.Now.ToString("g");
                        comp.Save();
                    }
                    catch (Exception)
                    {
                        this.Errors += String.Format("Component: {0} failed to merge\r\n", comp.FileName);
                    }

                    View.StepProgressBar();/////////////////////////////////////////

                }
                string mergeDate = DateTime.Today.ToShortDateString();
                SetLastMergeDate(MasterDB, mergeDate);
                View.StepProgressBar();/////////////////////////////////////////////

                //commit transaction in database
                MasterDB.EndTransaction();

            }
            catch (Exception)
            {
                //cancel transaction, no change made to master database
                MasterDB.CancelTransaction();
            }
            finally
            {
                View.HideProgressBar();
            }

            View.ShowPostMergeReport();
        }

        public void ExecuteSingleMerge(ComponentFileVM comp)
        {
            DAL compDB = comp.Database;
            if (compDB == null) { return; }

            //start save point 
            string savePointName = String.Format("merge{0}", comp.Component_CN);
            
            MasterDB.Execute(string.Format("SAVEPOINT {0};", savePointName));
            try
            {
                this.UpdateTDVs(comp);
                this.UpdateSampleGroup(comp);
                this.UpdateSampleGroupTDVmappings(comp);
                this.UpdateCounts(comp);
                this.MergePlots(compDB);
                this.MergeTrees(compDB);
                this.MergeLogs(compDB);
                this.MergeStem(compDB);

                MasterDB.Execute(String.Format("RELEASE SAVEPOINT {0};", savePointName));
                SetLastMergeDate(compDB, DateTime.Today.ToShortDateString());

            }
            catch(Exception e)
            {
                MasterDB.Execute(String.Format("ROLLBACK TO SAVEPOINT {0};", savePointName));
                throw e;
            }
 
        }

        public void MergeLogs(DAL compDB)
        {
            List<LogDO> compLogs = compDB.Read<LogDO>("Log", null);

            try
            {
                //MasterDB.BeginTransaction();
                foreach (LogDO l in compLogs)
                {
                    LogDO match = MasterDB.ReadSingleRow<LogDO>("Log", "WHERE Log_CN = ?", l.Log_CN);
                    if (match == null)
                    {
                        match = new LogDO(MasterDB);
                        match.StartWrite();
                        match.Tree_CN = l.Tree_CN;
                        match.rowID = l.Log_CN;
                        match.EndWrite();
                        match.SetValues(l);
                        MasterDB.Save(match, true, OnConflictOption.Fail);
                        LogsAdded++;
                    }
                    else
                    {          
                        match.SetValues(l);
                        if (match.HasChanges)
                        {
                            LogsUpdated++;
                            match.Save();
                        }
                    }
                }

                //MasterDB.EndTransaction();
            }
            catch (Exception e)
            {
                //MasterDB.CancelTransaction();
                throw e;
            }
        }


        private void MergeNewCount(CountTreeDO componentCount)
        {
                CountTreeDO newCount = new CountTreeDO(MasterDB);
                newCount.SetValues(componentCount);
                newCount.SampleGroup_CN = componentCount.SampleGroup_CN;
                newCount.CuttingUnit_CN = componentCount.CuttingUnit_CN;
                //newCount.CreatedDate = componentCount.CreatedDate;
                //newCount.CreatedBy = componentCount.CreatedBy;
                newCount.Component_CN = componentCount.Component_CN;
                newCount.TreeDefaultValue_CN = componentCount.TreeDefaultValue_CN;
                newCount.Tally_CN = componentCount.Tally_CN;
                newCount.Save();
        }

        private void UpdateTDVs(ComponentFileVM comp)
        {
            DAL compDB = comp.Database;
            System.Diagnostics.Debug.Assert(compDB != null);

            List<TreeDefaultValueDO> compTDV = compDB.Read<TreeDefaultValueDO>("TreeDefaultValue", null);

            try
            {
                foreach(TreeDefaultValueDO tdv in compTDV)
                {
                    TreeDefaultValueDO match = MasterDB.ReadSingleRow<TreeDefaultValueDO>("TreeDefaultValue", "WHERE PrimaryProduct = ? AND Species = ? AND LiveDead = ?", tdv.PrimaryProduct, tdv.Species, tdv.LiveDead);
                    if(match == null)
                    {
                        match = new TreeDefaultValueDO(MasterDB);
                        match.StartWrite();
                        match.SetValues(tdv);
                        match.EndWrite();
                        match.Save();
                        this.TDVAdded++;
                    }

                    if(match.rowID != tdv.rowID)//unlikely 
                    {
                        compDB.Execute(String.Format(@"pragma foreign_keys = off;
                                        UPDATE TreeDefaultValue Set TreeDefaultValue_CN = {0} WHERE TreeDefaultValue_CN = {1};
                                        UPDATE SampleGroupTreeDefaultValue Set TreeDefaultValue_CN = {0} WHERE TreeDefaultValue_CN = {1};
                                        UPDATE Tree Set TreeDefaultValue_CN = {0} WHERE TreeDefaultValue_CN = {1};
                                        UPDATE CountTree Set TreeDefaultValue_CN = {0} WHERE TreeDefaultValue_CN = {1};", match.TreeDefaultValue_CN, tdv.TreeDefaultValue_CN));
                        tdv.rowID = match.rowID;
                    }
                }
            }
            catch
            {

            }

        }

        private void UpdateSampleGroup(ComponentFileVM comp)
        {
            DAL compDB = comp.Database;
            System.Diagnostics.Debug.Assert(compDB != null);


            List<SampleGroupDO> compSG = compDB.Read<SampleGroupDO>("SampleGroup", null);

            try
            {
                foreach(SampleGroupDO sg in compSG)
                {
                    SampleGroupDO match = MasterDB.ReadSingleRow<SampleGroupDO>("SampleGroup", "WHERE Code = ? and Stratum_CN = ?", sg.Code, sg.Stratum_CN);
                    if(match == null)
                    {
                        match = new SampleGroupDO(MasterDB);
                        match.StartWrite();
                        match.SetValues(sg);
                        match.Stratum_CN = sg.Stratum_CN;
                        match.EndWrite();
                        match.Save();
                        this.SGAdded++;
                    }

                    if(match.rowID != sg.rowID)//unlikely 
                    {
                        compDB.Execute(String.Format(@"pragma foreign_keys = off;
                                         UPDATE SampleGroup Set SampleGroup_cn = {0} WHERE SampleGroup_CN = {1};
                                         UPDATE SampleGroupTreeDefaultValue Set SampleGroup_cn = {0} WHERE SampleGroup_CN = {1};
                                         UPDATE Tree Set SampleGroup_cn = {0} WHERE SampleGroup_CN = {1};
                                         UPDATE CountTree Set SampleGroup_cn = {0} WHERE SampleGroup_CN = {1};", match.SampleGroup_CN, sg.SampleGroup_CN));
                    }
                }
            }
            catch
            {

            }
        }

        private void UpdateSampleGroupTDVmappings(ComponentFileVM comp)
        {
            DAL compDB = comp.Database;
            System.Diagnostics.Debug.Assert(compDB != null);

            List<SampleGroupTreeDefaultValueDO> compSGTDV = compDB.Read<SampleGroupTreeDefaultValueDO>("SampleGroupTreeDefaultValue", null);

            try
            {
                foreach(SampleGroupTreeDefaultValueDO sgtdv in compSGTDV)
                {
                    SampleGroupTreeDefaultValueDO match = MasterDB.ReadSingleRow<SampleGroupTreeDefaultValueDO>("SampleGroupTreeDefaultValue", "WHERE TreeDefaultValue_CN = ? AND SampleGroup_CN = ?", sgtdv.TreeDefaultValue_CN, sgtdv.SampleGroup_CN);
                    if(match == null)
                    {
                        match = new SampleGroupTreeDefaultValueDO(MasterDB);
                        match.StartWrite();
                        match.SampleGroup_CN = sgtdv.SampleGroup_CN;
                        match.TreeDefaultValue_CN = sgtdv.TreeDefaultValue_CN;
                        match.EndWrite();
                        match.Save();
                        this.SGTDVAdded++;
                    }
                }
            }
            catch
            {

            }
        }

        private void UpdateCounts(ComponentFileVM comp)
        {
            DAL compDB = comp.Database;
            System.Diagnostics.Debug.Assert(compDB != null);
            //bool _showNewPopWarning = true;
            List<CountTreeDO> compCounts = compDB.Read<CountTreeDO>("CountTree", null);
            
            try
            {
                //MasterDB.AttachDB(compDB, COMP_ALIAS);
                foreach (CountTreeDO count in compCounts)
                {
                    if (count.Component_CN != comp.Component_CN)
                    {
                        count.Component_CN = comp.Component_CN;
                        count.Save();
                    }

                    string countFilter = String.Format("SampleGroup_CN = {0} AND CuttingUnit_CN = {1} AND TreeDefaultValue_CN {2} AND Component_CN = {3};", 
                            count.SampleGroup_CN,
                            count.CuttingUnit_CN,
                            (count.TreeDefaultValue_CN != null) ? ("= " + count.TreeDefaultValue_CN) : "IS NULL",
                            count.Component_CN);


                    if (MasterDB.GetRowCount(CruiseDAL.Schema.COUNTTREE._NAME,
                        "WHERE " + countFilter) > 0)
                    {
                        string command = string.Format(
                            @"UPDATE CountTree
                        SET TreeCount = {0}, SumKPI = {1}
                        WHERE " + countFilter + ";",
                            count.TreeCount,
                            count.SumKPI);
                        MasterDB.Execute(command);
                    }
                    else
                    {
                        this.MergeNewCount(count);                        
                        //if (_showNewPopWarning)
                        //{
                        //    System.Windows.Forms.MessageBox.Show("Population fround in component that is not in master,\r\n" +
                        //        "Merging of new populations not supported at this time");
                        //    _showNewPopWarning = false;
                        //}
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void MergePlots(DAL compDB)
        {
            List<PlotDO> compPlots = compDB.Read<PlotDO>("Plot", null);

            try
            {
                //MasterDB.BeginTransaction();
                foreach (PlotDO p in compPlots)
                {
                    PlotDO match = MasterDB.ReadSingleRow<PlotDO>("Plot", "WHERE PlotNumber = ? AND CuttingUnit_CN = ? AND Stratum_CN = ?", p.PlotNumber, p.CuttingUnit_CN, p.Stratum_CN);
                    if (match == null)
                    {
                        match = new PlotDO(MasterDB);
                        match.StartWrite();
                        //match.rowID = p.Plot_CN;
                        match.CuttingUnit_CN = p.CuttingUnit_CN;
                        match.Stratum_CN = p.Stratum_CN;
                        match.EndWrite();
                        match.SetValues(p);
                        match.Validate();
                        match.Save();
                        PlotsAdded++;
                    }
                    else
                    {
                        match.SetValues(p);
                        match.Validate();
                        if (match.HasChanges)
                        {
                            PlotsUpdated++;
                            match.Save();
                        }                                                
                    }

                    if (match.rowID != p.rowID)
                    {
                        compDB.Execute(String.Format("UPDATE Tree SET Plot_CN = {0} WHERE Plot_CN = {1};", match.Plot_CN, p.Plot_CN));
                        compDB.ChangeRowID(p, match.rowID.Value, OnConflictOption.Fail);
                        //compDB.Save(p, true, OnConflictOption.Fail);
                    }
                }
                //MasterDB.EndTransaction();
            }
            catch (Exception e)
            {
                //MasterDB.CancelTransaction();
                throw e;
            }

                    

//            string updatePlotsCommand = string.Format(@"
//                    WITH tmp (
//                        SELECT {0}.Plot.* FROM {0}.Plot JOIN main.Plot ON {0}.Plot.Plot_CN = main.Plot.Plot_CN
//                        WHERE {0}.Plot.ModifiedDate > main.Plot.ModifiedDate )
//                    UPDATE main.Plot SET IsEmpty = tmp.IsEmpty,
//                    Slope = tmp.Slope
//                    KPI = tmp.KPI,
//                    Aspect = tmp.Aspect,
//                    Remarks = tmp.Remarks,
//                    XCoordinate = tmp.XCoordinate,
//                    YCoordinate = tmp.YCoordinate,
//                    ZCoordinate = tmp.ZCoordinate,
//                    MetaData = tmp.MetaData,
//                    Blob = tmp.Blob;
//                    ", alias);
//            compDB.Execute(updatePlotsCommand);

        }

        public void MergeTrees(DAL compDB)
        {
            List<TreeDO> compTrees = compDB.Read<TreeDO>("Tree", null);

            try
            {
                //MasterDB.BeginTransaction();
                foreach (TreeDO t in compTrees)
                {
                    TreeDO match = MasterDB.ReadSingleRow<TreeDO>("Tree", "WHERE Tree_CN = ?", t.Tree_CN);
                    if (match == null)
                    {
                        match = new TreeDO(MasterDB);
                        match.rowID = t.Tree_CN;
                        match.SampleGroup_CN = t.SampleGroup_CN;
                        match.Stratum_CN = t.Stratum_CN;
                        match.CuttingUnit_CN = t.CuttingUnit_CN;
                        match.Plot_CN = t.Plot_CN;
                        match.SetValues(t);
                        match.StartWrite();
                        match.TreeDefaultValue_CN = t.TreeDefaultValue_CN;
                        match.EndWrite();
                        match.Validate();
                        MasterDB.Save(match, true, OnConflictOption.Fail);
                        TreesAdded++;
                    }
                    else
                    {

                        match.SetValues(t);

                        match.TreeDefaultValue_CN = t.TreeDefaultValue_CN;
                        match.Plot_CN = t.Plot_CN;
                        //check sampleGroup, cuttingUnit, stratum because they cant change? yea because they could change st or sg in 100 pct, but not unit
                        match.SampleGroup_CN = t.SampleGroup_CN;
                        match.Stratum_CN = t.Stratum_CN;
                        
                        match.Validate();

                        if (match.HasChanges)
                        {
                            TreesUpdated++;
                            match.Save();
                        }
                        
                    }
                }
                //MasterDB.EndTransaction();
            }
            catch (Exception e)
            {
                //MasterDB.CancelTransaction();
                throw e;
            }
        }

        public void MergeStem(DAL compDB)
        {

            List<StemDO> compStems = compDB.Read<StemDO>("Stem", null);

            foreach (StemDO s in compStems)
            {
                StemDO match = MasterDB.ReadSingleRow<StemDO>("Stem", s.rowID);
                if (match == null)
                {
                    match = new StemDO(MasterDB);
                    match.Tree_CN = s.Tree_CN;
                    match.SetValues(s);
                    MasterDB.Save(match, true, OnConflictOption.Fail);
                    StemsAdded++;
                }
                else
                {
                    
                    match.SetValues(s);
                    if (match.HasChanges)
                    {
                        StemsUpdated++;
                    }
                    match.Save();
                        
                    
                }
            }
        }





        #region IPresentor Members

        public IWindowPresenter Controller
        {
            get;
            set; 
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (this.Components != null)
            {
                foreach (ComponentFileVM comp in this.Components)
                {
                    if (comp.Database != null)
                    {
                        comp.Database.Dispose();
                        comp.Database = null;
                    }
                }
            }
        }

        #endregion

        #region ISaveHandler Members

        public void HandleSave()
        {
            //nothing to save
        }

        public void HandleAppClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //do nothing
        }

        public bool CanHandleSave
        {
            get
            {
                return false;
            }
        }


        #endregion

        #region IPresentor Members


        public void UpdateView()
        {
            //do nothing
        }

        #endregion
    }
}
