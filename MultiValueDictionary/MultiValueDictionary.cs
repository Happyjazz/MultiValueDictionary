using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public class MultiValueDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, ISet<TValue>> _data = new Dictionary<TKey, ISet<TValue>>();

        public int Count
        {
            get { return _data.Count; }
        }

        public ICollection<TKey> Keys
        {
            get { return _data.Keys; }
        }

        public bool Add(TKey key, TValue value)
        {
            if (_data.ContainsKey(key))
            {
                if (_data[key].Contains(value))
                {
                    return false;
                }
                _data[key].Add(value);
                return true;
            }
            ISet<TValue> valueSet = new HashSet<TValue>();
            valueSet.Add(value);
            _data.Add(new KeyValuePair<TKey, ISet<TValue>>(key, valueSet));
            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public ISet<TValue> Get(TKey key)
        {
            if (_data.ContainsKey(key))
            {
                return _data[key];
            }
            throw new Exception("Key not found");
        }

        public bool ContainsKey(TKey key)
        {
            if (_data.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public bool Remove(TKey key, TValue value)
        {
            if (_data.ContainsKey(key))
            {
                if (_data[key].Contains(value))
                {
                    _data[key].Remove(value);
                    if (_data[key].Count==0)
                    {
                        _data.Remove(key);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
