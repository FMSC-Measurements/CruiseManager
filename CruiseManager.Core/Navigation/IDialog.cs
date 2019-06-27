using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Navigation
{
    public interface ICruiseManagerDialog : IDialog<CruiseManagerNavigationParamiters>
    { }

    public interface IDialog<TNavParams> : IDialog where TNavParams : NavigationParamiters_Base
    {
        TNavParams NavigationParamiters { get; set; }
    }

    public interface IDialog
    {
        void SetNavParams(NavigationParamiters_Base NavigationParamiters);
    }
}
