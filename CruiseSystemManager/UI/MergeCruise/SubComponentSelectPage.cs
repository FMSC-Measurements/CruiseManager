using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM.UI.CombineCruise
{
    public partial class SubComponentSelectPage : UserControl
    {
        MergeCruiseView MasterView { get; set; }
        public CombineCruisePresenter Presenter { get; set; }

        public SubComponentSelectPage(MergeCruiseView MasterView, CombineCruisePresenter presenter)
        {
            this.MasterView = MasterView;
            Presenter = presenter;
            
            InitializeComponent();
            SubComponentGridView.AutoGenerateColumns = false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Presenter.Finish();
            Presenter.View.DialogResult = DialogResult.OK;
            Presenter.View.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Presenter.View.GoToComponentPage();
        }
    }
}
