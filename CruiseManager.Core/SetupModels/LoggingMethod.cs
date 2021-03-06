﻿using System;
using System.Xml.Serialization;

namespace CruiseManager.Core.SetupModels
{
    [Serializable]
    public class LoggingMethod
    {
        public LoggingMethod()
        {
        }

        public LoggingMethod(String[] values)
        {
            Code = values[0];
            FriendlyValue = values[1];
        }

        [XmlAttribute]
        public String Code { get; set; }

        [XmlAttribute]
        public String FriendlyValue { get; set; }

        [XmlIgnore]
        public string CodePlus
        {
            get
            {
                return String.Concat(this.Code, " - ", this.FriendlyValue);
            }
        }

        //public override String ToString()
        //{
        //    return String.Concat(this.Code, " - ", this.FriendlyValue);
        //}

        //#region IFormattable Members

        //public string ToString(string format, IFormatProvider formatProvider)
        //{
        //    return this.ToString();
        //}

        //#endregion
    }
}