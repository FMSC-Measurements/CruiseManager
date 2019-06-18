﻿using CruiseManager.Core.Components;
using CruiseManager.Core.Components.ViewInterfaces;
using System;

namespace CruiseManager.WinForms.Components
{
    public partial class CreateComponentView : UserControlView, ICreateComponentView
    {
        public CreateComponentView(CreateComponentPresenter viewPresenter)
        {
            InitializeComponent();
            __progressBar.Maximum = 100;
            this.@__numCompTB.Maximum = (decimal)Core.Components.CreateComponentPresenter.MAX_COMPONENTS;

            viewPresenter.ProgressChanged += ViewPresenter_ProgressChanged;

            this.ViewPresenter = viewPresenter;
            this.ViewPresenter.View = this;
        }

        private void ViewPresenter_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var percentDone = e.ProgressPercentage;
            bool done = (e.UserState as bool?) ?? false;

            __progressBar.Value = percentDone;
            __progressBar.Visible = !done;
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

        public void EndEdits()
        {
            //nothing to do
        }
    }
}