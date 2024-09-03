namespace DSA.Sort.SortAlgorithms {
    using Abstraction;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Xml;

    public class SelectionSortStrategy: ISortStrategy {
        public void Sort(int[] array) {
            for (int i=0;i < array.Length-1;i++) {
                for (int j=i+1; j < array.Length; j++) {
                    if (array[i] > array[j]) {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }

    public class BubbleSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            for (int time = 1; time < array.Length; time++)
            {
                for (int j = 0; j < array.Length - time; j++)
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
    }

    public class InsertionSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int key = array[i];
                int idx = i - 1;
                while (idx >= 0 && key < array[idx])
                {
                    array[idx + 1] = array[idx];
                    idx -= 1;
                }
                array[idx + 1] = key;
            }
        }
    }

    public class MergeSortStrategy : ISortStrategy
    {
        private void Merge(int[] array, int left, int mid, int right)
        {
            int i = left;
            int k = left;
            int j = mid + 1;
            int[] temp = new int[right + 1];

            while (k <= right)
            {
                if (i == mid + 1)
                {
                    for (int tempIdx = j; tempIdx <= right; tempIdx++)
                    {
                        temp[k] = array[tempIdx];
                        k += 1;
                    }
                    break;
                }

                if (j == right + 1)
                {
                    for (int tempIdx = i; tempIdx <= mid; tempIdx++)
                    {
                        temp[k] = array[tempIdx];
                        k += 1;
                    }
                    break;
                }

                if (array[i] < array[j])
                {
                    temp[k] = array[i];
                    i += 1;
                }
                else
                {
                    temp[k] = array[j];
                    j += 1;
                }
                k += 1;
            }

            for (int idx = left; idx <= right; idx++) {
                array[idx] = temp[idx];
            }
        }

        private void DivideAndMergeRecursion(int[] array, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            int mid = (left + right) / 2;
            DivideAndMergeRecursion(array, left, mid);
            DivideAndMergeRecursion(array, mid + 1, right);
            Merge(array, left, mid, right);
        }

        public void Sort(int[] array)
        {
            DivideAndMergeRecursion(array, 0, array.Length - 1);
        }
    }

    public class QuickSortStrategy : ISortStrategy
    {
        private void Partion(int[] array, int left, int right)
        {
            int i = left;
            int j = right;
            int pivoit = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i] < pivoit) {
                    i += 1;
                }
                while (array[j] > pivoit) {
                    j -= 1;
                }

                //= for the case i, j point to pivot at same time
                if (i <= j) {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i += 1;
                    j -= 1;
                }
            }

            if (i < right) {
                Partion(array, i, right);
            }
            if (j > left) {
                Partion(array, left, j);
            }
        }

        public virtual void Sort(int[] array)
        {
            Partion(array, 0, array.Length - 1);
        }
    }

    public class SelectionSortStrategyDecoratedStopwatch: SelectionSortStrategy
    {
        public SelectionSortStrategyDecoratedStopwatch() {}

        public override void Sort(int[] array) {
            Stopwatch sw = Stopwatch.StartNew();
            base.Sort();
            sw.Stop();
            Console.Out.WriteLine(sw.ElapsedMilliseconds);
        }
    }

    public class BubbleSortStrategyDecoratedStopwatch: BubbleSortStrategy
    {
        public BubbleSortStrategyDecoratedStopwatch() {}

        public override void Sort(int[] array) {
            Stopwatch sw = Stopwatch.StartNew();
            base.Sort();
            sw.Stop();
            Console.Out.WriteLine(sw.ElapsedMilliseconds);
        }
    }

    public class InsertionSortStrategyDecoratedStopwatch: InsertionSortStrategy
    {
        public InsertionSortStrategyDecoratedStopwatch() {}

        public override void Sort(int[] array) {
            Stopwatch sw = Stopwatch.StartNew();
            base.Sort();
            sw.Stop();
            Console.Out.WriteLine(sw.ElapsedMilliseconds);
        }
    }

    public class QuickSortStrategyDecoratedStopwatch: QuickSortStrategy
    {
        public QuickSortStrategyDecoratedStopwatch() { }

        public override void Sort(int[] array)
        {
            Stopwatch sw = Stopwatch.StartNew();
            base.Sort(array);
            sw.Stop();
            Console.Out.WriteLine(sw.ElapsedMilliseconds);
        }
    }

    public class MergeSortStrategyDecoratedStopwatch: MergeSortStrategy
    {
        public MergeSortStrategyDecoratedStopwatch() {}

        public override void Sort(int[] array) {
            Stopwatch sw = Stopwatch.StartNew();
            base.Sort();
            sw.Stop();
            Console.Out.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
