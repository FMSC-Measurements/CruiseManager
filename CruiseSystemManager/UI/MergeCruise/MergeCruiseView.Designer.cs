namespace CSM.UI.CombineCruise
{
    partial class MergeCruiseView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeCruiseView));
           this.pageHost1 = new CSM.UI.PageHost();
           this.SuspendLayout();
           // 
           // pageHost1
           // 
           this.pageHost1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.pageHost1.Location = new System.Drawing.Point(0, 0);
           this.pageHost1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.pageHost1.Name = "pageHost1";
           this.pageHost1.Size = new System.Drawing.Size(660, 448);
           this.pageHost1.TabIndex = 0;
           // 
           // MergeCruiseView
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(660, 448);
           this.Controls.Add(this.pageHost1);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.Name = "MergeCruiseView";
           this.Text = "MergeCruiseView";
           this.ResumeLayout(false);

        }

        #endregion

        private PageHost pageHost1;



    }
}