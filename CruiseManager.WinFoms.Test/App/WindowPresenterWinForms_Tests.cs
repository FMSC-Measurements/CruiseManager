using CruiseDAL;
using CruiseManager.WinForms.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CruiseManager.Winforms.Test.App
{
    public class WindowPresenterWinForms_Tests
    {
        [Fact]
        public void RealignTreeSpecies()
        {
            using(var db = new DAL())
            {
                WindowPresenterWinForms.RealignTreeSpecies(db, 0);
            }
        }
    }
}
