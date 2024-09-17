//https://leetcode.com/problems/kth-largest-element-in-a-stream/description/
//constraint: 
// 0 <= nums.length <= 1000
// 1 <= k <= nums.length + 1
// -1000 <= nums[i] <= 1000
// -1000 <= val <= 1000
// At most 1000 calls will be made to add.

using System.Collections.Generic;
public class KthLargest {

    // PriorityQueue<int, int> pq1;
    // PriorityQueue<int, int> pq2;

    PriorityQueue<int, int> minPQueueKthLargest;
    int kth;

    private int getPriority(int value) {
        return 1000 - value; // max value is 1000 => max heap, the larger the value , the more priority it have (priority smaller)
    }
    public KthLargest(int k, int[] nums) {
        //solution: 2 max heap -> time complexity: O(nlogn), space: O (2n)
        // this.pq1 = new PriorityQueue<int,int>();
        // this.pq2 = new PriorityQueue<int,int>();
        // this.kth = k;
        // foreach (int num in nums) {
        //     //try to create max heap, the larger, the more priority
        //     pq1.Enqueue(num, getPriority(num));
        // }


        //solution min heap size k, time complexity: O(nlogk) -> space: O(k)
        this.kth = k;
        this.minPQueueKthLargest = new PriorityQueue<int, int>();
        int count = 0;

        foreach (int num in nums) {
            count += 1;
            if (count <= k) {
                minPQueueKthLargest.Enqueue(num , num);
                continue;
            }
            //else, pQueue size only limit to k
            int kthLargest = minPQueueKthLargest.Peek();
            if (num > kthLargest) {
                //num is new kthLargest in minPQueue
                minPQueueKthLargest.DequeueEnqueue(num, num);
            }
        }
    }

    //time: O(nlogn)
    public int Add(int val) {
        //solution 2 max heap => time exceed: O(nlogn)
        // pq1.Enqueue(val, getPriority(val)); //logn
        // int count = 0;
        // int result = 0;

        // //n time
        // while (true) {
        //     if (pq1.Count == 0) {
        //         break;
        //     }

        //     int max = pq1.Dequeue(); //log n
        //     pq2.Enqueue(max, getPriority(max)); //log n
        //     count++;
        //     if (count == kth) {
        //         result = max;
        //     }
        // }
        // pq1 = pq2;
        // pq2 = new PriorityQueue<int, int>();
        // return result;

        //solution: 1 min heap size k: time O(logk), size kth
        if (this.minPQueueKthLargest.Count == 0 || this.minPQueueKthLargest.Count < this.kth) {
            this.minPQueueKthLargest.Enqueue(val, val);
            return this.minPQueueKthLargest.Peek();    
        }

        if (val > this.minPQueueKthLargest.Peek()) {
            this.minPQueueKthLargest.DequeueEnqueue(val, val);
        }
        return this.minPQueueKthLargest.Peek();

    }

    public static void Main(string[] args) {
        KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
        int kth = kthLargest.Add(3); // return 4
        System.Console.WriteLine(kth);
        kth = kthLargest.Add(5); // return 5
        System.Console.WriteLine(kth);
        kth = kthLargest.Add(10); // return 5
        System.Console.WriteLine(kth);
        kth = kthLargest.Add(9); // return 8
        System.Console.WriteLine(kth);
        kth = kthLargest.Add(4); // return 8
        System.Console.WriteLine(kth);
    }
}