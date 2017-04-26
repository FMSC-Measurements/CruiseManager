using CruiseDAL.DataObjects;
using CruiseManager.Core.SetupModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace CruiseManager.Core.App
{
    public abstract class SetupServiceBase
    {
        public static readonly string SETUP_FILENAME = "STPinfo.setup";
        public static readonly string AUDIT_VALUE_FILE_NAME = @"AuditValues.xml";
        public static readonly string CRUISE_METHOD_FILE_NAME = @"CruiseMethods.xml";
        public static readonly string DEFAULT_SETUP_PATH = ".\\";
        public static readonly string LOG_FIELD_FILE_NAME = @"LogFields.xml";
        public static readonly string LOGGING_METHOD_FILE_NAME = @"LoggingMethods.xml";
        public static readonly string PRODUCT_CODE_FILE_NAME = @"ProductCodes.xml";
        public static readonly string REGION_FILE_NAME = "Regions.xml";
        public static readonly string TREE_FIELD_FILE_NAME = @"TreeFields.xml";
        public static readonly string UOM_FILE_NAME = @"UOMCodes.xml";
        //public static SetupService Instance { get; set; }

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

        protected SetupServiceBase()
        {
            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var directory = System.IO.Path.GetDirectoryName(codeBasePath);

            Path = codeBasePath = System.IO.Path.Combine(directory, SETUP_FILENAME);
        }

        public string Path { get; private set; }

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
                Array.IndexOf(CruiseDAL.Schema.CruiseMethods.UNSUPPORTED_METHODS, cm.Code) != -1);

            return list;
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

        protected void CheckFileExists()
        {
            if (!System.IO.File.Exists(Path))
            {
                throw new System.IO.IOException("Unable to locate file @ " + Path);
            }
        }

        protected abstract void ExtractStream(string fileName, Stream stream);

        protected abstract void SaveStream(string fileName, MemoryStream stream);
    }
}