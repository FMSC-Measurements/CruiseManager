using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;

namespace CSM
{
    class EditorPresenter : IPresenter 
    {
        #region Propertys 
        public WindowPresenter WindowPresenter { get; protected set; }
        public SaleDO Sale { get; protected set; }
        public List<CuttingUnitDO> CuttingUnits { get; protected set; }
        public List<StratumDO> Strata { get; protected set; }
        public List<SampleGroupDO> SampleGroups { get; protected set; }
        public List<TreeDefaultValueDO> TreeDefaults { get; protected set; }

        #region forwarding propertys 
        public bool InSupervisorMode
        {
            get
            {
                return WindowPresenter.InSupvisorMode;
            }
        }

        public DAL DAL
        {
            get
            {
                return WindowPresenter.DAL;
            }
        }
        #endregion 

        #endregion

        public EditorPresenter(WindowPresenter windowPresenter)
        {
            this.WindowPresenter = windowPresenter; 
        }

        private void LoadCruiseData()
        {

        }

        public void RecursiveDeleteStratum(StratumDO stratum)
        {

        }

        public void RecursiveDeleteCuttingUnit(CuttingUnitDO cuttingunit)
        {

        }

        public void AddCuttingUnit(CuttingUnitDO cuttingUnit)
        {

        }

        public void AddSampleGroup(SampleGroupDO sampleGroup)
        {

        }

        public void AddStratum(StratumDO stratum)
        {

        }

        public void AddTreeDefault(TreeDefaultValueDO treeDV)
        {

        }

        private void GenerateBackupOfUnit(CuttingUnitDO unit)
        {

        }

        private void GenerateBackupOfStratum(StratumDO stratum)
        {

        }
        //requires supervisor mode
        public void moveTree(TreeDO tree, StratumDO stratum, CuttingUnitDO unit, PlotDO plot)
        {
            if (tree == null) { throw new ArgumentNullException("Tree"); }
            //if (InSupervisorMode == false) { throw new InvalidOperationException("Action requires suppervisor mode"); }

            if (stratum != null && stratum.DAL != null) { tree.Stratum = stratum; }
            if (unit != null && unit.DAL != null) { tree.CuttingUnit = unit; }
            if (plot != null && plot.DAL != null) { tree.Plot = plot; }

            //note: a cutting unit mod requres the cutting unit of the plot to be mod
            //but if the plot is being mod then the cutting unit of the new plot needs to be mod
            //too. as well a cutting unit mod requires the cutting units of the owned stratum 
            //to be mod, unles the owned stratum is being mod too. in that case the 
            //mod stratum needs to be checked for the proper unit. 

            //a mod of the stratum needs to check that the new stratum contain the same plot 
            //owned by the tree, as well as, the same cutting unit, 

            //

        }

        //public void moveUnits(...)
        //{
        ////we moving units to different sales 
        ////so we need to open a seperate cruise files and move that data
        //}






        #region IPresenter Members

        public EditorView View
        {
            get;
            set;
        }

        IView IPresenter.View
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
