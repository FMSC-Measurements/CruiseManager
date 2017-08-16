using CruiseDAL.Schema;
using System;
using System.Collections.Generic;

namespace CruiseManager.Core.Constants
{
    public static class Strings
    {
        public const string SUPERVISOR_LOGIN = "$m0k3yb3ar";

        public const string HOME_LAYOUT_TITLE_BAR = "Cruise Manager - FMSC";

        public const string LEGACY_CRUISE_FILE_EXTENTION = ".crz";
        public const string CRUISE_FILE_EXTENTION = ".cruise";
        public const string CRUISE_TEMPLATE_FILE_EXTENTION = ".cut";
        public const string COMPONET_MASTER_EXTENTION = ".M.cruise";

        public static readonly string TEMP_FILENAME = "~temp.cruise";

        public const string FRIENDLY_LEGACY_CRUISE_FILETYPE_NAME = "Cruise File(Pre 2013)";
        public const string FRIENDLY_CRUISE_FILETYPE_NAME = "Cruise File";
        public const string FRIENDLY_CRUISE_TEMPLATE_FILETYPE_NAME = "Cruise Template File";
        public const string FRIENDLY_COMPONENT_MASTER_FILETYPE_NAME = "Component Master File";

        //public static readonly string[] THREE_P_METHODS = new string[] { "3P", "S3P", "F3P", "P3P" };//moved to CruiseDAL.Schema.CruiseMethods

        public static readonly string[] EDITABLE_UNIT_FILEDS = { CUTTINGUNIT.AREA, CUTTINGUNIT.DESCRIPTION, CUTTINGUNIT.LOGGINGMETHOD, CUTTINGUNIT.PAYMENTUNIT };
        public static readonly string[] EDITABLE_ST_FIELDS = { STRATUM.DESCRIPTION, STRATUM.MONTH, STRATUM.YEAR, STRATUM.YIELDCOMPONENT, "MonthStr" };
        public static readonly string[] EDITABLE_SG_FIELDS = { SAMPLEGROUP.BIGBAF, SAMPLEGROUP.SECONDARYPRODUCT, SAMPLEGROUP.MINKPI, SAMPLEGROUP.MAXKPI };

        public static readonly string[] HOTKEYS = { "A", "B", "C", "D",
                "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2",
                "3", "4", "5", "6", "7", "8", "9", "0", "*", "." };

        public static readonly string[] INDICATOR_TYPES = { "Beep", "None" };

        public static readonly String[] SALE_PURPOSE = { "Timber Sale", "Check Cruise", "Right of Way", "Recon", "Other" };

        public static readonly Dictionary<string, string> PURPOSE_SHORT_MAP = new Dictionary<string, string>() {
            { "Timber Sale", "TS" },
            {"Check Cruise", "Check" },
            {"Right of Way", "RoW" },
            {"Recon", "Recon" } };

        public static readonly string[] YIELD_COMPONENT_VALUES = new string[] { "CL", "CD", "NL", "ND" };

        public enum IndicatorType { Beep, None };

        public static readonly string OPEN_CRUISE_FILE_DIALOG_FILTER =
            String.Format("All CSM files|*{1};*{3}| {0}(*{1})|*{1}| {2} (*{3})|*{3}| {4} (*{5})|*{5}",
            Strings.FRIENDLY_CRUISE_FILETYPE_NAME,
            Strings.CRUISE_FILE_EXTENTION,
            Strings.FRIENDLY_CRUISE_TEMPLATE_FILETYPE_NAME,
            Strings.CRUISE_TEMPLATE_FILE_EXTENTION,
            Strings.FRIENDLY_COMPONENT_MASTER_FILETYPE_NAME,
            Strings.COMPONET_MASTER_EXTENTION);
    }
}