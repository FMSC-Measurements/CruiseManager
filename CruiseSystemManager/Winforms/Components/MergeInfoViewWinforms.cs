using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.Components;
using CruiseManager.Core;
using CruiseManager.Core.ViewInterfaces;

namespace CruiseManager.Winforms.Components
{
    public partial class MergeInfoViewWinforms : IView<UserControl>
    {
        public MergeInfoViewWinforms(MergeComponentsPresenter viewPresenter)
        {
            this.ViewPresenter = viewPresenter;
            InitializeComponent();
        }

        protected new MergeComponentsPresenter ViewPresenter
        {
            get { return base.ViewPresenter as MergeComponentsPresenter; }
            set { base.ViewPresenter = value; }
        }


        public void UpdateMasterInfo()
        {
            __numComLBL.Text = ViewPresenter.NumComponents.ToString();
            __dateLastMergeLBL.Text = ViewPresenter.LastMergeDate;
            __totalTreeRecLBL.Text = ViewPresenter.MasterTreeCount.ToString();
        }

        public void UpdateComponentInfo()
        {
            this._BS_ComponentFiles.DataSource = ViewPresenter.AllComponents;
        }

        private void __searchBTN_Click(object sender, EventArgs e)
        {
            this.ViewPresenter.FindComponents(); 
        }

    }
}
