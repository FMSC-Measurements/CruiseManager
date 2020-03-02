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
        protected SetupServiceBase()
        {
            
        }

        

        public List<CruiseMethod> GetCruiseMethods()
        {
            List<CruiseMethod> list = null;
            using (Stream stream = GetStream(CRUISE_METHOD_FILE_NAME))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<CruiseMethod>));
                list = s.Deserialize(stream) as List<CruiseMethod>;
            }

            list.RemoveAll((CruiseMethod cm) =>
                Array.IndexOf(CruiseDAL.Schema.CruiseMethods.UNSUPPORTED_METHODS, cm.Code) != -1);

            return list;
        }

        public List<LogFieldSetupDO> GetLogFieldSetups()
        {
            using (var stream = GetStream(LOG_FIELD_FILE_NAME))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<LogFieldSetupDO>));
                return s.Deserialize(stream) as List<LogFieldSetupDO>;
            }
        }

        public List<LoggingMethod> GetLoggingMethods()
        {
            using (var stream = GetStream(LOGGING_METHOD_FILE_NAME))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<LoggingMethod>));
                return s.Deserialize(stream) as List<LoggingMethod>;
            }
        }

        public List<ProductCode> GetProductCodes()
        {
            using (var stream = GetStream(PRODUCT_CODE_FILE_NAME))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<ProductCode>));
                return s.Deserialize(stream) as List<ProductCode>;
            }
        }

        public List<Region> GetRegions()
        {
            using (var stream = GetStream(REGION_FILE_NAME))
            {
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
            using (var stream = GetStream(TREE_FIELD_FILE_NAME))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<TreeFieldSetupDO>));
                return s.Deserialize(stream) as List<TreeFieldSetupDO>;
            }
        }

        public List<UOMCode> GetUOMCodes()
        {
            using (var stream = GetStream(UOM_FILE_NAME))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<UOMCode>));
                return s.Deserialize(stream) as List<UOMCode>;
            }
        }

        protected abstract Stream GetStream(string fileName);
    }
}