using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CruiseDAL;

namespace CruiseManager.Services
{
    public class DatabaseProvider : IDatabaseProvider
    {
        public bool HasIncompleteCruise => HasUnfinishedCruiseFile();

        public DAL Database => GetV2Database();

        public string FilePath { get; set; }

        DAL GetV2Database()
        {
            var filepath = FilePath;
            var extention = System.IO.Path.GetExtension(filepath).ToLower();
            if(extention == ".cruise")
            {
                return new DAL(extention);
            }
            else { return null; }
        }

        public static bool HasUnfinishedCruiseFile()
        {
            string tempPath = GetTempCruiseLocation();
            return System.IO.File.Exists(tempPath);
        }

        public static string GetTempCruiseLocation()
        {
            return System.IO.Path.GetDirectoryName(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + "\\" + Strings.TEMP_FILENAME;
        }

        public Task<DAL> GetNewCruiseAsync()
        {
            throw new NotImplementedException();
        }

        public DAL GetIncompleteCruise()
        {
            var tempCruiseLocation = GetTempCruiseLocation();
            if(File.Exists(tempCruiseLocation))
            {
                return new DAL(tempCruiseLocation);
            }
            else { return null; }
        }

        public void FinalizeNewCruise()
        {
            throw new NotImplementedException();
        }
    }
}
