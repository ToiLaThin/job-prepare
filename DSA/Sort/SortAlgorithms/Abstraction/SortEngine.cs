namespace DSA.Sort.SortAlgorithms.Abstraction
{
    public static class SortEngineStrategy
    {
        public static void Sort(int[] array, ISortStrategy sortAlgorithm)
        {
            sortAlgorithm.Sort(array);
        }
    }

    public interface ISortStrategy
    {
        void Sort(int[] array);
    }


    /// <summary>
    /// represent all method with same signature to be executed when this delegate invoke
    /// </summary>
    /// <param name="array"></param>
    public delegate void SortDelegate(int[] array);
    public class SortEngineDelegate
    {
        private SortDelegate _sortDelegate;
        public SortEngineDelegate() { }
        public SortEngineDelegate(SortDelegate sortDelegate)
        {
            _sortDelegate = sortDelegate;
        }

        public void Sort(int[] array)
        {
            var sortAlgorithms = _sortDelegate.GetInvocationList();
            if (sortAlgorithms.Length != 1)
            {
                Console.Out.WriteLine("Invalid");
                return;
            }
            _sortDelegate.Invoke(array);
        }

        //public void SetSortAlgorithm(Action<int[]> sortAlgorithm) { 
        //    _sortDelegate = new SortDelegate(sortAlgorithm);
        //}

        public void SetSortAlgorithm(SortDelegate sortDelegate) {
            _sortDelegate = sortDelegate;
        }
    }    
}