namespace DSA.Sort.SortAlgorithms
{
    using Abstraction;
    using Common;
    class Program
    {
        static void DemoUsingSortEngineDelegate(int[] array)
        {
            SortEngineDelegate sortEngineV2 = new SortEngineDelegate();
            //sortEngineV2.SetSortAlgorithm((anyArr) => SelectionSort(anyArr));
            //SortDelegate sortSelection = (anyArr) => SelectionSort(anyArr);

            //sortEngineV2.SetSortAlgorithm((anyArr) => BubbleSort(anyArr));

            //sortEngineV2.SetSortAlgorithm((anyArr) => SortAlgorithms.InsertionSort(anyArr));
            //sortEngineV2.SetSortAlgorithm(anyArr => SortAlgorithms.MergeSort(anyArr));
            sortEngineV2.SetSortAlgorithm(anyArr => SortAlgorithms.QuickSort(anyArr));
            sortEngineV2.Sort(array);
        }

        static void DemoUsingSortEngineStrategy(int[] array)
        {
            //SortEngineStrategy.Sort(array, new SelectionSortStrategy());
            //SortEngineStrategy.Sort(array, new BubbleSortStrategy());
            //SortEngineStrategy.Sort(array, new InsertionSortStrategy());
            //SortEngineStrategy.Sort(array, new MergeSortStrategy());
            SortEngineStrategy.Sort(array, new QuickSortStrategy());
        }

        static void Main(string[] args)
        {
            int[] array = { 5, 3, 8, 4, 2 };
            //DemoUsingSortEngineDelegate(array);
            DemoUsingSortEngineStrategy(array);
            foreach (var item in array) {
                System.Console.WriteLine(item);
            }

        }
    }
}