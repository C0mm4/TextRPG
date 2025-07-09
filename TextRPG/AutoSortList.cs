using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class AutoSortList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> _list = new();

        public event Action<List<T>>? OnChanged;

        public void Add(T item)
        {
            _list.Add(item);
            _list.Sort();
            OnChanged?.Invoke(_list);
        }

        public bool Remove(T item)
        {
            bool ret = _list.Remove(item);
            if (ret)
            {
                _list.Sort();
                OnChanged?.Invoke(_list);
            }

            return ret;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _list.Count)
            {
                _list.RemoveAt(index);
                _list.Sort();
                OnChanged?.Invoke(_list);
            }
        }
        public T? Find(Predicate<T> match) => _list.Find(match);
        public List<T> FindAll(Predicate<T> match) => _list.FindAll(match);
        public int FindIndex(Predicate<T> match) => _list.FindIndex(match);
        public int FindIndex(int startIndex, Predicate<T> match) => _list.FindIndex(startIndex, match);
        public int FindIndex(int startIndex, int count, Predicate<T> match) => _list.FindIndex(startIndex, count, match);
        public int FindLastIndex(Predicate<T> match) => _list.FindLastIndex(match);
        public int FindLastIndex(int startIndex, Predicate<T> match) => _list.FindLastIndex(startIndex, match);
        public int FindLastIndex(int startIndex, int count, Predicate<T> match) => _list.FindLastIndex(startIndex, count, match);
        public T? FindLast(Predicate<T> match) => _list.FindLast(match);
        public bool Exists(Predicate<T> match) => _list.Exists(match);
        public bool TrueForAll(Predicate<T> match) => _list.TrueForAll(match);


        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        public int Count => _list.Count;
        public T this[int index] => _list[index];
    }
}
