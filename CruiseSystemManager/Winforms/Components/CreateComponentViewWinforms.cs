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

        public CreateComponentViewWinforms(WindowPresenter windowPresenter)
        {
            this._myWindowPresenter = windowPresenter;
            InitializeComponent();
        }

        private CreateComponentPresenter _presenter; 
        public CreateComponentPresenter Presenter 
        {
            get { return _presenter; }
            set
            {
                _presenter = value;
                if (value != null)
                {
                    this.__numCompTB.Value = (Decimal)value.NumComponents;
                }
            }
        }

        private void __makeBtn_Click(object sender, EventArgs e)
        {
            Presenter.MakeComponents((int)this.__numCompTB.Value);
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
    }
}
