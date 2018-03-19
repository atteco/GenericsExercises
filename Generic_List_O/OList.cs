using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_List_O
{
    public class OList<T> : IEnumerable, IOList<T> where T:class
    {
        private int defaultSize = 5;
        private T[] store;

        public OList()
        {
            store = new T[defaultSize];
        }
        public OList(int koko)
        {
            store = new T[koko];
        }

        public void Add(T item)
        {
            if (!store.Contains(null))
            {
                Array.Resize<T>(ref store, store.GetLength(1) + 5);
            }

            for (int i=0; i < store.Length; i++)
            {
                if(store[i] == null)
                {
                    store[i] = item;
                    break;
                }
            }
        }

        public T GetItemFromIndex(int i)
        {
            return store[i];
        }

        public void Delete(T item)
        {
            store = store.Where(val => val != item).ToArray();
        }

        public int Length()
        {
            return store.Length;
        }

        public int GetItemIndex(T item)
        {
            return Array.IndexOf<T>(store, item);
        }

        public T GetItem(Func<T,bool> condition)
        {
            return store.SingleOrDefault(condition);
        }

        public void DeleteItem(T item)
        {
           store = store.Where(element => element != item).ToArray();
        }

        public void DeleteItem(Func<T,bool> condition)
        {
           store = store.Where(element => element != store.SingleOrDefault(condition)).ToArray();
        }

        public T[] GetAllInArray()
        {
            return store;
        }

        public IEnumerable<T> GetAllInIEnumerable() //TODO
        {
           // yield return store.All<T>(); 

            foreach(T item in store)
            {
                yield return item;
            }
        }

        public IEnumerable<T> GetItemIEnumerble(Func<T,bool> condition) //TODO
        {
            yield return store.SingleOrDefault(condition);
        }

        public ItemEnum<T> GetEnumerator()
        {
            return new ItemEnum<T>(store);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    //following class is implemented according to an example found here: 
    //https://msdn.microsoft.com/fi-fi/library/system.collections.ienumerator(v=vs.110).aspx 
    public class ItemEnum<T> : IEnumerator<T>
    {
        private T[] _itemStore;
        int position = -1;

        public ItemEnum(T[] itemStore)
        {
            _itemStore = itemStore;
        }


        public bool MoveNext()
        {
            position++;
            return (position < _itemStore.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            Console.WriteLine("\n_something_ was Dispose():d in ItemEnum<T>");
            Console.ReadLine();
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _itemStore[position];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Some _index_ is now out of range . . . ");
                    Console.ReadLine();
                    throw;
                }
            }
        }

    }
}
