﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FMSC.Controls
{
    public class YearComboBox : ComboBox
    {
        private bool isCurrentYearInRange
        {
            get
            {
                return (_endYear > DateTime.Today.Year) && (startYear < DateTime.Today.Year);
            }
        }
        

        private int _endYear = 2099;
        public int EndYear
        {
            get
            {
                return _endYear;
            }
            set
            {
                if (value < startYear) { return; }
                _endYear = value;

                resetDateRange();
            }
        }

        private int startYear = 1900;
        public int StartYear
        {
            get
            {
                return startYear;
            }
            set
            {
                if (value > _endYear) { return; }
                startYear = value;

                resetDateRange();
            }
        }

        private void resetDateRange()
        {
            this.DataSource = Enumerable.Range(startYear, _endYear - startYear).ToArray();
        }


        public YearComboBox()
        {
            
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
            
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            if (isCurrentYearInRange && String.IsNullOrEmpty(this.Text))
            {
                this.Text = DateTime.Today.Year.ToString();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            
            
        }


        //protected override void OnDropDown(EventArgs e)
        //{
        //    base.OnDropDown(e);
        //    if (isCurrentYearInRange && this.SelectedIndex <= 0)
        //    {
        //        this.SelectedIndex = DateTime.Today.Year - startYear;
        //    }
        //}
    }
}
