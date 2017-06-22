using CruiseManager.Core.Components;
using CruiseManager.Core.Components.ViewInterfaces;
using System;

namespace CruiseManager.WinForms.Components
{
    public partial class CreateComponentView : UserControlView, ICreateComponentView
    {
        public CreateComponentView(CreateComponentPresenter viewPresenter)
        {
            InitializeComponent();
            this.@__numCompTB.Maximum = (decimal)Core.Components.CreateComponentPresenter.MAX_COMPONENTS;

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