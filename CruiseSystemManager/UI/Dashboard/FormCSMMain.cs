using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSM.Logic;

namespace CSM.UI.Dashboard
{
    public partial class FormCSMMain : Form
    {
        public FormCSMMain(IWindowPresenter presenter)
        {
            this.Presenter = presenter;
            InitializeComponent();

            this.FormClosing +=new FormClosingEventHandler(this.Presenter.HandleAppClosing);
            this.openToolStripMenuItem.Click += new EventHandler(this.Presenter.HandleOpenFileClick);
            this.newToolStripMenuItem.Click +=new EventHandler(this.Presenter.HandleNewCruiseClick);
            this.saveToolStripMenuItem.Click += new EventHandler(this.Presenter.HandleSaveClick);
            this.aboutToolStripMenuItem.Click += new EventHandler(this.Presenter.HandleAboutClick);
            this.saveAsToolStripMenuItem.Click += new EventHandler(this.Presenter.HandleSaveAsClick);
        }

        public IWindowPresenter Presenter { get; set; }
        public Panel ViewContentPanel { get { return this._viewContentPanel; } }
        public Panel ViewNavPanel { get { return this._viewNavPanel; } }

        public void AddNavButton(String text, EventHandler eventHandler)
        {

            Button newNavButton = new Button();
            newNavButton.AutoSize = true;
            newNavButton.BackColor = System.Drawing.Color.Green;
            newNavButton.Dock = System.Windows.Forms.DockStyle.Top;
            newNavButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            newNavButton.FlatAppearance.BorderSize = 2;
            newNavButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            //newNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            newNavButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newNavButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            newNavButton.Location = new System.Drawing.Point(0, 0);
            newNavButton.Size = new System.Drawing.Size(200, 35);
            newNavButton.Text = text;
            newNavButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            newNavButton.UseVisualStyleBackColor = false;
            newNavButton.Click += eventHandler;

            newNavButton.Parent = this._viewNavPanel;
        }

        public void ClearNavPanel()
        {
            this.ViewNavPanel.Controls.Clear();
        }

        public bool EnableSave
        {
            get
            {
                return this.saveToolStripMenuItem.Enabled;
            }
            set
            {
                this.saveToolStripMenuItem.Enabled = value;
            }
        }

        public bool EnableSaveAs
        {
            get
            {
                return this.saveAsToolStripMenuItem.Enabled;
            }
            set
            {
                this.saveAsToolStripMenuItem.Enabled = value;
            }
        }



    }
}