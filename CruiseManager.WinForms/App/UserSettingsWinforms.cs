using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.App
{
    public class UserSettingsWinforms : UserSettings
    {
        private string[] _recentFiles;

        #region properties
        public override string CruiseSaveLocation
        {
            get
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.DefaultCruiseSaveLocation))
                {
                    Properties.Settings.Default.DefaultCruiseSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles";
                    Properties.Settings.Default.Save();
                }
                return Properties.Settings.Default.DefaultCruiseSaveLocation;
            }
            set
            {
                if (Properties.Settings.Default.DefaultCruiseSaveLocation == value) { return; }
                Properties.Settings.Default.DefaultCruiseSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }

        public override string TemplateSaveLocation
        {
            get
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.DefaultTemplateSaveLocation))
                {
                    Properties.Settings.Default.DefaultTemplateSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CruiseFiles\\Templates";
                    Properties.Settings.Default.Save();
                }
                return Properties.Settings.Default.DefaultTemplateSaveLocation;
            }
            set
            {
                if (Properties.Settings.Default.DefaultTemplateSaveLocation == value) { return; }
                Properties.Settings.Default.DefaultTemplateSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }
        
        public override string[] RecentFiles
        {
            get
            {
                if (_recentFiles == null)
                {
                    string raw = Properties.Settings.Default.RecentFiles ?? string.Empty;
                    _recentFiles = raw.Split(new char[] { ';' }, RECENT_FILE_LIST_SIZE, StringSplitOptions.RemoveEmptyEntries);
                }

                return _recentFiles;
            }
        }
        #endregion

        public override void AddRecentFile(String path)
        {
            string[] oldRecentFiles = this.RecentFiles;
            string[] newRecentFiles = null;
            if (oldRecentFiles.Length > 0)
            {
                string[] union = new String[oldRecentFiles.Length + 1];
                union[0] = path;
                Array.Copy(oldRecentFiles, 0, union, 1, oldRecentFiles.Length);
                newRecentFiles = union.Distinct().Take(RECENT_FILE_LIST_SIZE).ToArray();
            }
            else
            {
                newRecentFiles = new string[1] { path };
            }

            this._recentFiles = newRecentFiles;
            Properties.Settings.Default.RecentFiles = String.Join(";", this._recentFiles);
            Properties.Settings.Default.Save();


        }
    }
}
