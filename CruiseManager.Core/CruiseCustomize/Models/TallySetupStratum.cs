using CruiseDAL.Enums;
using CruiseDAL.Schema;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "Stratum")]
    public class TallySetupStratum : TallySetupStratum_Base
    {
        public bool IsManditoryTally
        {
            get { return CruiseMethods.MANDITORY_TALLY_METHODS.Contains(Method); }
        }

        public override bool HasChangesToSave
        {
            get
            {
                return IsChanged 
                    || SampleGroups.Any(x => x.HasTallyEdits);
            }
        }

        //called when the view is initialized, for each stratum
        //initialized a list containing information about sampleGroups
        public override void Initialize()
        {
            if (SampleGroups != null) { return; }//if we have already created initialized this stratum,

            SampleGroups = DAL.From<TallySetupSampleGroup>()
                .Where("Stratum_CN = ?").Query(Stratum_CN).ToList();
            foreach (TallySetupSampleGroup sg in SampleGroups)
            {
                sg.Stratum = this;

                sg.LoadTallieData();
            }
        }

        public override bool Validate()
        {
            bool isValid = true;
            var errorBuilder = new StringBuilder();

            isValid = ValidateTallyHotKeys(ref errorBuilder) && isValid;

            if (IsManditoryTally)
            {
                foreach (TallySetupSampleGroup sg in SampleGroups)
                {
                    if (sg.TallyMethod == TallyMode.Unknown || (sg.TallyMethod & TallyMode.None) == TallyMode.None)
                    {
                        errorBuilder.AppendFormat("Sample Group {0} in Stratum {1} needs tally configuration\r\n", sg.Code, Code);
                        isValid = false;
                    }
                }
            }

            Errors = errorBuilder.ToString();
            return isValid;
        }

        public bool ValidateTallyHotKeys(ref StringBuilder errorBuilder)
        {
            bool success = true;
            List<char> usedHotKeys = new List<char>();
            //StringBuilder errorBuilder = new StringBuilder();

            foreach (TallySetupSampleGroup sg in SampleGroups)
            {
                if (sg.TallyMethod.HasFlag(TallyMode.BySampleGroup))
                {
                    char hk = HotKeyToChar(sg.SgTallie.Hotkey);
                    if (hk == char.MinValue)
                    {
                        errorBuilder.AppendFormat("Missing Hot Key in SG:{0} Stratum:{1}\r\n", sg.ToString(), Code);
                        success = false;
                    }
                    else if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                    {
                        //ERROR stratum already has hot-key
                        errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", sg.SgTallie.Hotkey, sg.ToString(), Code);
                        success = false;
                    }
                    else
                    {
                        //SUCCESS add hot key to list of in use hot keys
                        usedHotKeys.Add(hk);
                    }
                }
                else if (sg.TallyMethod.HasFlag(TallyMode.BySpecies))
                {
                    foreach (TallyVM t in sg.Tallies.Values)
                    {
                        char hk = HotKeyToChar(t.Hotkey);
                        if (hk == char.MinValue)
                        {
                            errorBuilder.AppendFormat("Missing Hot Key in SG:{0} Stratum:{1}\r\n", sg.ToString(), Code);
                            success = false;
                        }
                        else if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                        {
                            //ERROR stratum already has hot-key
                            errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", t.Hotkey, sg.ToString(), Code);
                            success = false;
                        }
                        else
                        {
                            //SUCCESS add hot key to list of in use hot keys
                            usedHotKeys.Add(hk);
                        }
                    }
                }
            }

            return success;
        }

        public override bool SaveTallySetup(ref StringBuilder errorBuilder)
        {
            bool success = true;

            if (SampleGroups != null)
            {
                foreach (TallySetupSampleGroup sgVM in SampleGroups)
                {
                    sgVM.Save();
                    if (sgVM.HasTallyEdits == true)
                    {
                        success = sgVM.SaveTallies(ref errorBuilder) && success;
                    }
                }
            }

            return success;
        }

        public static char HotKeyToChar(string str)//TODO move method somewhere more useful
        {
            if (String.IsNullOrEmpty(str))
            {
                return char.MinValue;
            }
            return char.ToUpper(str[0]);
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

    }
}