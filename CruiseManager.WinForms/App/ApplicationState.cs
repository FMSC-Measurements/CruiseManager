using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CruiseDAL.DataObjects;
using System.IO;
using System.Xml.Serialization;
using CruiseManager.Core.App;

namespace CruiseManager.WinForms.App
{

    
    public class ApplicationState : IApplicationState
    {
        const int RECENT_FILE_LIST_SIZE = 10;

        [Serializable]
        public class ApplicationStateData
        {
            private string[] _recentFiles = new string[0];

            [XmlArray]
            public String[] RecentFiles
            {
                get { return _recentFiles; }
                set { _recentFiles = value; }
            }
        }


        private ApplicationStateData _data;
        public ApplicationState()
        {
            _data = Deserialize() ?? new ApplicationStateData();

        }

        
        public String[] RecentFiles
        {
            get
            {
                return _data.RecentFiles;
            }
            protected set { _data.RecentFiles = value; }
        }

        public void AddRecentFile(String path)
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

            this.RecentFiles = newRecentFiles;

            try
            {
                this.Save();
            }
            catch (IOException e)
            {
                throw new UserFacingException("Could Not Access Setting File", e);                
            }                
        }

        public void Save()
        {
            var path = GetAppSettingsPath();
            var directory = Path.GetDirectoryName(path);
            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ApplicationStateData));
                serializer.Serialize(writer, this._data);
            }
        }

        private ApplicationStateData Deserialize()
        {
            try
            {
                string path = GetAppSettingsPath();
                if (!File.Exists(path))
                {
                    path = GetOldAppSettingPath();
                    if(!File.Exists(path))
                    {
                        return null;
                    }
                } 

                using (StreamReader reader = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ApplicationStateData));
                    return (ApplicationStateData)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex);
                return null;
            }

        }

        private static string GetOldAppSettingPath()
        {
            string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return directory + "\\state.xml";
        }

        private static string GetAppSettingsPath()
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) , "FMSC\\CruiseManager");
            return Path.Combine(directory, "state.xml");
        }


    }
}
