// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
// Notice that the solution set must not contain duplicate triplets.

// Example 1:
// Input: nums = [-1,0,1,2,-1,-4]
// Output: [[-1,-1,2],[-1,0,1]]
// Explanation: 
// nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
// nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
// nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
// The distinct triplets are [-1,0,1] and [-1,-1,2].
// Notice that the order of the output and the order of the triplets does not matter.

// Example 2:
// Input: nums = [0,1,1]
// Output: []
// Explanation: The only possible triplet does not sum up to 0.

// Example 3:
// Input: nums = [0,0,0]
// Output: [[0,0,0]]
// Explanation: The only possible triplet sums up to 0.

// Constraints:
// 3 <= nums.length <= 3000
// -105 <= nums[i] <= 105

using System;
using System.Collections.Generic;

IList<IList<int>> threeSum(int[] nums) {
    //sort input array
    //if arr sorted, start element if negative, sum of 2 remaining elements is positive which mean they can be 
    //both positive, or one positive and one negative

    //but if start element is positive, sum of 2 remaining elements is negative which mean the search ends, since the left part is search 
    Array.Sort(nums);
    var result = new List<IList<int>>();

    int start = 0;
    int left, right, sum;

    while (start < nums.Length - 2) {
        if (nums[start] > 0) {
            break;
        }

        left = start + 1;
        right = nums.Length - 1;

        //2 sum using 2 pointer
        //triplet is in increasing order
        while (left < right) {
            sum = nums[start] + nums[left] + nums[right];
            if (sum == 0) {
                result.Add(new List<int> {nums[start],  nums[left], nums[right]});
                break;
            }
            else if (sum < 0) {
                //move left pointer to right
                left += 1;
            } else {
                //move right pointer to left
                right -= 1;
            }
        }

        //move start pointer to right
        start += 1;

    }
    return result;
}

// int[] nums = {-1, 0, 1, 2, -1, -4};
// int[] nums = {0, 1, 1};
int[] nums = {0, 0, 0};
var result = threeSum(nums);
if (result.Count == 0) {
    System.Console.WriteLine("[]");
}
foreach (var triplet in result) {
    Console.Write("[");
    foreach (var num in triplet) {
        if (num == triplet[triplet.Count - 1]) {
            Console.Write(num);
        } else {
            Console.Write(num + ", ");
        }
    }
    Console.WriteLine("]");
}