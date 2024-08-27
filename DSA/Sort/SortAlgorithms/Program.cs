using DSA.Sort.SortAlgorithms.Abstraction;
namespace DSA.Sort.SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 3, 8, 4, 2 };
            SortEngineStrategy.Sort(array, new SelectionSortStrategy());
            foreach (var item in array)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}