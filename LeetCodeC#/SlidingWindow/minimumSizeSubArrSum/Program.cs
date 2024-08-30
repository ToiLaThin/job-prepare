// Given an array of positive integers nums and a positive integer target, return the minimal length of a subarray
// whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.

// Example 1:
// Input: target = 7, nums = [2,3,1,2,4,3]
// Output: 2
// Explanation: The subarray [4,3] has the minimal length under the problem constraint.

// Example 2:
// Input: target = 4, nums = [1,4,4]
// Output: 1

// Example 3:
// Input: target = 11, nums = [1,1,1,1,1,1,1,1]
// Output: 0

public class Program {
    public static int minSubArrLen(int[] nums, int target) {
        int left = 0;
        int right = -1;
        int sum = 0;
        int minLen = int.MaxValue;

        while (left < nums.Length) {
            right += 1;
            while (sum < target && right < nums.Length) {
                sum += nums[right];
                if (right == nums.Length - 1) {                    
                    break; //avoid index out of range
                }
                if (sum >= target) {
                    minLen = Math.Min(minLen, right - left + 1);
                    break;
                }
                right += 1;
            }

            if (sum < target && minLen == int.MaxValue && right == nums.Length - 1) {
                return 0;
            }

            while (sum >= target && left <= right) {
                System.Console.WriteLine($"left: {left}, right: {right}, sum: {sum}");
                minLen = Math.Min(minLen, right -  left + 1);
                System.Console.WriteLine($"minLen: {minLen}");
                sum -= nums[left];
                left += 1;
                if (left == nums.Length) {
                    break;
                }
            }

            if (sum < target && right == nums.Length - 1) {
                break;
            }
        }
        return minLen == int.MaxValue ? 0 : minLen;
    }
    public static void Main() {
        int[] nums = { 2, 3, 1, 2, 4, 3 };
        int target = 7;
        int result = minSubArrLen(nums, target);
        System.Console.WriteLine(result);

    }
}