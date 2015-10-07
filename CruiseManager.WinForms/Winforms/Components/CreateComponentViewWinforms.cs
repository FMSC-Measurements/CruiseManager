using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.Components;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core;
using CruiseManager.WinForms;

namespace CruiseManager.WinForms.Components
{
    public partial class CreateComponentViewWinforms : UserControlView, CreateComponentView
    {
        public CreateComponentViewWinforms(CreateComponentPresenter viewPresenter)
        {
            InitializeComponent();

            this.ViewPresenter = viewPresenter;
            this.ViewPresenter.View = this;
        }

        public new CreateComponentPresenter ViewPresenter 
        {
            get { return (CreateComponentPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            System.Diagnostics.Debug.Assert(ViewPresenter != null);
            this.__numCompTB.Value = (Decimal)ViewPresenter.NumComponents;
        }



        private void __makeBtn_Click(object sender, EventArgs e)
        {
            ViewPresenter.MakeComponents((int)this.__numCompTB.Value);
            this.ShowMessage("Done");
            //MessageBox.Show("Done");
        }

        public void InitializeAndShowProgress(int numSteps)
        {
            this.__progressBar.Maximum = numSteps;
            this.__progressBar.Step = 1;
            this.__progressBar.Value = 0;
            this.__progressBar.Visible = true;
        }

        public void HideProgressBar()
        {
            this.__progressBar.Visible = false;
        }

        public void StepProgressBar()
        {
            this.__progressBar.PerformStep();
        }


        public void EndEdits()
        {
            //nothing to do
        }
    }
}
