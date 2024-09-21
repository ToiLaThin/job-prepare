//https://leetcode.com/problems/find-the-duplicate-number/description/

using System;
using System.Collections.Generic;

//n : 1 - 10^5
//num[i]: 1 - n
public class Program {
    //time: O(n)
    //space O(n)
    public static int FindDuplicate(int[] nums) {
        Dictionary<int, int> counter = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            if (counter.ContainsKey(nums[i])) {
                return nums[i];
            }
            counter[nums[i]] = 1;
        }
        return 0;
    }
    public static void Main(string[] args) {
        int[] nums = { 1, 3, 4, 2, 2 };
        int result = FindDuplicate(nums);
        System.Console.WriteLine(result);
    }
}