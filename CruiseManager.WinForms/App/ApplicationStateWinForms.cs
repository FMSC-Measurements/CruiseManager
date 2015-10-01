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

    
    public class ApplicationStateWinForms : IApplicationState
    {
        const int RECENT_FILE_LIST_SIZE = 10;

        [Serializable]
        protected class ApplicationStateData
        {
            [XmlArray]
            public String[] RecentFiles { get; set; }
        }


        private ApplicationStateData _data;
        public ApplicationStateWinForms()
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
            this.Save();
        }

        public void Save()
        {
            string path = GetAppSettingsPath();
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ApplicationStateData));
                serializer.Serialize(writer, this._data);
                writer.Close();
            }
        }

        private ApplicationStateData Deserialize()
        {
            try
            {
                string path = GetAppSettingsPath();
                if (!File.Exists(path))
                {
                    return null;
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

        private static string GetAppSettingsPath()
        {
            string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return directory + "\\state.xml";
        }


    }
}
