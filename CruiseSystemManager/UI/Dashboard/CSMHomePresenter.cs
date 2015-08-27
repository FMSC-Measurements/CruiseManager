using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM
{
    public class CSMHomePresenter 
    {
        public WindowPresenter WindowPresenter { get; protected set; }

        public CSMHomePresenter(WindowPresenter windowPresenter)
        {
            WindowPresenter = windowPresenter;
        }

        //public bool ConvertCruise(String targetPath, String outputPath)
        //{
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    using (COConverter converter = new COConverter())
        //    {
        //        var success = converter.Run(targetPath, outputPath);
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


        public void CreateNewCruise()
        {
            WindowPresenter.ShowCruiseWizardDiolog();
        }

        public bool Shutdown()
        {
            return WindowPresenter.Shutdown();
        }





        public CSMHomeView View
        {
            get;
            protected set;
        }


        public void UpdateView()
        {
            throw new NotImplementedException();
        }


    }
}
