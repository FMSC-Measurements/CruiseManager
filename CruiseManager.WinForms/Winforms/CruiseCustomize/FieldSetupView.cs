using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class FieldSetupView : CruiseManager.WinForms.UserControlView, IFieldSetupView
    {
        public FieldSetupView()
        {
            InitializeComponent();
        }

        public new FieldSetupPresenter ViewPresenter
        {
            get { return (FieldSetupPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public void UpdateFieldSetupViews()
        {
            throw new NotImplementedException();
        }
    }
}
