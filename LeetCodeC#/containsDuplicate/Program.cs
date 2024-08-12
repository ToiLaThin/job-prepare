using System;
using System.Collections.Generic;
bool hasDuplicate(int[] nums) {
    HashSet<int> set = new HashSet<int>();
    for(int i = 0; i < nums.Length; i++) {
        if (set.Contains(nums[i])) {
            return true;
        }
        set.Add(nums[i]);
    }
    return false;
}

int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
System.Console.WriteLine(hasDuplicate(nums));