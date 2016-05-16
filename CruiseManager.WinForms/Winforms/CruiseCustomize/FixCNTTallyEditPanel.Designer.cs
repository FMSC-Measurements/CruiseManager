namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class FixCNTTallyEditPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel _upperPannel;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.Windows.Forms.Label _tallyField_LBL;
            System.Windows.Forms.Label _title_LBL;
            this._tallyField_CmbB = new System.Windows.Forms.ComboBox();
            this._BS_TallyClass = new System.Windows.Forms.BindingSource(this.components);
            this._lowerPanel = new System.Windows.Forms.FlowLayoutPanel();
            _upperPannel = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            _tallyField_LBL = new System.Windows.Forms.Label();
            _title_LBL = new System.Windows.Forms.Label();
            _upperPannel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TallyClass)).BeginInit();
            this.SuspendLayout();
            // 
            // _upperPannel
            // 
            _upperPannel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _upperPannel.Controls.Add(flowLayoutPanel1);
            _upperPannel.Controls.Add(_title_LBL);
            _upperPannel.Dock = System.Windows.Forms.DockStyle.Top;
            _upperPannel.Location = new System.Drawing.Point(0, 0);
            _upperPannel.Name = "_upperPannel";
            _upperPannel.Size = new System.Drawing.Size(313, 71);
            _upperPannel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(_tallyField_LBL);
            flowLayoutPanel1.Controls.Add(this._tallyField_CmbB);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(313, 27);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // _tallyField_LBL
            // 
            _tallyField_LBL.AutoSize = true;
            _tallyField_LBL.Dock = System.Windows.Forms.DockStyle.Left;
            _tallyField_LBL.Location = new System.Drawing.Point(3, 0);
            _tallyField_LBL.Name = "_tallyField_LBL";
            _tallyField_LBL.Size = new System.Drawing.Size(54, 27);
            _tallyField_LBL.TabIndex = 1;
            _tallyField_LBL.Text = "Tally Field";
            _tallyField_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _tallyField_CmbB
            // 
            this._tallyField_CmbB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this._BS_TallyClass, "Field", true));
            this._tallyField_CmbB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._tallyField_CmbB.FormattingEnabled = true;
            this._tallyField_CmbB.Location = new System.Drawing.Point(63, 3);
            this._tallyField_CmbB.Name = "_tallyField_CmbB";
            this._tallyField_CmbB.Size = new System.Drawing.Size(121, 21);
            this._tallyField_CmbB.TabIndex = 2;
            // 
            // _BS_TallyClass
            // 
            this._BS_TallyClass.DataSource = typeof(CruiseManager.Core.CruiseCustomize.FixCNTTallyClass);
            // 
            // _title_LBL
            // 
            _title_LBL.AutoSize = true;
            _title_LBL.Dock = System.Windows.Forms.DockStyle.Top;
            _title_LBL.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _title_LBL.Location = new System.Drawing.Point(0, 0);
            _title_LBL.Name = "_title_LBL";
            _title_LBL.Size = new System.Drawing.Size(168, 25);
            _title_LBL.TabIndex = 0;
            _title_LBL.Text = "FixCNT Tally Setup";
            // 
            // _lowerPanel
            // 
            this._lowerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._lowerPanel.Location = new System.Drawing.Point(0, 71);
            this._lowerPanel.Name = "_lowerPanel";
            this._lowerPanel.Size = new System.Drawing.Size(313, 216);
            this._lowerPanel.TabIndex = 1;
            // 
            // FixCNTTallyEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._lowerPanel);
            this.Controls.Add(_upperPannel);
            this.Name = "FixCNTTallyEditPanel";
            this.Size = new System.Drawing.Size(313, 287);
            _upperPannel.ResumeLayout(false);
            _upperPannel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TallyClass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox _tallyField_CmbB;
        private System.Windows.Forms.BindingSource _BS_TallyClass;
        private System.Windows.Forms.FlowLayoutPanel _lowerPanel;
    }
}
