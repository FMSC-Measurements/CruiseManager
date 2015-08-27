using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;

namespace CSM.UI.CombineCruise
{
    public partial class ComponentSelectPage : UserControl
    {
        CombineCruisePresenter Presenter { get; set; }
        //MergeCruiseView MasterView { get; set; }
        private CruiseDAL.DataObject Selection;

        public string CuttingUnitDisplayFormat { get; set; }
        public string StratumDisplayFormat { get; set; }

        public ComponentSelectPage(CombineCruisePresenter Presenter)
        {
            this.Presenter = Presenter;
            //this.MasterView = MasterView;

            
            
            InitializeComponent();


        }


        protected bool IsSelectionUnitFirst
        {
            get
            {
                return true; //TODO implement logic
            }
        }



        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Selection is CuttingUnitDO)
            {
                var dup = Presenter.CheckDuplicateCuttingUnit(Selection as CuttingUnitDO);
                if (dup != null)
                {
                    MessageBox.Show("Cutting Unit " + (Selection as CuttingUnitDO).Code + "Already Exists");
                    return;
                }
            }
            else
            {
                var dup = Presenter.CheckDuplicateStratum(Selection as StratumDO);
                if (dup != null)
                {
                    MessageBox.Show("Stratum " + (Selection as StratumDO).Code + "Already Exists");
                    return;
                }
            }

            //Presenter.FirstSelection = Selection;
            //Presenter.GoToSubComponentPage();
        }

        private void __UnitFirstRB_CheckedChanged(object sender, EventArgs e)
        {
            BuildComponentTree();
        }

        private void __stratumFirstRB_CheckedChanged(object sender, EventArgs e)
        {
            BuildComponentTree();
        }

        private void __processBTN_Click(object sender, EventArgs e)
        {
            if (IsSelectionUnitFirst)
            {
                this.ProcessUnitFirstSelection();
            }
            else
            {
                this.ProcessStratumFirstSelection();
            }
        }

        public bool HandleStratumConflict(StratumDO stratum)
        {
            MessageBox.Show("Stratum " + stratum.Code + "Already Exists");
            return false;
        }

        public bool HandleUnitConflict(CuttingUnitDO unit)
        {
            MessageBox.Show("Cutting Unit " + unit.Code + "Already Exists");
            return false;
        }

        protected void BuildComponentTree()
        {
            if (IsSelectionUnitFirst)
            {
                BuildComponentTreeUnitFirst();
            }
            else
            {
                BuildComponentTreeStratumFirst();
            }
        }


        private void BuildComponentTreeUnitFirst()
        {
            __ComponentTree.Nodes.Clear();

            foreach (CuttingUnitDO unit in Presenter.AllCuttingUnits)
            {
                TreeNode parentNode = new TreeNode(unit.ToString(this.CuttingUnitDisplayFormat, null));
                parentNode.Tag = unit;

                foreach (StratumDO st in unit.Strata)
                {
                    TreeNode childNode = new TreeNode(st.ToString(this.StratumDisplayFormat, null));
                    childNode.Tag = st;
                    parentNode.Nodes.Add(childNode);
                }

                __ComponentTree.Nodes.Add(parentNode);
            }
        }

        private void BuildComponentTreeStratumFirst()
        {
            __ComponentTree.Nodes.Clear();

            foreach (StratumDO st in Presenter.AllStrata)
            {
                TreeNode parentNode = new TreeNode(st.ToString(this.StratumDisplayFormat, null));
                parentNode.Tag = st;

                foreach (CuttingUnitDO unit in st.CuttingUnits)
                {
                    TreeNode childNode = new TreeNode(unit.ToString(this.CuttingUnitDisplayFormat, null));
                    childNode.Tag = unit;
                    parentNode.Nodes.Add(childNode);
                }
                __ComponentTree.Nodes.Add(parentNode);
            }

        }

        private void ProcessUnitFirstSelection()
        {
            foreach (TreeNode parentNode in __ComponentTree.Nodes)
            {
                if (parentNode.Checked == true)
                {
                    CuttingUnitDO unit = parentNode.Tag as CuttingUnitDO;
                    List<StratumDO> strataSelection = new List<StratumDO>();
                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        if (childNode.Checked == true)
                        {
                            StratumDO st = childNode.Tag as StratumDO;
                            strataSelection.Add(st);
                        }
                    }

                    Presenter.CombineUnit(unit, strataSelection);
                }
            }
        }

        private void ProcessStratumFirstSelection()
        {
            foreach (TreeNode parentNode in __ComponentTree.Nodes)
            {
                if (parentNode.Checked == true)
                {
                    StratumDO st = parentNode.Tag as StratumDO;
                    List<CuttingUnitDO> unitSelection = new List<CuttingUnitDO>();

                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        if (childNode.Checked == true)
                        {
                            CuttingUnitDO unit = childNode.Tag as CuttingUnitDO;
                            unitSelection.Add(unit);
                        }
                    }

                    Presenter.CombineStratum(st, unitSelection);
                }

            }

        }
      


    }
}
