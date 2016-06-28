﻿using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.ViewModel;
using CruiseManager.WinForms.CommandModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public partial class UserControlContainerView : UserControlView, IContainerView
    {
        public UserControlContainerView(ApplicationControllerBase appController)
        {
            this.ApplicationController = appController;
            InitializeComponent();
        }

        public override IPresentor ViewPresenter
        {
            get
            {
                return this.ActiveView.ViewPresenter;
            }

            protected set
            {
            }
        }

        private IView _activeView;

        public IView ActiveView
        {
            get
            {
                return _activeView;
            }

            set
            {
                if (value == _activeView) { return; }
                if (UnWireActiveView(_activeView))
                {
                    WireUpActiveView(value);
                    _activeView = value;
                }
            }
        }

        public ApplicationControllerBase ApplicationController
        {
            get; protected set;
        }

        private IEnumerable<ViewNavigateCommand> _viewLinks;

        public IEnumerable<ViewNavigateCommand> ViewLinks
        {
            get
            {
                return _viewLinks;
            }
            set
            {
                this._navLinkPanel.SuspendLayout();
                this._navLinkPanel.Controls.Clear();

                var buttons = (from ViewNavigateCommand cmd in value
                               select MakeLinkButton(cmd)).ToArray();
                this._navLinkPanel.Controls.AddRange(buttons);
                this._navLinkPanel.ResumeLayout();

                this._viewLinks = value;
            }
        }

        protected Button MakeLinkButton(ViewNavigateCommand cmd)
        {
            Button newButton = new LinkButton();
            cmd.BindTo(newButton);
            return newButton;
        }

        private class LinkButton : Button
        {
            public LinkButton()
            {
                this.SetStyle(ControlStyles.Selectable, false);
                this.FlatStyle = FlatStyle.Flat;
            }
        }

        public void NavigateTo(Type viewType)
        {
            var view = this.ApplicationController.GetView(viewType);
            this.ActiveView = view;
        }

        public void NavigateTo<T>() where T : IView
        {
            var view = this.ApplicationController.GetView<T>();
            this.ActiveView = view;
        }

        protected bool UnWireActiveView(IView view)
        {
            if (view == null) { return true; }
            var saveHandler = view.ViewPresenter as ISaveHandler;
            if (saveHandler != null && saveHandler.HasChangesToSave)
            {
                var doSave = _activeView.AskYesNoCancel("You Have Unsaved Changes, Would You Like To Save Before Closing?", "Save Changes?", null);
                if (doSave == null)//user selects cancel
                {
                    return false;
                    //return false;//don't change views
                }
                else if (doSave == true)
                {
                    saveHandler.HandleSave();
                }
                else//continue without saving
                { }
            }

            Control cView = (Control)view;
            this._contentPanel.Controls.Remove(cView);
            return true;
        }

        protected void WireUpActiveView(IView view)
        {
            if (view == null) { this.Controls.Clear(); return; }

            Control cView = (Control)view;

            cView.SuspendLayout();
            cView.Dock = DockStyle.Fill;
            cView.BringToFront();
            this._contentPanel.Controls.Add(cView);
            cView.ResumeLayout();
        }
    }
}