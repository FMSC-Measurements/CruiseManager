using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using CruiseDAL.DataObjects;
using System.Reflection;
using CruiseManager.Core.SetupModels;

namespace CruiseManager.Core.App
{

    public abstract class SetupService
    {
        public static readonly string DEFAULT_SETUP_PATH = "\\STPinfo.setup";
        public static readonly string THREEP_FILE_NAME = @"ThreePCodes.xml";
        public static readonly string LOGGING_METHOD_FILE_NAME = @"LoggingMethods.xml";
        public static readonly string TREE_FIELD_FILE_NAME = @"TreeFields.xml";
        public static readonly string PRODUCT_CODE_FILE_NAME = @"ProductCodes.xml";
        public static readonly string UOM_FILE_NAME = @"UOMCodes.xml";
        public static readonly string LOG_FIELD_FILE_NAME = @"LogFields.xml";
        public static readonly string AUDIT_VALUE_FILE_NAME = @"AuditValues.xml";
        public static readonly string CRUISE_METHOD_FILE_NAME = @"CruiseMethods.xml";
        public static readonly string TREE_DEFAULT_FILE_NAME = "TreeDefaults.xml";
        public static readonly string REGION_FILE_NAME = "Regions.xml";


        public static SetupService Instance { get; set; }

        //public static SetupService GetHandle()
        //{
        //    if (_instance != null)
        //    {
        //        return _instance;
        //    }
        //    throw new InvalidOperationException();
        //}

        //public static void Initialize(SetupService instance)
        //{
        //    System.Diagnostics.Debug.Assert(instance != null);
        //    _instance = instance;
        //}

        protected SetupService()
            : this(DEFAULT_SETUP_PATH)
        { }

        protected SetupService(String path)
        {
            string directory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.Path = directory + path;
            //Path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\USDA Forest Service\FMSC\" + path;
        }

        public string Path { get; private set; }

        protected void CheckFileExists()
        {
            if (!System.IO.File.Exists(Path))
            {
                throw new System.IO.IOException("Unable to locate file @ " + Path);
            }
        }

        protected abstract void ExtractStream(string fileName, Stream stream);
        

        protected abstract void SaveStream(string fileName, MemoryStream stream);
       

        public List<CruiseMethod> GetCruiseMethods()
        {
            List<CruiseMethod> list = null;
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                
                ExtractStream(CRUISE_METHOD_FILE_NAME, stream);             
                XmlSerializer s = new XmlSerializer(typeof(List<CruiseMethod>));
                list = s.Deserialize(stream) as List<CruiseMethod>;
            }

            list.RemoveAll((CruiseMethod cm) =>
                Array.IndexOf(CruiseDAL.Schema.Constants.CruiseMethods.UNSUPPORTED_METHODS, cm.Code) != -1);

            return list;
        }

        public void SaveCruiseMethods(List<CruiseMethod> CruiseMethods)
        {
            CheckFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<CruiseMethod>));
                s.Serialize(stream, CruiseMethods);
                SaveStream(CRUISE_METHOD_FILE_NAME, stream);
            }
        }

        public void SaveRegions(List<Region> regions)
        {
            CheckFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Region>));
                s.Serialize(stream, regions);
                SaveStream(REGION_FILE_NAME, stream);
            }
        }

        public List<Region> GetRegions()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(REGION_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<Region>));
                try
                {
                    return s.Deserialize(stream) as List<Region>;
                }
                catch
                {
                    return new List<Region>();
                }
                
            }

        }
        

        public List<ThreePCode> GetThreePCodes()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(THREEP_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<ThreePCode>));
                return s.Deserialize(stream) as List<ThreePCode>;
            }

        }

        public List<LoggingMethod> GetLoggingMethods()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(LOGGING_METHOD_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<LoggingMethod>));
                return s.Deserialize(stream) as List<LoggingMethod>;
            }
        }

        public List<TreeFieldSetupDO> GetTreeFieldSetups()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(TREE_FIELD_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<TreeFieldSetupDO>));
                return s.Deserialize(stream) as List<TreeFieldSetupDO>;
            }
        }

        public List<ProductCode> GetProductCodes()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(PRODUCT_CODE_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<ProductCode>));
                return s.Deserialize(stream) as List<ProductCode>;
            }
        }

        public List<UOMCode> GetUOMCodes()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(UOM_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<UOMCode>));
                return s.Deserialize(stream) as List<UOMCode>;
            }
        }

        public List<LogFieldSetupDO> GetLogFieldSetups()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(LOG_FIELD_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<LogFieldSetupDO>));
                return s.Deserialize(stream) as List<LogFieldSetupDO>;
            }
        }




        public List<TreeDefaultValueDO> GetTreeDefaults()
        {
            CheckFileExists();
            using (Stream stream = new MemoryStream())
            {

                ExtractStream(TREE_DEFAULT_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<TreeDefaultValueDO>));
                return s.Deserialize(stream) as List<TreeDefaultValueDO>;
            }
        }

        public void SaveTreeDefaults(List<TreeDefaultValueDO> tdvList)
        {
            CheckFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<TreeDefaultValueDO>));
                s.Serialize(stream, tdvList);
                SaveStream(TREE_DEFAULT_FILE_NAME, stream);
            }

        }

        public void SaveLoggingMethods(List<LoggingMethod> lMeths)
        {
            CheckFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<LoggingMethod>));
                s.Serialize(stream, lMeths);
                SaveStream(LOGGING_METHOD_FILE_NAME, stream);
            }
        }

        public void SaveProductCodes(List<ProductCode> pCodes)
        {
            CheckFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<ProductCode>));
                s.Serialize(stream, pCodes);
                SaveStream(PRODUCT_CODE_FILE_NAME, stream);
            }
        }

        public void SaveUOMCodes(List<UOMCode> uomCodes)
        {
            CheckFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<UOMCode>));
                s.Serialize(stream, uomCodes);
                SaveStream(UOM_FILE_NAME, stream);
            }
        }


    }

}
