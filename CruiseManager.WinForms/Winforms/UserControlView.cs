using CruiseManager.Core.ViewModel;
using CruiseManager.ViewModel;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public class UserControlView : UserControl, IView
    {
        ViewModelBase _viewPresenter;

        public virtual ViewModelBase ViewModel
        {
            get { return _viewPresenter; }
            protected set
            {
                OnViewModelChanging();
                _viewPresenter = value;
                OnViewModelChanged();
            }
        }

        protected virtual void OnViewModelChanged()
        {
        }

        protected virtual void OnViewModelChanging()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            if(ViewModel is IViewLoadAware vm)
            {
                vm.OnViewLoad();
            }
        }

        

        #region abstract methods
        public virtual void EndEdits()
        { }
        #endregion


        public void ShowWaitCursor()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.ShowWaitCursor));
            }
            else
            {
                this.TopLevelControl.Cursor = Cursors.WaitCursor;
            }
        }

        public void ShowDefaultCursor()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.ShowDefaultCursor));
            }
            else
            {
                this.TopLevelControl.Cursor = Cursors.Default;
            }
        }

    }
}