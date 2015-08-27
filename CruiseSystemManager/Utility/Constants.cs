using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL.Schema;

namespace CSM.Utility
{
    public static class Constants
    {
        internal static readonly TreeDefaultValueDO[] EMPTY_SPECIES_LIST = new TreeDefaultValueDO[] { };

        public static readonly String[] LOGGING_METHODS = new String[] { "1", "2", "3", "..." };

        public static readonly String[] SALE_PURPOSE = new string[] { "Timber Sale", "Check Cruise", "Right of Way", "Recon", "Other" };
    }

    public static class R
    {
        

        public static class Strings
        {
            public const string SUPERVISOR_LOGIN = "$m0k3yb3ar"; 

            public const string HOME_LAYOUT_TITLE_BAR = "Cruise Manager - FMSC";

            public const string LEGACY_CRUISE_FILE_EXTENTION = ".crz";
            public const string CRUISE_FILE_EXTENTION = ".cruise";
            public const string CRUISE_TEMPLATE_FILE_EXTENTION = ".cut";
            public const string COMPONET_MASTER_EXTENTION = ".M.cruise";

            public  static readonly string TEMP_FILENAME = "~temp.cruise";

            public const string FRIENDLY_LEGACY_CRUISE_FILETYPE_NAME = "Cruise File(Pre 2013)";
            public const string FRIENDLY_CRUISE_FILETYPE_NAME = "Cruise File";
            public const string FRIENDLY_CRUISE_TEMPLATE_FILETYPE_NAME = "Cruise Template File";
            public const string FRIENDLY_COMPONENT_MASTER_FILETYPE_NAME = "Component Master File";

            //public static readonly string[] THREE_P_METHODS = new string[] { "3P", "S3P", "F3P", "P3P" };//moved to CruiseDAL.Schema.CruiseMethods

            public static readonly string[] EDITABLE_UNIT_FILEDS = new string[] { CUTTINGUNIT.AREA, CUTTINGUNIT.DESCRIPTION, CUTTINGUNIT.LOGGINGMETHOD };
            public static readonly string[] EDITABLE_ST_FIELDS = new string[] { STRATUM.DESCRIPTION, STRATUM.MONTH, STRATUM.YEAR, STRATUM.YIELDCOMPONENT };
            public static readonly string[] EDITABLE_SG_FIELDS = new string[] { SAMPLEGROUP.BIGBAF };

            public static readonly string[] HOTKEYS = new string[] { "A", "B", "C", "D",
                "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2",
                "3", "4", "5", "6", "7", "8", "9", "0" };

            public static readonly string[] INDICATOR_TYPES = new string[] { "Beep", "None" };

            public enum IndicatorType { Beep, None };

            public static readonly string OPEN_CRUISE_FILE_DIALOG_FILTER = 
                String.Format("All CSM files|*{1};*{3}| {0}(*{1})|*{1}| {2} (*{3})|*{3}| {4} (*{5})|*{5}",
                R.Strings.FRIENDLY_CRUISE_FILETYPE_NAME,
                R.Strings.CRUISE_FILE_EXTENTION,
                R.Strings.FRIENDLY_CRUISE_TEMPLATE_FILETYPE_NAME,
                R.Strings.CRUISE_TEMPLATE_FILE_EXTENTION,
                R.Strings.FRIENDLY_COMPONENT_MASTER_FILETYPE_NAME,
                R.Strings.COMPONET_MASTER_EXTENTION);
        }

    }

    public static class SQL
    {
        public static string CLEAR_FIELD_DATA = @"
UPDATE CountTree Set TreeCount = 0, SumKPI = 0;
UPDATE SampleGroup Set SampleSelectorState = '';
DELETE FROM Log;
DELETE FROM Stem;
DELETE FROM LogStock;
DELETE FROM TreeCalculatedValues;
DELETE FROM Tree;
DELETE FROM Plot;
DELETE FROM ErrorLog WHERE TableName IN ('Tree', 'Plot', 'Log', 'Stem');
UPDATE CuttingUnit Set TallyHistory = NULL;
";

        public static string MAKE_COUNTS_FOR_COMPONENTS = @"INSERT OR IGNORE INTO CountTree (Component_CN, SampleGroup_CN, CuttingUnit_CN, Tally_CN, TreeDefaultValue_CN, CreatedBy) 
SELECT Component.Component_CN, CountTree.SampleGroup_CN, CountTree.CuttingUnit_CN, Tally_CN, CountTree.TreeDefaultValue_CN, CountTree.CreatedBy
FROM CountTree JOIN Component ON CountTree.Component_CN = Component.Component_CN
UNION ALL
SELECT Component.Component_CN, CountTree.SampleGroup_CN, CountTree.CuttingUnit_CN, Tally_CN, CountTree.TreeDefaultValue_CN, CountTree.CreatedBy
FROM COMPONENT JOIN CountTree
WHERE CountTree.Component_CN IS NULL;";
    }

}
