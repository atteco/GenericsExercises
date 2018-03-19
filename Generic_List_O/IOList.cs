using System;

namespace Generic_List_O
{
    public interface IOList<T> where T : class
    {
        void Add(T item);
        void Delete(T item);
        void DeleteItem(T item);
        void DeleteItem(Func<T, bool> condition);
        T[] GetAllInArray();
        ItemEnum<T> GetEnumerator();
        T GetItem(Func<T, bool> condition);
        T GetItemFromIndex(int i);
        int GetItemIndex(T item);
        int Length();
    }
}