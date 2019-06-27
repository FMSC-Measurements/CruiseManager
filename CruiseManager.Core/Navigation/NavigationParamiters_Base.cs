using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CruiseManager.Navigation
{
    public class NavigationParamiters_Base : Dictionary<string, object>
    {
        protected void SetValueInternal(object value, [CallerMemberName] string paramName = null)
        {

            if (base.ContainsKey(paramName))
            {
                base[paramName] = value;
            }
            else
            {
                base.Add(paramName, value);
            }
        }

        public object GetValue(string paramName)
        {
            if (base.ContainsKey(paramName))
            {
                return base[paramName];
            }
            else
            { return null; }
        }

        protected TReslut GetValueInternal<TReslut>([CallerMemberName] string paramName = null)
        {
            var value = GetValue(paramName);

            if (value is TReslut reslut) { return reslut; }

            var typeExpected = typeof(TReslut);
            return (TReslut)Convert.ChangeType(value, typeExpected);
        }
    }
}
