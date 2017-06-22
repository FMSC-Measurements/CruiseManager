using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ILogGradeAuditView : IView
    {
        void EndEdit();
    }
}