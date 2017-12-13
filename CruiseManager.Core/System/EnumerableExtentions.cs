using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class EnumerableExtentions
    {
        public static BindingList<T> ToBindingList<T>( this IEnumerable<T> @this)
        {
            var list = @this.ToList();
            return new BindingList<T>(list);
        }
    }
}
