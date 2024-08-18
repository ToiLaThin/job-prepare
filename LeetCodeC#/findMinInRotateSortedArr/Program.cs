﻿// Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

// [4,5,6,7,0,1,2] if it was rotated 4 times.
// [0,1,2,4,5,6,7] if it was rotated 7 times.
// Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

// Given the sorted rotated array nums of unique elements, return the minimum element of this array.

// You must write an algorithm that runs in O(log n) time.

 

// Example 1:

// Input: nums = [3,4,5,1,2]
// Output: 1
// Explanation: The original array was [1,2,3,4,5] rotated 3 times.
// Example 2:

// Input: nums = [4,5,6,7,0,1,2]
// Output: 0
// Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.
// Example 3:

// Input: nums = [11,13,15,17]
// Output: 11
// Explanation: The original array was [11,13,15,17] and it was rotated 4 times. 
 

// Constraints:

// n == nums.length
// 1 <= n <= 5000
// -5000 <= nums[i] <= 5000
// All the integers of nums are unique.
// nums is sorted and rotated between 1 and n times.

//the point is to find the pivot, the pivot is the smallest element in the array

using System;
int findMin(int[] nums) {
    int l = 0;
    int r = nums.Length - 1;
    //if the array is rotated n times, the pivot is the smallest element in the array

    while (l <= r) {
        if (nums[l] <= nums[r]) { //search space is already sorted => return the first element
            return nums[l];
        }

        int m = (l + r) / 2;
        
        if (nums[m] >= nums[l] && nums[m] > nums[r]) { //pivot is in the right half
            l = m + 1;
        }
        else { //pivot is in the left half
            r = m;
        }
    }

    return -1; //should never reach here
}

// int[] nums = new int[] {3,4,5,1,2}; //output 1
// int[] nums = new int[] {4,5,6,7,0,1,2}; //output 0
// int[] nums = new int[] {2, 1}; //output 1
// int[] nums = new int[] {1}; //output 1
int[] nums = new int[] {3, 1, 2}; //output 1
Console.WriteLine(findMin(nums)); // 1