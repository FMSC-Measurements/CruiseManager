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

        public bool IsSTR
        {
            get
            {
                return Method == CruiseDAL.Schema.CruiseMethods.STR;
            }
        }

        //public static bool CanDefineTallys(StratumDO stratum)
        //{
        //    if (stratum != null  
        //        && (stratum.Method == "FIX" 
        //        || stratum.Method == "PNT" 
        //        || stratum.Method == "100"))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //called when the view is initialized, for each stratum 
        //initialized a list containing information about sampleGroups
        public void LoadSampleGroups()
        {
            if (SampleGroups != null) { return; }//if we have already created initialized this stratum, 

            SampleGroups = this.DAL.Read<TallySetupSampleGroup>("SampleGroup", "WHERE Stratum_CN = ?", Stratum_CN);
            foreach (TallySetupSampleGroup sg in SampleGroups)
            {
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
            return (base.Code + "  -  " + base.Method);
        }
    }
}
