using CruiseDAL.Schema;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "Stratum")]
    public abstract class TallySetupStratum_Base : DataObject_Base
    {
        #region Persisted Members

        [XmlIgnore]
        [PrimaryKeyField(Name = "Stratum_CN")]
        public Int64? Stratum_CN { get; set; }

        private String _code;

        [XmlElement]
        [Field(Name = "Code")]
        public virtual String Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (_code == value) { return; }
                _code = value;
                this.NotifyPropertyChanged(STRATUM.CODE);
            }
        }

        private String _hotkey;

        [XmlElement]
        [Field(Name = "Hotkey")]
        public virtual String Hotkey
        {
            get
            {
                return _hotkey;
            }
            set
            {
                if (_hotkey == value) { return; }
                _hotkey = value;
                this.NotifyPropertyChanged(STRATUM.HOTKEY);
            }
        }

        private String _method;

        [XmlElement]
        [Field(Name = "Method")]
        public virtual String Method
        {
            get
            {
                return _method;
            }
            set
            {
                if (_method == value) { return; }
                _method = value;
                this.NotifyPropertyChanged(STRATUM.METHOD);
            }
        }

        #endregion Persisted Members

        public bool CanSelectSystematic
        {
            get
            {
                return Method == CruiseMethods.STR;
            }
        }

        public abstract bool HasChangesToSave { get; }

        public List<TallySetupSampleGroup> SampleGroups { get; set; }

        [IgnoreField]
        public string Errors { get; set; }

        //called when the view is initialized, for each stratum
        //initialized a list containing information about sampleGroups
        public abstract void Initialize();

        public abstract bool Validate();

        public abstract bool SaveTallySetup(ref StringBuilder errorBuilder);

        public override string ToString()
        {
            return (Code + "  -  " + Method);
        }
    }
}