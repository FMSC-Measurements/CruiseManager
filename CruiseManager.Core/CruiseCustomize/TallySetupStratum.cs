using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;

namespace CruiseManager.Core.CruiseCustomize
{
    public class TallySetupStratum : CruiseDAL.DataObjects.StratumDO
    {
        public List<TallySetupSampleGroup> SampleGroups { get; set; }


        /// <returns>collection containing all hot-keys in use by samplegroups in the stratum</returns>
        public ICollection<String> ListHotKeysInuse()
        {
            var inuseHotKeys = new List<string>();
            foreach (TallySetupSampleGroup sg in this.SampleGroups)
            {
                if (sg.TallyMethod.HasFlag(CruiseDAL.Enums.TallyMode.BySpecies))
                {
                    inuseHotKeys.AddRange(
                        (from TallyDO tally in sg.Tallies.Values
                         select tally.Hotkey));
                }
                else if (sg.TallyMethod.HasFlag(CruiseDAL.Enums.TallyMode.BySampleGroup))
                {
                    inuseHotKeys.Add(sg.SgTallie.Hotkey);

                }
            }
            return inuseHotKeys;
        }


        public override string ToString()
        {
            return (base.Code + "  -  " + base.Method);
        }
    }
}
