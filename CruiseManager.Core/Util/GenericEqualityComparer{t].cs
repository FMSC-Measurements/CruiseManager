using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.Util
{
    public class GenericEqualityComparer<T> : EqualityComparer<T>
    {
        Func<T, T, bool> _equals;
        Func<T, int> _getHash;

        public GenericEqualityComparer(Func<T, T, bool> equalsFunc)
        {
            _equals = equalsFunc;
        }

        public GenericEqualityComparer(Func<T, T, bool> equalsFunc, Func<T, int> getHashFunc)
        {
            _equals = equalsFunc;
            _getHash = getHashFunc;
        }

        public override bool Equals(T x, T y)
        {
            return _equals(x, y);
        }

        public override int GetHashCode(T obj)
        {
            if(_getHash != null)
            {
                return _getHash(obj);
            }
            else
            {
                return obj.GetHashCode();
            }
        }
    }
}
