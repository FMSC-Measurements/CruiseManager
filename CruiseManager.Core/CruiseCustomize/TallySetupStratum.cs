using CruiseDAL.Schema;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "Stratum")]
    public class TallySetupStratum : DataObject_Base
    {
        public bool CanDefineTallies
        {
            get
            {
                if (Method == CruiseDAL.Schema.CruiseMethods.FIXCNT)
                {
                    return false;
                }
                else { return true; }
            }
        }

        public bool CanEditSystematic
        {
            get
            {
                return Method == CruiseDAL.Schema.CruiseMethods.STR;
            }
        }

        public bool IsSTR
        {
            get
            {
                return Method == CruiseDAL.Schema.CruiseMethods.STR;
            }
        }

        public List<TallySetupSampleGroup> SampleGroups { get; set; }

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

        //called when the view is initialized, for each stratum
        //initialized a list containing information about sampleGroups
        public void LoadSampleGroups()
        {
            if (SampleGroups != null) { return; }//if we have already created initialized this stratum,

            SampleGroups = DAL.From<TallySetupSampleGroup>()
                .Where("Stratum_CN = ?").Read(Stratum_CN).ToList();
            foreach (TallySetupSampleGroup sg in SampleGroups)
            {
                sg.Stratum = this;

                //TODO compare what we see as the tally mode vs. the stored mode on the sample group
                sg.TallyMethod = sg.GetSampleGroupTallyMode();
                sg.LoadTallieData();

                if (Method == CruiseDAL.Schema.CruiseMethods.STR
                    && sg.TallyMethod == CruiseDAL.Enums.TallyMode.None)
                {
                    sg.TallyMethod = CruiseDAL.Enums.TallyMode.BySampleGroup;
                }
                if (CruiseDAL.Schema.CruiseMethods.THREE_P_METHODS.Contains(Method)
                    && sg.TallyMethod == CruiseDAL.Enums.TallyMode.None)
                {
                    sg.TallyMethod = CruiseDAL.Enums.TallyMode.BySpecies;
                }
            }
        }

        /// <returns>collection containing all hot-keys in use by sample groups in the stratum</returns>
        public IEnumerable<String> ListUsedHotKeys()
        {
            var inuseHotKeys = new String[] { } as IEnumerable<String>;
            foreach (TallySetupSampleGroup sg in this.SampleGroups)
            {
                inuseHotKeys = inuseHotKeys.Union(sg.ListUsedHotKeys());
            }
            return inuseHotKeys;
        }

        public override string ToString()
        {
            return (Code + "  -  " + Method);
        }
    }
}