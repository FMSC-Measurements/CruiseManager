using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;

namespace CSM.Winforms.CruiseCustomize
{
    public class TallySetupStratum : CruiseDAL.DataObjects.StratumDO
    {
        public List<TallySetupSampleGroup> SampleGroups { get; set; }


        /// <returns>collection containing all hotkeys in use by samplegroups in the stratum</returns>
        public ICollection<String> ListHotKeysInuse()
        {
            string[] inuseHotKeys = new string[0];
            foreach (TallySetupSampleGroup sg in this.SampleGroups)
            {
                inuseHotKeys = inuseHotKeys.Union(
                    (from TallyDO tally in sg.Tallies.Values
                     select tally.Hotkey)).ToArray();
            }
            return inuseHotKeys;
        }


        public override string ToString()
        {
            return (base.Code + "  -  " + base.Method);
        }
    }
}
