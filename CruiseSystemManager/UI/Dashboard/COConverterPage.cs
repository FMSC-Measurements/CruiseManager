using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSM.Utility;

namespace CSM.NavPages
{
    public partial class COConverterPage : UserControl, IPage
    {
        public string targetPath { get; set; }
        public string outputPath { get; set; }
        //public CSMHomePresenter Presenter { get; protected set; }

        public COConverterPage()
        {
            InitializeComponent();
            
            //this.Presenter = Presenter;

            //setting textbox bindings 
            TargetPathTextBox.DataBindings.Add("Text", this, "targetPath");
            OutputPathTextBox.DataBindings.Add("Text", this, "outputPath");
        }

        private void TargetPathBrowseButton_Click(object sender, EventArgs e)
        {
            ClearStatus();
            openFileDialog.Filter = "Cruise Files (*.crz)|*.crz";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                targetPath = openFileDialog.FileName;
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
            //saveFileDialog.OverwritePrompt = false;//becase we are going to display our own warning
            saveFileDialog.DefaultExt = "cruise";
            saveFileDialog.Filter = "Cruise Files (*.cruise)|*.cruise";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //if (System.IO.File.Exists(saveFileDialog.FileName))
                //{
                //    if (MessageBox.Show("File already exists It will be overwritten.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                //    {
                //        outputPath = saveFileDialog.FileName;
                //    }
                //}
                //else
                //{
                    outputPath = saveFileDialog.FileName;
                //}
            }
            else
            {
                outputPath = null;
                
            }
            OutputPathTextBox.Text = outputPath;
        }

        COConverter converter;

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if( outputPath == null || targetPath == null)
            {
                return;
            }

            StatusLabel.Text = "Please wait";


            converter = new COConverter();
            Control.CheckForIllegalCrossThreadCalls = false;
            IAsyncResult result = converter.BenginConvert(targetPath, outputPath, null, 
                 
                new AsyncCallback(ConvertDone));
            this.UseWaitCursor = true;
            this.Parent.Text = "Working";

            
        }

        private void ConvertDone(IAsyncResult result)
        {
            this.UseWaitCursor = false;
            if (converter.EndConvert(result))
            {
                StatusLabel.Text = "Success";
            }
            else
            {
                StatusLabel.Text = "Unsuccessful";
            }
            this.Parent.Text = "";
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private void ConvertUpdate(ProcessUpdateEventArgs e)
        {
            progressBar1.PerformStep();
        }

        //public bool ConvertCruise(String targetPath, String outputPath)
        //{
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    using (COConverter converter = new COConverter())
        //    {
        //        var success = converter.Convert(targetPath, outputPath, null);
        //        if (success)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            var responce = MessageBox.Show("Unable to convert file, would you like to save the log file", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //            if (responce == DialogResult.Yes)
        //            {
        //                saveFileDialog.DefaultExt = "txt";
        //                saveFileDialog.Filter = "Text file (*.txt)|*.txt";
        //                saveFileDialog.FilterIndex = 0;
        //                if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //                {
        //                    converter.Dumplog(saveFileDialog.FileName);
        //                }
        //            }
        //            return false;
        //        }
        //    }
        //}

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

        private void ClearStatus()
        {
            StatusLabel.Text = "";
        }



        #region IPage Members


        public bool HandleKeypress(Keys key)
        {
            return false;
        }

        #endregion
    }
}
