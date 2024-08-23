// Given an integer array nums and an integer k, return the k most frequent elements. 
// You may return the answer in any order.

// Example 1:
// Input: nums = [1,1,1,2,2,3], k = 2
// Output: [1,2]
// Example 2:

// Input: nums = [1], k = 1
// Output: [1]
 

// Constraints:

// 1 <= nums.length <= 105
// -104 <= nums[i] <= 104
// k is in the range [1, the number of unique elements in the array].
// It is guaranteed that the answer is unique.
 

// Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.

using System;
using System.Collections.Generic;
int[] topKFrequent(int[] nums, int k) {
    Dictionary<int, int> freqCounter = new Dictionary<int, int>();
    nums.ToList().ForEach(num => {
        if (freqCounter.ContainsKey(num)) {
            freqCounter[num]++;
        } else {
            freqCounter.Add(num, 1);
        }
    });

    // List<List<int>> bucketsByFre = new List<List<int>>();
    // bucketsByFre must be of size nums.Length + 1 because the maximum frequency of any element can be nums.Length
    List<int>[] bucketsByFre = new List<int>[nums.Length + 1]; //array of lists (each ele is a list)
    for (int i = 0; i < bucketsByFre.Length; i++) {
        bucketsByFre[i] = new List<int>();
    }

    // sure that entry.Value (frequency) is not greater than nums.Length so we can use it as index of bucketsByFre
    foreach (var entry in freqCounter) {
        bucketsByFre[entry.Value].Add(entry.Key);
    }

    int[] res = new int[k];
    int resIdx = 0;
    for (int i = bucketsByFre.Length - 1; i >= 0; i--) {
        if (bucketsByFre[i].Count <= 0) {
            continue;
        }
        foreach (var ele in bucketsByFre[i]) {
            res[resIdx] = ele;
            resIdx++;
            if (resIdx >=k) {
                goto end;
            }
        }
    }
    end:
        return res;
}

int[] nums = new int[] {1, 1, 1, 2, 2, 3};
int k = 2;
int[] res = topKFrequent(nums, k);
Console.WriteLine(string.Join(", ", res));
