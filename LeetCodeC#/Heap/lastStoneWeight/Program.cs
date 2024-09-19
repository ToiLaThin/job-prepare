//https://leetcode.com/problems/last-stone-weight/description/

//2 approach 
//+ sort arr O(nlogn) => bin search to find index , then insert O(logn + n = n) => all loop: O(n^2)
//+ build heap O(nlogn) => extract 2 max (logn) => insert (logn) => all loop O(nlogn)
using System.Collections.Generic;
using System;
public class Solution {
    private static int getMaxHeapPriority(int weight) {
        //constraint 1 <= weight <= 1000
        return 1000 - weight;
    }
    public static int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
        //nlogn
        for (int i = 0; i < stones.Length; i++) {
            heap.Enqueue(stones[i], getMaxHeapPriority(stones[i]));
        }

        //nlogn
        while (heap.Count > 1) {
            int firstStoneWeight = heap.Dequeue();
            int secondStoneWeight = heap.Dequeue();

            //edge case
            if (firstStoneWeight == secondStoneWeight && heap.Count == 0) {
                return 0;
            }

            if (firstStoneWeight == secondStoneWeight) {
                continue;
            }

            int smashedStoneWeight = Math.Abs(firstStoneWeight - secondStoneWeight);
            heap.Enqueue(smashedStoneWeight, getMaxHeapPriority(smashedStoneWeight));
        }

        return heap.Dequeue();
    }
    public static void Main(String[] args) {
        // int[] stones = { 2, 7, 4, 1, 8, 1 };
        int[] stones = { 1 };
        int[] stones = { 2, 2 };
        System.Console.WriteLine(LastStoneWeight(stones));
    }
}