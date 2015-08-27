using Ionic.Zip; // ZipFile
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using CruiseDAL.DataObjects;
using System.Reflection;
namespace CSM.Utility.Setup
{

    public class SetupService
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

        protected static SetupService _instance;

        public static SetupService GetHandle()
        {
            if (_instance == null)
            {
                _instance = new SetupService();
            }
            return _instance;
        }

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

        public void checkFileExists()
        {
            if (!System.IO.File.Exists(Path))
            {
                throw new System.IO.IOException("Unable to locate file @ " + Path);
            }
        }

        protected void ExtractStream(string fileName, Stream stream)
        {
            using (ZipFile zip = ZipFile.Read(Path))
            {
                if (zip.ContainsEntry(fileName) == false) { return; }
                ZipEntry entry = zip[fileName];
                entry.Extract(stream);
                stream.Position = 0;   // HACK for some reason the position is set to the end
            }
        }

        protected void SaveStream(string fileName, MemoryStream stream)
        {
            using (ZipFile zip = ZipFile.Read(Path))
            {
                stream.Position = 0;
                var buff = stream.GetBuffer();
                if ( zip.ContainsEntry(fileName) == false)
                {
                    zip.AddEntry(fileName, buff);
                }
                else
                {
                    zip.UpdateEntry(fileName, buff);
                }
                zip.Save();
            }
        }


        public List<CruiseMethod> GetCruiseMethods()
        {
            List<CruiseMethod> list = null;
            checkFileExists();
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
            checkFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<CruiseMethod>));
                s.Serialize(stream, CruiseMethods);
                SaveStream(CRUISE_METHOD_FILE_NAME, stream);
            }
        }

        public void SaveRegions(List<Region> regions)
        {
            checkFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Region>));
                s.Serialize(stream, regions);
                SaveStream(REGION_FILE_NAME, stream);
            }
        }

        public List<Region> GetRegions()
        {
            checkFileExists();
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
            checkFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(THREEP_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<ThreePCode>));
                return s.Deserialize(stream) as List<ThreePCode>;
            }

        }

        public List<LoggingMethod> GetLoggingMethods()
        {
            checkFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(LOGGING_METHOD_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<LoggingMethod>));
                return s.Deserialize(stream) as List<LoggingMethod>;
            }
        }

        public List<TreeFieldSetupDO> GetTreeFieldSetups()
        {
            checkFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(TREE_FIELD_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<TreeFieldSetupDO>));
                return s.Deserialize(stream) as List<TreeFieldSetupDO>;
            }
        }

        public List<ProductCode> GetProductCodes()
        {
            checkFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(PRODUCT_CODE_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<ProductCode>));
                return s.Deserialize(stream) as List<ProductCode>;
            }
        }

        public List<UOMCode> GetUOMCodes()
        {
            checkFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(UOM_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<UOMCode>));
                return s.Deserialize(stream) as List<UOMCode>;
            }
        }

        public List<LogFieldSetupDO> GetLogFieldSetups()
        {
            checkFileExists();
            using (Stream stream = new MemoryStream())
            {
                ExtractStream(LOG_FIELD_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<LogFieldSetupDO>));
                return s.Deserialize(stream) as List<LogFieldSetupDO>;
            }
        }




        public List<TreeDefaultValueDO> GetTreeDefaults()
        {
            checkFileExists();
            using (Stream stream = new MemoryStream())
            {

                ExtractStream(TREE_DEFAULT_FILE_NAME, stream);
                XmlSerializer s = new XmlSerializer(typeof(List<TreeDefaultValueDO>));
                return s.Deserialize(stream) as List<TreeDefaultValueDO>;
            }
        }

        public void SaveTreeDefaults(List<TreeDefaultValueDO> tdvList)
        {
            checkFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<TreeDefaultValueDO>));
                s.Serialize(stream, tdvList);
                SaveStream(TREE_DEFAULT_FILE_NAME, stream);
            }

        }

        public void SaveLoggingMethods(List<LoggingMethod> lMeths)
        {
            checkFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<LoggingMethod>));
                s.Serialize(stream, lMeths);
                SaveStream(LOGGING_METHOD_FILE_NAME, stream);
            }
        }

        public void SaveProductCodes(List<ProductCode> pCodes)
        {
            checkFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<ProductCode>));
                s.Serialize(stream, pCodes);
                SaveStream(PRODUCT_CODE_FILE_NAME, stream);
            }
        }

        public void SaveUOMCodes(List<UOMCode> uomCodes)
        {
            checkFileExists();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(List<UOMCode>));
                s.Serialize(stream, uomCodes);
                SaveStream(UOM_FILE_NAME, stream);
            }
        }


    }

}
