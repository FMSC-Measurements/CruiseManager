using CruiseDAL.DataObjects;
using CruiseManager.Core.SetupModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using CruiseManager.Data;
using CruiseManager.Services;
using CruiseDAL;
using CruiseManager.Navigation;
using CruiseManager.Core.ViewModel;
using System.Linq;

namespace CruiseManager.WinForms.CruiseWizard
{
    [DialogName("EditTreeDefault")]
    public partial class FormAddTreeDefault : Form, IDialog
    {
        public DAL Database { get; }
        private bool _isNewTreeDefault;
        public CruiseManagerNavigationParamiters NavigationParamiters { get; set; }

        public TreeDefaultValueDO TreeDefault
        {
            get { return this._BS_TDV.DataSource as TreeDefaultValueDO; }
            set
            {
                this._BS_TDV.DataSource = value;
            }
        }

        public FormAddTreeDefault(ISetupService setupService, IDatabaseProvider databaseProvider)
        {
            InitializeComponent();

            Database = databaseProvider.Database;
            this._PProdCB.DataSource = setupService.GetProductCodes();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var species = NavigationParamiters?.Species;
            var liveDead = NavigationParamiters?.LiveDead;
            var primaryProd = NavigationParamiters?.PrimaryProduct;

            var tdv = Database.From<TreeDefaultValueDO>()
                .Where("Species = @p1 AND LiveDead = @p2 AND PrimaryProduct = @p3")
                .Query(species, liveDead, primaryProd).FirstOrDefault();

            if(tdv == null)
            {
                tdv = new TreeDefaultValueDO();
                _isNewTreeDefault = true;
            }
            else
            { _isNewTreeDefault = false; }

            TreeDefault = tdv;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (DialogResult == DialogResult.OK)
            {
                this._BS_TDV.EndEdit();
                if (!TreeDefault.Validate() == true)
                {
                    MessageBox.Show(this.TreeDefault.Error);
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        if (_isNewTreeDefault)
                        {
                            Database.Insert(TreeDefault);
                        }
                        else
                        {
                            Database.Update(TreeDefault);
                        }
                    }
                    catch (FMSC.ORM.UniqueConstraintException ex)
                    {
                        MessageBox.Show("Values Conflict With Existing Tree Default");
                    }
                    catch (FMSC.ORM.ConstraintException ex)
                    {
                        MessageBox.Show("Invalid Values");
                    }
                }
            }
        }

        void IDialog.SetNavParams(NavigationParamiters_Base navParams)
        {
            NavigationParamiters = (CruiseManagerNavigationParamiters)navParams;
        }
    }
}