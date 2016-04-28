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
        const int RECENT_FILE_LIST_SIZE = 10;

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

        public List<string> RecentFiles
        {
            get; protected set;
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

        //private string[] _recentFiles;

        //#region properties
        //public override string CruiseSaveLocation
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(Properties.Settings.Default.DefaultCruiseSaveLocation))
        //        {
        //            Properties.Settings.Default.DefaultCruiseSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles";
        //            Properties.Settings.Default.Save();
        //        }
        //        return Properties.Settings.Default.DefaultCruiseSaveLocation;
        //    }
        //    set
        //    {
        //        if (Properties.Settings.Default.DefaultCruiseSaveLocation == value) { return; }
        //        Properties.Settings.Default.DefaultCruiseSaveLocation = value;
        //        Properties.Settings.Default.Save();
        //    }
        //}

        //public override string TemplateSaveLocation
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(Properties.Settings.Default.DefaultTemplateSaveLocation))
        //        {
        //            Properties.Settings.Default.DefaultTemplateSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CruiseFiles\\Templates";
        //            Properties.Settings.Default.Save();
        //        }
        //        return Properties.Settings.Default.DefaultTemplateSaveLocation;
        //    }
        //    set
        //    {
        //        if (Properties.Settings.Default.DefaultTemplateSaveLocation == value) { return; }
        //        Properties.Settings.Default.DefaultTemplateSaveLocation = value;
        //        Properties.Settings.Default.Save();
        //    }
        //}

        //public override string[] RecentFiles
        //{
        //    get
        //    {
        //        if (_recentFiles == null)
        //        {
        //            string raw = Properties.Settings.Default.RecentFiles ?? string.Empty;
        //            _recentFiles = raw.Split(new char[] { ';' }, RECENT_FILE_LIST_SIZE, StringSplitOptions.RemoveEmptyEntries);
        //        }

        //        return _recentFiles;
        //    }
        //}
        //#endregion

        //public override void AddRecentFile(String path)
        //{
        //    string[] oldRecentFiles = this.RecentFiles;
        //    string[] newRecentFiles = null;
        //    if (oldRecentFiles.Length > 0)
        //    {
        //        string[] union = new String[oldRecentFiles.Length + 1];
        //        union[0] = path;
        //        Array.Copy(oldRecentFiles, 0, union, 1, oldRecentFiles.Length);
        //        newRecentFiles = union.Distinct().Take(RECENT_FILE_LIST_SIZE).ToArray();
        //    }
        //    else
        //    {
        //        newRecentFiles = new string[1] { path };
        //    }

        //    this._recentFiles = newRecentFiles;
        //    Properties.Settings.Default.RecentFiles = String.Join(";", this._recentFiles);
        //    Properties.Settings.Default.Save();


        //}
    }
}
