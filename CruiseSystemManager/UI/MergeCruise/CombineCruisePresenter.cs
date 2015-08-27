using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using System.Collections;
using CruiseDAL;
using CSM.Logic;

namespace CSM.UI.CombineCruise
{
    public class CombineCruisePresenter : IPresentor
    {
        public IWindowPresenter Controller { get; set; }

        //public MergeCruiseView View { get; set; }

        //this view displayes a selection of cutting units and strata for the user to select from 
        //public ComponentSelectPage ComponentSelectPage { get { return View.ComponentSelectPage; } }

        //this view displayes a selection of cutting units or strata that the user can select from 
        //public SubComponentSelectPage SubComponentSelectPage { get { return View.SubComponentSelectPage; } }


        public DAL DAL { get { return Controller.Database; } }

        public DAL FromDAL { get; set; }

        public CombineCruisePresenter(IWindowPresenter WindowPresenter, DAL fromDAL)
        {
            this.Controller = WindowPresenter;
            FromDAL = fromDAL;
            AllCuttingUnits = FromDAL.Read<CuttingUnitDO>("CuttingUnit", null, null);
            AllStrata = FromDAL.Read<StratumDO>("Stratum", null, null);
            //FirstSelection = null;
            //SelectedSubSelection = new List<DataObject>();
            //SubSelectionStrata = new List<StratumDO>();
            //SubSelectionCuttingUnits = new List<CuttingUnitDO>();
            //SelectedSubSelectionCuttingUnits = new List<CuttingUnitDO>();
            //SelectedSubSelectionStrata = new List<StratumDO>();
            //this.View = View;
        }

        public List<CuttingUnitDO> AllCuttingUnits { get; set; }

        public List<StratumDO> AllStrata { get; set; }

        /// <summary>
        /////////////////////////////////////////////////////////////////////////
        /// </summary>
        //private DataObject _firstSelection; 
        //public DataObject FirstSelection
        //{
        //    get
        //    {
        //        return _firstSelection;
        //    }
        //    set
        //    {
        //        _firstSelection = value;
        //        if (_firstSelection == null) { return; }
        //        if (IsSelectionCuttingUnit)
        //        {
        //            var unit = FirstSelection as CuttingUnitDO;
        //            if (unit.Strata.IsPopulated == false) { unit.Strata.Populate(); }
        //            AvalableSubSelection = unit.Strata;
        //        }
        //        else
        //        {
        //            var stratum = FirstSelection as StratumDO;
        //            if (stratum.CuttingUnits.IsPopulated == false) { stratum.CuttingUnits.Populate(); }
        //            AvalableSubSelection = stratum.CuttingUnits;
        //        }
        //    }
        //}

        //public IList AvalableSubSelection { get; set; }

        //public List<DataObject> SelectedSubSelection { get; set; }



        //public bool IsSelectionCuttingUnit
        //{
        //    get { return FirstSelection is CuttingUnitDO; }
        //}



        //public void GoToSubComponentPage()
        //{
        //    if (this.IsSelectionCuttingUnit)
        //    {
        //        var codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Code",
        //            HeaderText = "Code",
        //            Name = "codeDataGridViewTextBoxColumn",
        //            ReadOnly = true
        //        };

        //        var descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Description",
        //            ReadOnly = true,
        //            Name = "descriptionDataGridViewTextBoxColumn",
        //            HeaderText = "Description"
        //        };

        //        var methodDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Method",
        //            ReadOnly = true,
        //            Name = "methodDataGridViewTextBoxColumn",
        //            HeaderText = "Method"
        //        };

        //        var basalAreaFactorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "BasalArea",
        //            HeaderText = "Basal Area",
        //            Name = "basalAreaFactorDataGridViewTextBoxColumn",
        //            ReadOnly = true
        //        };

        //        var fixedPlotSizeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "FixedPlotSize",
        //            ReadOnly = true,
        //            Name = "fixedPlotSizeDataGridViewTextBoxColumn",
        //            HeaderText = "Fixed Plot Size"
        //        };

        //        var monthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Month",
        //            HeaderText = "Month",
        //            Name = "monthDataGridViewTextBoxColumn",
        //            ReadOnly = true
        //        };

        //        var yearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Year",
        //            ReadOnly = true,
        //            Name = "yearDataGridViewTextBoxColumn",
        //            HeaderText = "Year"
        //        };


        //        SubComponentSelectPage.SubComponentGridView.Columns.Clear();
        //        SubComponentSelectPage.SubComponentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        //            codeDataGridViewTextBoxColumn,
        //            descriptionDataGridViewTextBoxColumn,
        //            methodDataGridViewTextBoxColumn,
        //            basalAreaFactorDataGridViewTextBoxColumn,
        //            fixedPlotSizeDataGridViewTextBoxColumn,
        //            monthDataGridViewTextBoxColumn,
        //            yearDataGridViewTextBoxColumn});

        //        //SubComponentSelectPage.SubComponentGridView.DataSource = Presenter.SubSelectionStrata;
        //        //SubComponentSelectPage.SubComponentGridView.SelectedItems = Presenter.SelectedSubSelectionStrata;
        //        SubComponentSelectPage.SubSelectionTypeLabel.Text = "Strata";


        //    }
        //    else
        //    {
        //        var codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Code",
        //            HeaderText = "Code",
        //            Name = "codeDataGridViewTextBoxColumn",
        //            ReadOnly = true
        //        };

        //        var areaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Area",
        //            HeaderText = "Area",
        //            Name = "areaDataGridViewTextBoxColumn",
        //            ReadOnly = true
        //        };

        //        var descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "Description",
        //            ReadOnly = true,
        //            Name = "descriptionDataGridViewTextBoxColumn",
        //            HeaderText = "Description"
        //        };

        //        var loggingMethodDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "LoggingMethod",
        //            HeaderText = "Logging Method",
        //            Name = "loggingMethodDataGridViewTextBoxColumn",
        //            ReadOnly = true
        //        };

        //        var paymentUnitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
        //        {
        //            DataPropertyName = "PaymentUnit",
        //            ReadOnly = true,
        //            Name = "paymentUnitDataGridViewTextBoxColumn",
        //            HeaderText = "Payment Unit"
        //        };


        //        SubComponentSelectPage.SubComponentGridView.Columns.Clear();
        //        SubComponentSelectPage.SubComponentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        //            codeDataGridViewTextBoxColumn,
        //            areaDataGridViewTextBoxColumn,
        //            descriptionDataGridViewTextBoxColumn,
        //            loggingMethodDataGridViewTextBoxColumn,
        //            paymentUnitDataGridViewTextBoxColumn});

        //        //SubComponentSelectPage.SubComponentGridView.DataSource = Presenter.SubSelectionCuttingUnits;
        //        //SubComponentSelectPage.SubComponentGridView.SelectedItems = Presenter.SelectedSubSelectionCuttingUnits;
        //        SubComponentSelectPage.SubSelectionTypeLabel.Text = "Cutting Units";
        //    }

        //    SubComponentSelectPage.SubComponentGridView.DataSource = Presenter.AvalableSubSelection;
        //    SubComponentSelectPage.SubComponentGridView.SelectedItems = Presenter.SelectedSubSelection;
        //    pageHost1.Display(SubComponentSelectPage);
        //}


        //public void GoToComponentPage()
        //{
        //    //pageHost1.Display(ComponentSelectPage);
        //}

        public void Finish()
        {
            //foreach(DataObject obj in SelectedSubSelection)
            //{
            //    if(IsSelectionCuttingUnit)
            //    {
            //        var unit = FirstSelection as CuttingUnitDO; 
            //        var stratum = obj as StratumDO;
            //        CopyCuttingUnitStratum(unit, stratum);
            //    }
            //    else 
            //    {
            //        var stratum = FirstSelection as StratumDO; 
            //        var unit = obj as CuttingUnitDO; 
            //        CopyCuttingUnitStratum(unit, stratum);
            //    }

            //}
            //if (isComponentCuttingUnit)
            //{
            //    foreach (DataObject (stratum as StratumDO) in SelectedSubSelection)
            //    {
            //        CopyCuttingUnitStratum(SelectedCuttingUnit, stratum);
            //    }
            //}
            //else
            //{
            //    foreach (CuttingUnitDO unit in SelectedSubSelectionCuttingUnits)
            //    {
            //        CopyCuttingUnitStratum(unit, SelectedStratum);
            //    }
            //}
        }


        Dictionary<PlotDO, PlotDO> PlotLookup = new Dictionary<PlotDO, PlotDO>();
        private PlotDO CopyPlot(PlotDO plot, CuttingUnitDO unit, StratumDO stratum)
        {
            //see if I have already copyed this plot
            if (!PlotLookup.ContainsKey(plot))
            {
                //see if there is a duplicate plot in the db
                PlotDO dup = CheckDuplicatePlot(plot, unit, stratum);
                //if there is NOT a duplicate
                if (dup == null)
                {
                    //create a copy of the plot, to put into the dest db
                    PlotDO newPlot = new PlotDO(plot) { DAL = DAL, CuttingUnit = unit, Stratum = stratum };
                    //add the plot to the look up 
                    PlotLookup.Add(plot, newPlot);
                    //save
                    newPlot.Save();
                    //return the plot that was copyed
                    return newPlot;
                }
                else
                {
                    //add the duplicate to the lookup
                    PlotLookup.Add(plot, dup);
                    //return the duplicate 
                    return dup;
                }
            }
            else
            {
                return PlotLookup[plot];
            }
        }

        private PlotDO CheckDuplicatePlot(PlotDO plot1, CuttingUnitDO unit, StratumDO stratum)
        {
            return DAL.ReadSingleRow<PlotDO>("Plot", "WHERE PlotNumber = ? AND CuttingUnit_CN AND Stratum_CN = ?",
                plot1.PlotNumber.ToString(),
                unit.CuttingUnit_CN.ToString(),
                stratum.Stratum_CN.ToString());
        }

        Dictionary<TreeDefaultValueDO, TreeDefaultValueDO> TreeDefaultLookup = new Dictionary<TreeDefaultValueDO, TreeDefaultValueDO>();
        private TreeDefaultValueDO CopyTreeDefault(TreeDefaultValueDO treeDefault)
        {
            if (!TreeDefaultLookup.ContainsKey(treeDefault))
            {
                TreeDefaultValueDO dup = CheckDuplicateTDV(treeDefault);
                if (dup == null)
                {
                    TreeDefaultValueDO newTDV = new TreeDefaultValueDO(treeDefault) { DAL = DAL };
                    TreeDefaultLookup.Add(treeDefault, newTDV);
                    newTDV.Save();
                    return newTDV;
                }
                else
                {
                    TreeDefaultLookup.Add(treeDefault, dup);
                    return dup;
                }
            }
            else
            {
                return TreeDefaultLookup[treeDefault];
            }
        }

        private TreeDefaultValueDO CheckDuplicateTDV(TreeDefaultValueDO treeDefault)
        {
            return DAL.ReadSingleRow<TreeDefaultValueDO>("TreeDefaultValue",
                "WHERE PrimaryProduct = ? AND Species = ? AND LiveDead = ?",
                treeDefault.PrimaryProduct,
                treeDefault.Species,
                treeDefault.LiveDead);
        }

        Dictionary<SampleGroupDO, SampleGroupDO> SampleGroupLookup = new Dictionary<SampleGroupDO, SampleGroupDO>();
        private SampleGroupDO CopySampleGroup(SampleGroupDO sampleGroup, StratumDO stratum)
        {
            if (!SampleGroupLookup.ContainsKey(sampleGroup))
            {
                SampleGroupDO dup = CheckDuplicateSampleGroup(sampleGroup, stratum);
                if (dup == null)
                {
                    SampleGroupDO newSG = new SampleGroupDO(sampleGroup) { DAL = DAL, Stratum = stratum };
                    SampleGroupLookup.Add(sampleGroup, newSG);
                    newSG.Save();
                    return newSG;
                }
                else
                {
                    SampleGroupLookup.Add(sampleGroup, dup);
                    return dup;
                }
            }
            else
            {
                return SampleGroupLookup[sampleGroup];
            }
        }

        private SampleGroupDO CheckDuplicateSampleGroup(SampleGroupDO sampleGroup, StratumDO stratum)
        {
            return DAL.ReadSingleRow<SampleGroupDO>("SampleGroup",
                "WHERE Stratum_CN AND Code = ?",
                stratum.Stratum_CN.ToString(),
                sampleGroup.Code);
        }

        //samplegroup TreeDefault set uses a custom comarer
        HashSet<SampleGroupTreeDefaultValueDO> SampleGroupTreeDefaultSet = 
            new HashSet<SampleGroupTreeDefaultValueDO>(new SampleGroupTreeDefaultComparer());
        private void CopySampleGroupTreeDefault(SampleGroupDO sampleGroup, TreeDefaultValueDO treeDefault)
        {
            SampleGroupTreeDefaultValueDO sgtdv = new SampleGroupTreeDefaultValueDO
            { 
                SampleGroup_CN = sampleGroup.SampleGroup_CN, 
                TreeDefaultValue_CN = treeDefault.TreeDefaultValue_CN 
            };
            if (!SampleGroupTreeDefaultSet.Contains(sgtdv))
            {
                SampleGroupTreeDefaultSet.Add(sgtdv);
                sgtdv.DAL = DAL;
                sgtdv.Save();
            }
        }

        private Dictionary<CuttingUnitDO, CuttingUnitDO> CuttingUnitLookup = new Dictionary<CuttingUnitDO, CuttingUnitDO>();
        private CuttingUnitDO CopyCuttingUnit(CuttingUnitDO unit)
        {
            if (!CuttingUnitLookup.ContainsKey(unit))
            {
                CuttingUnitDO dup = CheckDuplicateCuttingUnit(unit);
                if (dup == null)
                {
                    CuttingUnitDO newUnit = new CuttingUnitDO(unit);
                    newUnit.DAL = DAL;
                    newUnit.Save();
                    CuttingUnitLookup.Add(unit, newUnit);
                    return newUnit;
                }
                else
                {
                    CuttingUnitLookup.Add(unit, dup);
                    return dup;
                }
            }
            else
            {
                return CuttingUnitLookup[unit];
            }
        }

        public CuttingUnitDO CheckDuplicateCuttingUnit(CuttingUnitDO unit)
        {
            return DAL.ReadSingleRow<CuttingUnitDO>("CuttingUnit",
                "WHERE Code = ?", unit.Code);
        }

        private Dictionary<StratumDO, StratumDO> StratumLookup = new Dictionary<StratumDO, StratumDO>();
        private StratumDO CopyStratum(StratumDO stratum)
        {
            if (!StratumLookup.ContainsKey(stratum))
            {
                StratumDO dup = CheckDuplicateStratum(stratum);
                if (dup == null)
                {
                    StratumDO newStratum = new StratumDO(stratum);
                    newStratum.DAL = DAL;
                    newStratum.Save();
                    StratumLookup.Add(stratum, newStratum);
                    return newStratum;
                }
                else
                {
                    StratumLookup.Add(stratum, dup);
                    return dup;
                }
            }
            else
            {
                return StratumLookup[stratum];
            }
        }

        public StratumDO CheckDuplicateStratum(StratumDO stratum)
        {
            return DAL.ReadSingleRow<StratumDO>("Stratum",
                "WHERE Code = ?", stratum.Code);        
        }

        
        private void CopyCuttingUnitStratum(CuttingUnitDO unit, StratumDO stratum)
        {
            //if unit isn't in db copy
            CuttingUnitDO newUnit = CopyCuttingUnit(unit);
            //if stratum isn't in db copy 
            StratumDO newStratum = CopyStratum(stratum);

            
            CuttingUnitStratumDO newCUST = new CuttingUnitStratumDO(DAL) { CuttingUnit = newUnit, Stratum = newStratum };
            newCUST.Save();

            List<TreeDO> Trees = FromDAL.Read<TreeDO>("Tree", "WHERE CuttingUnit_CN = ? AND Stratum_CN = ?",
                unit.CuttingUnit_CN.ToString(),
                stratum.Stratum_CN.ToString());


            //make collections containing all unique plot, TDV and sampleGroups
            HashSet<TreeDefaultValueDO> TDVSet = new HashSet<TreeDefaultValueDO>();
            HashSet<SampleGroupDO> SampleGroupSet = new HashSet<SampleGroupDO>();
            foreach (TreeDO tree in Trees)
            {
                TreeDO newTree = new TreeDO(tree);
                newTree.CuttingUnit = newUnit;
                newTree.Stratum = newStratum;

                newTree.Plot = CopyPlot(tree.Plot, newUnit, newStratum);
                newTree.TreeDefaultValue = CopyTreeDefault(tree.TreeDefaultValue);
                newTree.SampleGroup = CopySampleGroup(tree.SampleGroup, newStratum);
                CopySampleGroupTreeDefault(newTree.SampleGroup, newTree.TreeDefaultValue);
                newTree.DAL = DAL;
                newTree.Save();
            }
        }

        public void CombineStratum(StratumDO st, List<CuttingUnitDO> unitSelection)
        {
            foreach (CuttingUnitDO unit in unitSelection)
            {
                CopyCuttingUnitStratum(unit, st);
            }
        }

        public void CombineUnit(CuttingUnitDO unit, List<StratumDO> strataSelection)
        {
            foreach (StratumDO stratum in strataSelection)
            {
                CopyCuttingUnitStratum(unit, stratum);
            }
        }
             
        private class SampleGroupTreeDefaultComparer : IEqualityComparer<SampleGroupTreeDefaultValueDO>
        {
            #region IEqualityComparer<SampleGroupTreeDefaultValueDO> Members

            public bool Equals(SampleGroupTreeDefaultValueDO x, SampleGroupTreeDefaultValueDO y)
            {
                return x.SampleGroup_CN == y.SampleGroup_CN && x.TreeDefaultValue_CN == y.TreeDefaultValue_CN;
            }

            public int GetHashCode(SampleGroupTreeDefaultValueDO obj)
            {
                return (obj.TreeDefaultValue_CN ^ 2).GetHashCode() + obj.SampleGroup_CN.GetHashCode();
            }
            #endregion
        }




        #region IDisposable Members

        public void Dispose()
        {
            
        }

        #endregion

        #region ISaveHandler Members

        public void HandleSave()
        {
            //do nothing
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
