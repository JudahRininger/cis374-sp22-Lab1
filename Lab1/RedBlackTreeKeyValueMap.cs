using System.Collections.Generic;
using DSA.DataStructures.Trees;

namespace Lab1
{
    internal class RedBlackTreeKeyValueMap<TKey, TValue> : IKeyValueMap<TKey, TValue>
    {
        private RedBlackTreeMap<TKey, TValue> RedBlackSearchTreeMap = new RedBlackTreeMap<TKey, TValue>();
        public RedBlackTreeKeyValueMap()
        {
        }

        public int Height => RedBlackSearchTreeMap.Height;

        public int Count => RedBlackSearchTreeMap.Count;

        public void Add(TKey key, TValue value)
        {
            RedBlackSearchTreeMap.Add(key, value);
        }

        public KeyValuePair<TKey, TValue> Get(TKey key)
        {
            var value = RedBlackSearchTreeMap[key];
            return new KeyValuePair<TKey, TValue>(key, value);
        }

        public bool Remove(TKey key)
        {
            if (RedBlackSearchTreeMap.ContainsKey(key))
            {
                RedBlackSearchTreeMap.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}