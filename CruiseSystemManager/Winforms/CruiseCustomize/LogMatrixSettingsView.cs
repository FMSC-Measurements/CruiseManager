using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;

namespace CSM.Winforms.CruiseCustomize
{
    public partial class LogMatrixSettingsView : UserControl
    {
        private CheckBox[] grades;
        private bool _currentLogMatrixChanging = false;

        public CustomizeCruisePresenter Presenter { get; set; }

        public LogMatrixSettingsView(CustomizeCruisePresenter presenter)
        {
            this.Presenter = presenter;
            InitializeComponent();

            //put all the grade checkBoxes in to a nice array
            //, so we can access them with a indexer
            this.grades = new CheckBox[10];
            this.grades[0] = this.grade0;
            this.grades[1] = this.grade1;
            this.grades[2] = this.grade2;
            this.grades[3] = this.grade3;
            this.grades[4] = this.grade4;
            this.grades[5] = this.grade5;
            this.grades[6] = this.grade6;
            this.grades[7] = this.grade7;
            this.grades[8] = this.grade8;
            this.grades[9] = this.grade9;
        }

        private string GradeCodeSeperator
        {
            get
            {
                if (_descriptorAndRB.Checked == true)
                { return "&"; }
                if (_descriptorOrRB.Checked == true)
                { return "or"; }
                if (_descriptorCamprunRB.Checked == true)
                { return "(camprun)"; }
                return string.Empty;
            }
        }

        public object DataSource
        {
            get { return this._BS_LogMatrix.DataSource; }
            set { this._BS_LogMatrix.DataSource = value; }
        }

        public void EndEdit()
        {


        }

        private void UpdateLogGradeCode()
        {
            LogMatrixDO lm = this._BS_LogMatrix.Current as LogMatrixDO;
            if (lm == null)
            {
                this._logGradeCodeTB.Text = string.Empty;
                return;
            }

            List<String> list = new List<string>();

            if (!string.IsNullOrEmpty(lm.LogGrade1)) { list.Add(lm.LogGrade1); }
            if (!string.IsNullOrEmpty(lm.LogGrade2)) { list.Add(lm.LogGrade2); }
            if (!string.IsNullOrEmpty(lm.LogGrade3)) { list.Add(lm.LogGrade3); }
            if (!string.IsNullOrEmpty(lm.LogGrade4)) { list.Add(lm.LogGrade4); }
            if (!string.IsNullOrEmpty(lm.LogGrade5)) { list.Add(lm.LogGrade5); }
            if (!string.IsNullOrEmpty(lm.LogGrade6)) { list.Add(lm.LogGrade6); }

            lm.GradeDescription = string.Join(" " + GradeCodeSeperator + " ",
                list.ToArray());
        }

        private void OnCurrentLogMatrixChanged(LogMatrixDO lm)
        {
            _currentLogMatrixChanging = true;

            foreach (CheckBox cb in grades)
            {
                cb.Checked = false;
            }

            if (string.IsNullOrEmpty(lm.Species))
            {
                _logMatrixSpeciesCB.SelectedIndex = -1;
            }

            if (!String.IsNullOrEmpty(lm.LogGrade1))
            {
                SetLogMatrixGradeView(lm.LogGrade1, true);
            }
            if (!String.IsNullOrEmpty(lm.LogGrade2))
            {
                SetLogMatrixGradeView(lm.LogGrade2, true);
            }
            if (!String.IsNullOrEmpty(lm.LogGrade3))
            {
                SetLogMatrixGradeView(lm.LogGrade3, true);
            }
            if (!String.IsNullOrEmpty(lm.LogGrade4))
            {
                SetLogMatrixGradeView(lm.LogGrade4, true);
            }
            if (!String.IsNullOrEmpty(lm.LogGrade5))
            {
                SetLogMatrixGradeView(lm.LogGrade5, true);
            }
            if (!String.IsNullOrEmpty(lm.LogGrade6))
            {
                SetLogMatrixGradeView(lm.LogGrade6, true);
            }

            if (!string.IsNullOrEmpty(lm.GradeDescription))
            {
                if (lm.GradeDescription.Contains('&'))
                {
                    this._descriptorAndRB.Checked = true;
                }
                else if (lm.GradeDescription.Contains("or"))
                {
                    this._descriptorOrRB.Checked = true;
                }
                else if (lm.GradeDescription.Contains("(camprun)"))
                {
                    this._descriptorCamprunRB.Checked = true;
                }
            }
            else
            {
                this._descriptorAndRB.Checked = false;
                this._descriptorOrRB.Checked = false;
                this._descriptorCamprunRB.Checked = false;
            }

            if (lm.ReportNumber == "R008")
            {
                _r008RB.Checked = true;
            }
            else if (lm.ReportNumber == "R009")
            {
                _r009RB.Checked = true;
            }
            else
            {
                _r008RB.Checked = true;
                //HACK editing property while current logMatrix is changind causes exception to be thrown when property changed event is thrown
                lm.SuspendEvents();//prevent property changed events from fireing
                lm.ReportNumber = "R008";
                lm.ResumeEvents();
            }

            //UpdateLogGradeCode();
            _currentLogMatrixChanging = false;
        }

        private void SetLogMatrixGradeView(string grade, bool value)
        {
            try
            {
                int i = Convert.ToInt32(grade);
                grades[i].Checked = value;
            }
            catch
            {
                //do nothing
            }
        }

        private bool SetLogMatrixGrade(string grade, bool value)
        {
            LogMatrixDO lm = this._BS_LogMatrix.Current as LogMatrixDO;
            if (lm == null) { return false; }

            if (value == false)
            {
                if (lm.LogGrade1 == grade)
                {
                    lm.LogGrade1 = string.Empty;
                    return true;
                }
                if (lm.LogGrade2 == grade)
                {
                    lm.LogGrade2 = string.Empty;
                    return true;
                }
                if (lm.LogGrade3 == grade)
                {
                    lm.LogGrade3 = string.Empty;
                    return true;
                }
                if (lm.LogGrade4 == grade)
                {
                    lm.LogGrade4 = string.Empty;
                    return true;
                }
                if (lm.LogGrade5 == grade)
                {
                    lm.LogGrade5 = string.Empty;
                    return true;
                }
                if (lm.LogGrade6 == grade)
                {
                    lm.LogGrade6 = string.Empty;
                    return true;
                }
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(lm.LogGrade1))
                {
                    lm.LogGrade1 = grade;
                    return true;
                }
                if (string.IsNullOrEmpty(lm.LogGrade2))
                {
                    lm.LogGrade2 = grade;
                    return true;
                }
                if (string.IsNullOrEmpty(lm.LogGrade3))
                {
                    lm.LogGrade3 = grade;
                    return true;
                }
                if (string.IsNullOrEmpty(lm.LogGrade4))
                {
                    lm.LogGrade4 = grade;
                    return true;
                }
                if (string.IsNullOrEmpty(lm.LogGrade5))
                {
                    lm.LogGrade5 = grade;
                    return true;
                }
                if (string.IsNullOrEmpty(lm.LogGrade6))
                {
                    lm.LogGrade6 = grade;
                    return true;
                }
                return false;
            }
        }

        private void grade_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentLogMatrixChanging == true) { return; }

            for (int i = 0; i < grades.Length; i++)
            {
                if (object.ReferenceEquals(grades[i], sender))
                {
                    if (this.SetLogMatrixGrade(i.ToString(), this.grades[i].Checked) == false)
                    {
                        this.grades[i].Checked = false;
                    }
                    UpdateLogGradeCode();
                }
            }
        }

        private void descriptor_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentLogMatrixChanging == true) { return; }
            this.UpdateLogGradeCode();
        }

        private void _addLogMatrixBTN_Click(object sender, EventArgs e)
        {

            this._BS_LogMatrix.Add(new LogMatrixDO());
        }

        private void _deleteLogMatrixBTN_Click(object sender, EventArgs e)
        {
            LogMatrixDO lm = this._BS_LogMatrix.Current as LogMatrixDO;
            if (lm == null) { return; }
            lm.Delete();
            this._BS_LogMatrix.Remove(lm);
        }

        private void _clearLogMatrixBTN_Click(object sender, EventArgs e)
        {
            foreach (LogMatrixDO lm in Presenter.LogMatrix)
            {
                if (lm.IsPersisted)
                {
                    lm.Delete();
                }
            }
            _BS_LogMatrix.Clear();
        }

        private void _BS_LogMatrix_CurrentChanged(object sender, EventArgs e)
        {
            LogMatrixDO lm = _BS_LogMatrix.Current as LogMatrixDO;
            if (lm == null)
            {
                this.newParameters.Enabled = false;
                return;
            }
            this.newParameters.Enabled = true;
            this.OnCurrentLogMatrixChanged(lm);
        }

        private void UpdateSEDLimmit()
        {
            LogMatrixDO lm = _BS_LogMatrix.Current as LogMatrixDO;
            if (lm == null) { return; }

            lm.SEDlimit = string.Format("{0} {1} {2} {3}",
                this._descriptor1.Text,
                (lm.SEDminimum > 0) ? lm.SEDminimum.ToString() : string.Empty,
                this._descriptor2.Text,
                (lm.SEDmaximum > 0) ? lm.SEDmaximum.ToString() : string.Empty);

        }


        private void sedLimmitSettingsChanged(object sender, EventArgs e)
        {
            UpdateSEDLimmit();
        }

        private void ReportID_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentLogMatrixChanging == true) { return; }
            LogMatrixDO lm = _BS_LogMatrix.Current as LogMatrixDO;
            if (lm == null) { return; }
            if (_r008RB.Checked == true)
            {
                lm.ReportNumber = "R008";
            }
            else if (_r009RB.Checked == true)
            {
                lm.ReportNumber = "R009";
            }
        }

    }


    
}
