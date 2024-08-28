namespace DSA.Sort.SortAlgorithms.Common
{
    public static class SortAlgorithms
    {
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
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

        private static void Merge(int[] array, int left, int mid, int right)
        {
            int i = left;
            int k = left;
            int j = mid + 1;
            int[] temp = new int[right + 1];

            while (k <= right) {
                if (i == mid + 1) {
                    for (int idx = j; idx <= right; idx++) {
                        temp[k] = array[idx];
                        k += 1;
                    }
                    break;
                }

                if (j == right + 1) {
                    for (int idx = i; idx <= mid; idx++) {
                        temp[k] = array[idx];
                        k += 1;
                    }
                    break;
                }

                if (array[i] < array[j]) {
                    temp[k] = array[i];
                    i += 1;
                }
                else
                {
                    temp[k] = array[j];
                    j += 1;
                }
                k++;
            }

            for (int idx = left; idx <= right; idx++)
            {
                array[idx] = temp[idx];
            }
        }

        private static void DivideAndMergeRecursion(int[] arr, int left, int right)
        {
            if (left == right) {
                return;
            }

            int mid = (left + right) / 2;
            DivideAndMergeRecursion(arr, left, mid);
            DivideAndMergeRecursion(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }

        public static void MergeSort(int[] array) {
            DivideAndMergeRecursion(array, 0, array.Length - 1);
        }

        private static void Partition(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = arr[(j + i) / 2];
            while (i <= j)
            {
                //move to elements need partioning
                while (arr[i] < pivot) {
                    i += 1;
                }
                while (arr[j] > pivot) {
                    j -= 1;
                }     

                //without equal, infinite loop
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i += 1;
                    j -= 1;
                }
            }

            if (i < right) {
                Partition(arr, i, right);
            }
            if (j > left)
            {
                Partition(arr, left, j);
            }
        }
        public static void QuickSort(int[] array)
        {
            Partition(array, 0, array.Length - 1);
        }
    }
}
