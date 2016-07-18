using System.Collections.Generic;

namespace Logic
{
    public interface IDataService
    {
        int ItemsCount { get; }

        void AddItem(int a);

        int GetElementAt(int index);

        IEnumerable<int> GetAllData();

        void RemoveAt(int index);

        void ClearAll();
        int GetMax();
    }
}