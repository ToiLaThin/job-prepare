// input arr: [9, 3, 5, 3, 5, 7, 2, 2]
// pattern [3, 5, 7] => check if this pattern exist in the arr, return the index

public class Program {
    public static int searchPattern(int[] arr, int[] pattern) {
        int p1 = 0; //p for arr
        int p2 = 0; //p for pattern
        while (p1 < arr.Length && p2 < pattern.Length) {
            int pTemp = p1;
            while (arr[pTemp] == pattern[p2]) {
                pTemp += 1;
                p2 += 1;

                if (p2 == pattern.Length) {
                    return p1;
                }

                if (pTemp == arr.Length) {
                    return -1;
                }
            }
            p1 += 1;
            p2 = 0;
        }

        //no pattern found
        if (p1 < arr.Length && p2 == pattern.Length) {
            return p1;
        }
        return -1;
    }

    public static int searchPattern2(int[] arr, int[] pattern) {
        for (int i = 0; i <= arr.Length - pattern.Length; i++) {
            bool patternFound = true;
            for (int j = 0; j < pattern.Length; j++) {
                if (arr[i + j] != pattern[j]) {
                    patternFound = false;
                    break;
                }
            }
            if (patternFound) {
                return i;
            }
        }
        return -1;
    }
    public static void Main(string[] args) {
        int[] arr = { 9, 3, 5, 3, 5, 7, 2, 2 };
        // int[] arr = { 3, 5, 7, 3, 5, 7 };
        // int[] arr = { 3, 5, 6, 7, 8, 3, 5 };
        int[] pattern = { 3, 5, 7};


        // int[] arr = { 3, 5, 7, 7, 3, 5, 7, 8 };
        // int[] pattern = { 7, 8 };
        int result = searchPattern2(arr, pattern);
        Console.WriteLine(result);
    }
}