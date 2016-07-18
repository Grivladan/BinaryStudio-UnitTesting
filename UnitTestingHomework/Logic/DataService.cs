using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class DataService : IDataService
    {
        private List<int> _data;

        public DataService(int capacity)
        {
            _data = new List<int>(capacity);
        }

        public int ItemsCount {get{ return _data == null ? 0 : _data.Count;} }

        public void AddItem(int a)
        {
            _data.Add(a);
        }

        public int GetElementAt(int index)
        {
            return _data.ElementAt(index);
        }

        public IEnumerable<int> GetAllData()
        {
            return _data;
        }

        public void RemoveAt(int index)
        {
            _data.RemoveAt(index);
        }

        public void ClearAll()
        {
            _data.Clear();
        }

        public int GetMax()
        {
            return _data.Max();
        }
    }
}