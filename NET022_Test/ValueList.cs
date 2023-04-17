namespace NET022_Test
{
    public class ValueList<T> where T : struct
    {
        private List<T> _list;

        public ValueList()
        {
            _list = new List<T>();
        }


        public ValueList(IEnumerable<T> items)
        {
            _list = new List<T>(items);
        }
        public void Add(T item)
        {
            _list.Add(item);
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= _list.Count)
            {
                throw new IndexOutOfRangeException("Index you are looking for is out of range.");
            }
            return _list[index];
        }

        public List<T> GetDescendingSortedItems()
        {
            List<T> sortedList = new List<T>(_list);
            for (int i = 0; i < sortedList.Count; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < sortedList.Count; j++)
                {
                    if (Comparer<T>.Default.Compare(sortedList[j], sortedList[maxIndex]) > 0)
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != i)
                {
                    T temp = sortedList[i];
                    sortedList[i] = sortedList[maxIndex];
                    sortedList[maxIndex] = temp;
                }
            }
            return sortedList;
        }


       
    }

}

