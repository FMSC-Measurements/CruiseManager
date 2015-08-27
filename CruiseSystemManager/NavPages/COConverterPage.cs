using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseSystemManager.NavPages
{
    public partial class COConverterPage : UserControl
    {
        public string targetPath { get; set; }
        public string outputPath { get; set; }


        public COConverterPage()
        {
            InitializeComponent();

            //setting textbox bindings 
            TargetPathTextBox.DataBindings.Add("Text", this, "targetPath");
            OutputPathTextBox.DataBindings.Add("Text", this, "outputPath");
        }

        private void TargetPathBrowseButton_Click(object sender, EventArgs e)
        {
            ClearStatus();
            openFileDialog1.Filter = "Cruise Files (*.crz)|*.crz";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                targetPath = openFileDialog1.FileName;
            }
            else
            {
                targetPath = null;
            }
            TargetPathTextBox.Text = targetPath;
        }

        private void OutputPathBrowseButton_Click(object sender, EventArgs e)
        {
            ClearStatus();
            saveFileDialog1.OverwritePrompt = false;//becase we are going to display our own warning
            saveFileDialog1.DefaultExt = "cruise";
            saveFileDialog1.Filter = "Cruise Files (*.cruise)|*.cruise";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(saveFileDialog1.FileName))
                {
                    if (MessageBox.Show("File already exists It will be overwritten.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        outputPath = saveFileDialog1.FileName;
                    }
                }
                else
                {
                    outputPath = saveFileDialog1.FileName;
                }
            }
            else
            {
                outputPath = null;
                
            }
            OutputPathTextBox.Text = outputPath;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if( outputPath == null || targetPath == null)
            {
                return;
            }

            StatusLabel.Text = "Please wait";

            using (COConverter converter = new COConverter())
            {
                var success = converter.Run(targetPath, outputPath);
                if (success)
                {
                    StatusLabel.Text = "Sucess!";
                }
                else
                {
                    StatusLabel.Text = "";
                    var saveLog = MessageBox.Show("Unable to convert file, would you like to save the log file", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (saveLog == DialogResult.Yes)
                    {
                        saveFileDialog2.DefaultExt = "txt";
                        saveFileDialog2.Filter = "Text file (*.txt)|*.txt";
                        saveFileDialog2.FilterIndex = 0;
                        if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                        {
                            converter.Dumplog(saveFileDialog2.FileName);
                        }
                    }
                }
            }
        }

        private void ClearStatus()
        {
            StatusLabel.Text = "";
        }

        private void TargetPathTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearStatus();
            targetPath = TargetPathTextBox.Text;
        }

        private void OutputPathTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearStatus();
            outputPath = OutputPathTextBox.Text;
        }
    }
}
