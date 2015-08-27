using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CruiseDAL;

namespace CSM.UI
{
    public partial class DialogConfigCounts : Form
    {
        private SampleGroupDO _sampleGroup;


        public DialogConfigCounts()
        {
            InitializeComponent();
            _speciesLB.DisplayMember = "Species";
            this._speciesLB.SelectedValueChanged += new EventHandler(_speciesLB_SelectedValueChanged);
            this._tallyBySpeciesCB.CheckedChanged += new EventHandler(_tallyBySpeciesCB_CheckedChanged);
        }

        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._hotKeyCB.Items.AddRange(new string[] { "A", "B", "C", "D",
                "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2",
                "3", "4", "5", "6", "7", "8", "9", "0" });
            this._behaviorCB.Items.AddRange(new string[] { "Beep", "None" });
        }

        void _tallyBySpeciesCB_CheckedChanged(object sender, EventArgs e)
        {
            if(_sampleGroup == null) { return; }
            _sampleGroup.TallyBySubPop = _tallyBySpeciesCB.Checked;
            this.LayoutPage(_sampleGroup);
        }

        void _speciesLB_SelectedValueChanged(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = (TreeDefaultValueDO)this._speciesLB.SelectedValue;
            TallyDO tally = TDVLookup[tdv];
            CurrentTally = tally;
        }

        private Dictionary<TreeDefaultValueDO, TallyDO> _tdvLookup;
        Dictionary<TreeDefaultValueDO, TallyDO> TDVLookup
        {
            get
            {
                if (_tdvLookup == null)
                {
                    _tdvLookup = new Dictionary<TreeDefaultValueDO, TallyDO>();
                }
                return _tdvLookup;
            }
        }


        TallyDO CurrentTally
        {
            get
            {
                return _BS_tally.Current as TallyDO;
            }
            set
            {
                if (_BS_tally.Current == value) { return; }
                if (_BS_tally.Contains(value) == false)
                {
                    _BS_tally.Add(value);
                }
                _BS_tally.Position = _BS_tally.IndexOf(value);
            }
        }

        private void LayoutPage(SampleGroupDO sg)
        {
            if (TDVLookup.Count != 0) { TDVLookup.Clear(); }
            bool tallyBySubPop = (sg.TallyBySubPop.HasValue) ? sg.TallyBySubPop.Value : false;
            StratumDO stratum = sg.Stratum;
            IList<TreeDefaultValueDO> TDVList = sg.TreeDefaultValues;
            _speciesGB.Visible = tallyBySubPop;

            if (tallyBySubPop)
            {

                if (sg.DAL != null && sg.DAL.Exists == true)
                {
                    DAL dal = sg.DAL;
                    foreach (TreeDefaultValueDO tdv in TDVList)
                    {
                        List<TallyDO> tallyList = dal.Read<TallyDO>("Tally", "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND CountTree.TreeDefaultValue_CN = ?", sg.SampleGroup_CN, tdv.TreeDefaultValue_CN);
                        TallyDO tally = (tallyList.Count > 0) ? tallyList[0] : null;
                        if (tally == null)
                        {
                            tally = new TallyDO(dal);
                        }
                        TDVLookup.Add(tdv, tally);
                    }
                }
                else
                {
                    _tdvLookup = sg.Tag as Dictionary<TreeDefaultValueDO, TallyDO>;
                    if (_tdvLookup == null)
                    {
                        sg.Tag = TDVLookup;
                    }
                    foreach (TreeDefaultValueDO tdv in TDVList)
                    {
                        TallyDO tally;
                        if (TDVLookup.ContainsKey(tdv))
                        {
                            tally = TDVLookup[tdv];
                        }
                        else
                        {
                            tally = new TallyDO();
                            TDVLookup.Add(tdv, tally);
                        }
                    }
                }

                if (_speciesLB.DataSource == TDVList)
                {
                    _speciesLB.ResetBindings();
                }
                else
                {
                    _speciesLB.DataSource = TDVList;
                }
                

            }
            else
            {
 
                if (sg.DAL != null && sg.DAL.Exists == true)
                {
                    DAL dal = sg.DAL;
                    TallyDO tally = dal.ReadSingleRow<TallyDO>("Tally", "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ?", sg.SampleGroup_CN);
                    if (tally != null)
                    {
                        CurrentTally = tally;
                    }
                    else
                    {
                        tally = new TallyDO(dal);

                    }
                }
                else
                {
                    TallyDO tally = sg.Tag as TallyDO;
                    if (sg.Tag == null)
                    {
                        tally = new TallyDO();
                        sg.Tag = tally;
                    }
                    CurrentTally = tally;
                }
            }
        }


        public void ShowDialog(SampleGroupDO sg, List<TallyDO> tallyPresets)
        {
            this.Text = String.Format("Configure Tallys - {0}", sg.Code);
            this._tdvLookup = null;
            this._BS_tally.DataSource = tallyPresets;
            this._tallyBySpeciesCB.Checked = (sg.TallyBySubPop.HasValue) ? sg.TallyBySubPop.Value : false;
            LayoutPage(sg);

            
            //switch (stratum.Method)
            //{
            //    case "3P":
            //    case "S3P":
            //    case "F3P":
            //    case "P3P":
            //        {
            //            this._selectorTypeCB.SelectedText = "ThreeP";
            //            this._selectorTypeCB.Enabled = false;
            //            break;
            //        }
            //    default:
            //        {
            //            this._selectorTypeCB.Enabled = true;
            //            this._selectorTypeCB.Items.Clear();
            //            this._selectorTypeCB.Items.AddRange(new string[] { "Block", "SRS", "Systematic" });
            //            break;
            //        }
            //}

            this._sampleGroup = sg;
            this.ShowDialog();
            this._sampleGroup = null;
        }
    }
}
