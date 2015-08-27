using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CSM.Utility.Setup;
using System.IO;
using System.Windows.Forms;
using CSM.Utility;
using System.Xml.Serialization;

namespace CSM
{
    public delegate void DatabaseChangedEventHandler(FileState state);

    public delegate void TreeDefaultsChangedEventHandler(bool error);

    public delegate void SupervisorModeChangedEventHandler();

    public enum AppStateChangedEventType { DatabaseChanged, SupervisorModeChanged, TreeDefaultsChanged }

    public enum FileState { UnLoaded, CruiseLoaded, TemplateLoaded, Error }

    [Serializable]
    public class ApplicationState
    {
        
        private static ApplicationState _instance; 
        private ApplicationState()
        {
#if DEBUG
            _inSupervisorMode = true;
#endif
            _setupService = SetupService.GetHandle();
        }


        public static ApplicationState GetHandle()
        {
            if (_instance == null)
            {
                _instance = Deserialize();
                if (_instance == null)
                {
                    _instance = new ApplicationState();
                }
            }
            return _instance;
        }

        private static ApplicationState Deserialize()
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
                    XmlSerializer serializer = new XmlSerializer(typeof(ApplicationState));
                    return (ApplicationState)serializer.Deserialize(reader);
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
            return directory + "\\AppSettings.xml";
        }

        public void Save()
        {
            string path = GetAppSettingsPath();
            using (StreamWriter writer = new StreamWriter(path,false))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ApplicationState));
                serializer.Serialize(writer, this);
                writer.Close();
            }
        }


        private SetupService _setupService;
        private DAL _dataBase;
        private bool _inSupervisorMode;
        //private List<TreeDefaultValueDO> _treeDefaults;

        public event DatabaseChangedEventHandler DatabaseChanged;

        public event TreeDefaultsChangedEventHandler TreeDefaultsChanged;

        public event SupervisorModeChangedEventHandler SupervisorModeChanged;

        [XmlElement]
        public bool? CreateSaleFolder { get; set; }

        [XmlIgnore]
        public SetupService SetupServ { get { return _setupService; } }

        [XmlIgnore]
        public DAL Database
        {
            get { return _dataBase; }
            set
            {
                if (value == _dataBase) { return; }
                try
                {
                    _dataBase = value;
                    if (value == null)
                    {
                        OnDatabaseChanged(FileState.UnLoaded);
                        return;
                    }
                    if (value.Extension == R.Strings.CRUISE_FILE_EXTENTION)
                    {
                        OnDatabaseChanged(FileState.CruiseLoaded);
                    }
                    else if (value.Extension == R.Strings.CRUISE_TEMPLATE_FILE_EXTENTION)
                    {
                        OnDatabaseChanged(FileState.TemplateLoaded);
                    }
                }
                catch( System.Exception e)
                {
                    System.Diagnostics.Trace.TraceError("{0} {1}", e.Message, e.StackTrace);
                    throw e;
                }
            }
        }

        [XmlIgnore]
        public bool InSupervisorMode
        {
            get 
            {
                return _inSupervisorMode;
            }
            set
            {
                if (_inSupervisorMode == value) { return; }
                _inSupervisorMode = value;
                OnSupervisorModeChanged();
            }
        }

        //public List<TreeDefaultValueDO> TreeDefaults
        //{
        //    get { return _treeDefaults; }
        //    set
        //    {
        //        if (_treeDefaults == value) { return; }
        //        _treeDefaults = value;
        //        OnTreeDefaultsChanged(false);
        //    }
        //}

        //public static SetupService SetupService;

        public static DirectoryInfo GetTemplateFolder()
        {
            string commonAppDir = Application.CommonAppDataPath;
            DirectoryInfo companyDir = System.IO.Directory.GetParent(commonAppDir);
            while (companyDir.Name != Application.CompanyName && companyDir.Parent != null)
            {
                companyDir = companyDir.Parent;
            }
            DirectoryInfo templateFolder = new DirectoryInfo(companyDir.FullName + "\\TemplateFiles");
            if (templateFolder.Exists == false) { templateFolder.Create(); }
            return templateFolder;
        }

        public static List<FileInfo> GetTemplateFiles()
        {
            DirectoryInfo tDir = GetTemplateFolder();
            //filter all files ending in .cut
            List<FileInfo> files = new List<FileInfo>(tDir.GetFiles("*" + CSM.Utility.R.Strings.CRUISE_TEMPLATE_FILE_EXTENTION));
            return files;
        }


        public void OnDatabaseChanged(FileState state)
        {
            if (DatabaseChanged != null)
            {
                DatabaseChanged(state);
            }
        }

        public void OnTreeDefaultsChanged(bool error)
        {
            if (TreeDefaultsChanged != null)
            {
                TreeDefaultsChanged(error);
            }
        }

        public void OnSupervisorModeChanged()
        {
            if (SupervisorModeChanged != null)
            {
                SupervisorModeChanged();
            }
        }

    }
}
