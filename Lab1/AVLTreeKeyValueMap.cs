using System.Collections.Generic;
using DSA.DataStructures.Trees;

namespace Lab1
{
    class AVLTreeKeyValueMap<TKey, TValue> : IKeyValueMap<TKey, TValue>
    {
        private AVLTreeMap<TKey, TValue> AVLSearchTreeMap = new AVLTreeMap<TKey, TValue>();
        public AVLTreeKeyValueMap()
        {
        }

        public int Height => AVLSearchTreeMap.Height;

        public int Count => AVLSearchTreeMap.Count;

        public void Add(TKey key, TValue value)
        {
            AVLSearchTreeMap.Add(key, value);
        }

        public KeyValuePair<TKey, TValue> Get(TKey key)
        {
            var value = AVLSearchTreeMap[key];
            return new KeyValuePair<TKey, TValue>(key, value);
        }

        public bool Remove(TKey key)
        {
            if (AVLSearchTreeMap.ContainsKey(key))
            {
                AVLSearchTreeMap.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}