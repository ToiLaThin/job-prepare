namespace DSA.Sort.SortAlgorithms.Abstraction
{
    public static class SortEngineStrategy
    {
        public static void Sort(int[] array, ISortStrategy sortAlgorithm)
        {
            sortAlgorithm.Sort(array);
        }
    }

    public interface ISortStrategy {
        void Sort(int[] array);
    }
}