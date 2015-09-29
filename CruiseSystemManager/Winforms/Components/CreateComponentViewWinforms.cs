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

namespace CruiseManager.WinForms.Components
{
    public partial class CreateComponentViewWinforms : UserControl, CreateComponentView
    {
        protected WindowPresenter _myWindowPresenter;
        //protected ApplicationController _myApplicationController;

        //public CreateComponentView(WindowPresenter windowPresenter, ApplicationController applicationController) : this()
        //{
        //    _myWindowPresenter = windowPresenter;
        //    _myApplicationController = applicationController;
        //}

        public CreateComponentViewWinforms(CreateComponentPresenter viewPresenter)
        {
            InitializeComponent();

            this.ViewPresenter = viewPresenter;
            this.ViewPresenter.View = this;
            this._myWindowPresenter = this.ViewPresenter.WindowPresenter;

            
        }

        public CreateComponentPresenter ViewPresenter 
        {
            get; set;
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
            this._myWindowPresenter.ShowMessage("Done");
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

        #region IView Members
        IPresentor IView.ViewPresenter
        {
            get
            {
                return this.ViewPresenter;
            }
        }

        public IEnumerable<ViewCommand> NavCommands
        {
            get; protected set;
        }

        public IEnumerable<ViewCommand> UserCommands
        {
            get; protected set;
        }
        #endregion
    }
}
