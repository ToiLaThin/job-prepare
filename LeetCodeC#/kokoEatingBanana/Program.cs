// Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
// Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.
// Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.
// Return the minimum integer k such that she can eat all the bananas within h hours.

 

// Example 1:
// Input: piles = [3,6,7,11], h = 8
// Output: 4
// Example 2:

// Input: piles = [30,11,23,4,20], h = 5
// Output: 30
// Example 3:

// Input: piles = [30,11,23,4,20], h = 6
// Output: 23

// Constraints:
// 1 <= piles.length <= 104
// piles.length <= h <= 109
// 1 <= piles[i] <= 109

// h is threshold of hours to eat all bananas, result must cause hours to be less than or equal to h

using System;
int minKokoEatingSpeed(int[] piles, int h) {
    //create an array of speed from 1 to max pile 
    // int maxPile = piles.Max();
    // int[] speeds = Enumerable.Range(1, maxPile + 1).ToArray();

    //bin search on speeds to find the min speed, for each midSpeed, calculate the hours to eat all piles
    int l = 1;
    int r = piles.Max();
    int res = r;
    while (l <= r) {
        int m = (l + r) / 2;
        long hoursToEat = 0;
        foreach (int p in piles) {
            hoursToEat += (int)Math.Ceiling((double)p / m); //(double)(p/m) give wrong result because of integer division
        }
        if (hoursToEat <= h) {
            res = m;
            r = m - 1;
        } else {
            l = m + 1;
        }
    }

    return res;
}

// int[] piles = new int[] {3,6,7,11};
// int h = 8;
// int[] piles = new int[] {30,11,23,4,20};
// int h = 5;

int[] piles = new int[] {25,10,23,4};
int h = 4; // 25
Console.WriteLine(minKokoEatingSpeed(piles, h)); // 30