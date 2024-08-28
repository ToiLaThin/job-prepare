namespace DSA.Sort.SortAlgorithms
{
    using Abstraction;
    using Common;
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 3, 8, 4, 2 };
            //SortEngineStrategy.Sort(array, new SelectionSortStrategy());

            SortEngineDelegate sortEngineV2 = new SortEngineDelegate();
            //sortEngineV2.SetSortAlgorithm((anyArr) => SelectionSort(anyArr));
            //SortDelegate sortSelection = (anyArr) => SelectionSort(anyArr);

            //sortEngineV2.SetSortAlgorithm((anyArr) => BubbleSort(anyArr));

            //sortEngineV2.SetSortAlgorithm((anyArr) => SortAlgorithms.InsertionSort(anyArr));
            //sortEngineV2.SetSortAlgorithm(anyArr => SortAlgorithms.MergeSort(anyArr));
            sortEngineV2.SetSortAlgorithm(anyArr => SortAlgorithms.QuickSort(anyArr));
            sortEngineV2.Sort(array);

            foreach (var item in array) {
                System.Console.WriteLine(item);
            }

        }
    }
}