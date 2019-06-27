using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Navigation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DialogNameAttribute : Attribute
    {
        public DialogNameAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; set; }
    }
}
