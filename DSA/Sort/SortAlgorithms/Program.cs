using DSA.Sort.SortAlgorithms.Abstraction;
namespace DSA.Sort.SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 3, 8, 4, 2 };
            //SortEngineStrategy.Sort(array, new SelectionSortStrategy());

            SortEngineDelegate sortEngineV2 = new SortEngineDelegate();
            sortEngineV2.SetSortAlgorithm((anyArr) => SelectionSort(anyArr));
            //signature
            sortEngineV2.SetSortAlgorithm((anyArr) => BubbleSort(anyArr));
            sortEngineV2.Sort(array);

            SortDelegate sortSelection = (anyArr) => SelectionSort(anyArr);
            foreach (var item in array)
            {
                System.Console.WriteLine(item);
            }

        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++) 
                {
                    if (array[i] > array[j]) {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void BubbleSort(int[] array)
        {
            for (int times = 1; times < array.Length; times++)
            {
                for (int j = 0; j < array.Length - times; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] array)
        {

        }
    }
}