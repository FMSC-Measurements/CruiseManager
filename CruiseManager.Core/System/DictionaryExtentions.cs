namespace System.Collections.Generic
{
    public static class DictionaryExtentions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> @this, TKey key, TValue defVal = default(TValue))
        {
            TValue value;
            if (@this.TryGetValue(key, out value))
            { return value; }
            else
            { return defVal; }
        }
    }
}