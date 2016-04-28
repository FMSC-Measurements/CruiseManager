using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.WinForms.App
{
    public class UserSettings : IUserSettings
    {

        public UserSettings()
        {
            if(string.IsNullOrEmpty( Properties.Settings.Default.DefaultCruiseSaveLocation))
            {
                Properties.Settings.Default.DefaultCruiseSaveLocation = 
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                    + @"\CruiseFiles";
            }
            if(String.IsNullOrEmpty(Properties.Settings.Default.DefaultTemplateSaveLocation))
            {
                Properties.Settings.Default.DefaultTemplateSaveLocation = 
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                    + "\\CruiseFiles\\Templates";
            }
        }

        public bool? CreateSaleFolder
        {
            get
            {
                bool tmp;
                if (bool.TryParse(Properties.Settings.Default.CreateSaleFolder, out tmp))
                { return tmp; }
                else
                { return null; }              
            }
            set
            {
                Properties.Settings.Default.CreateSaleFolder 
                    = (value.HasValue) ? value.ToString() : string.Empty;
            }
        }

        public string CruiseSaveLocation
        {
            get
            {
                return Properties.Settings.Default.DefaultCruiseSaveLocation;
            }

            set
            {
                Properties.Settings.Default.DefaultCruiseSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }

        public string FileNameFormat
        {
            get
            {
                return Properties.Settings.Default.FileNameFormat;
            }

            set
            {
                Properties.Settings.Default.FileNameFormat = value;
            }
        }


        public string Region
        {
            get
            {
                return Properties.Settings.Default.UserRegion; 
            }
            set
            {
                Properties.Settings.Default.UserRegion = value;
            }
        }

        public string TemplateSaveLocation
        {
            get
            {
                return Properties.Settings.Default.DefaultTemplateSaveLocation;
            }

            set
            {
                Properties.Settings.Default.DefaultTemplateSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }

        public void Save()
        {
            Properties.Settings.Default.Save();
        }

        public void Revert()
        {
            Properties.Settings.Default.Reload();
        }

        public void Reset()
        {
            Properties.Settings.Default.Reset();
        }

    }
}
