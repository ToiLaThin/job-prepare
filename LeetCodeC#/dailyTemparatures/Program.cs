// Given an array of integers temperatures represents the daily temperatures, 
// return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.

 

// Example 1:

// Input: temperatures = [73,74,75,71,69,72,76,73]
// Output: [1,1,4,2,1,1,0,0]
// Example 2:

// Input: temperatures = [30,40,50,60]
// Output: [1,1,1,0]
// Example 3:

// Input: temperatures = [30,60,90]
// Output: [1,1,0]
 

// Constraints:

// 1 <= temperatures.length <= 105
// 30 <= temperatures[i] <= 100

int[] dailyTemparatures1(int[] temperatures) {
    int[] result = new int[temperatures.Length];
    for(int i = 0; i < temperatures.Length; i++) {
        for (int j = i + 1; j < temperatures.Length; j++) {
            if(temperatures[j] > temperatures[i]) {
                result[i] = j - i;
                break;
            }
        }
    }
    return result;
}

// Using Monotonic Stack: 
// stack will store index and temperatures[i] of previous day
// for the current day, we will keep popping if curr day > stack top (previous day) and update the result for that previous day
// finally push the current day to stack
// Time complexity: O(n)
// Space complexity: O(n)
// so the order of the temperatures is decreasing in the stack

// the problem can be also understand as for the current day, find all the nearest previous day with smaller temp and calculate the difference
// we stop when we find the first previous day with higher temp

// stack when we have debt, we need to pay it back later
// element in stack are days that not yet found the next nearest day with higher temp in decreasing order
 int[] dailyTemparatures2(int[] temperatures) {
    Stack<int> mStackPreviousDayIdx = new Stack<int>();
    //initialize the result array with 0
    int[] result = new int[temperatures.Length]; // this is not required as the default value of int is 0
    //int[] result = new int[temperatures.Length].Select(x => 0).ToArray();

    for(int i = 0; i < temperatures.Length; i++) {
        while(mStackPreviousDayIdx.Count > 0 && temperatures[i] > temperatures[mStackPreviousDayIdx.Peek()]) {
            int previousDayIdx = mStackPreviousDayIdx.Pop();
            result[previousDayIdx] = i - previousDayIdx;
        }
        mStackPreviousDayIdx.Push(i);
    }

    return result;
}

int[] temperatures = new int[] {73,74,75,71,69,72,76,73};
Console.WriteLine(string.Join(", ", dailyTemparatures2(temperatures)));