using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CommandModel
{
    public abstract class ViewDispatchCommand : BoundCommand
    {
        public ViewDispatcher Dispatcher { get; set; }


        public Type ViewType { get; set; }
        
        public ViewDispatchCommand(String text, Type viewType, bool enabled = true) : base(text)
        {
            this.Name = text;
            this.ViewType = viewType;
            this.Enabled = enabled;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        protected override CommandBinding GetNewBinding(object control)
        {
            throw new NotImplementedException();
        }


        protected override void OnExceptionHandlerChanged()
        {
            throw new NotImplementedException();
        }
    }
}
