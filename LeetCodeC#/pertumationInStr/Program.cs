// Given two strings s1 and s2, 
// return true if s2 contains a permutation of s1, or false otherwise.
// In other words, return true if one of s1's permutations is the substring of s2.

// Example 1:
// Input: s1 = "ab", s2 = "eidbaooo"
// Output: true
// Explanation: s2 contains one permutation of s1 ("ba").

// Example 2:
// Input: s1 = "ab", s2 = "eidboaoo"
// Output: false
 
// Constraints:
// 1 <= s1.length, s2.length <= 104
// s1 and s2 consist of lowercase English letters.


public class Solution {
    public static bool checkInclusion(string s1, string s2) {
        int windowSize = s1.Length <= s2.Length ? s1.Length : s2.Length;
        //init all freq to 0, default value is 0
        int[] s1Freq = new int[26];

        for (int i = 0; i < s1.Length; i++) {
            s1Freq[s1[i] - 'a']++;
        }

        int left = 0;
        int right = windowSize - 1;
        while (right < s2.Length) {
            bool s2HaveCharNotInS1 = false;
            int[] s2Freq = new int[26];
            for (int i = left; i <= right; i++) {
                if (s1Freq[s2[i] - 'a'] == 0) {
                    s2HaveCharNotInS1 = true;
                    break;
                }
                s2Freq[s2[i] - 'a']++;
            }

            if (s2HaveCharNotInS1) {
                left += 1;
                    right += 1;
                continue;
            }


            bool isSame = true;
            for (char i = 'a'; i <= 'z'; i++) {
                if (s1Freq[i - 'a'] != s2Freq[i - 'a']) {
                    isSame = false;
                    break;
                }
            }

            if (!isSame) {
                left += 1;
                right += 1;
                continue;
            }
            return true;
            

        }
        return false;
    }
    public static void Main() {
        string s1 = "ab";
        // string s2 = "eidbaooo";
        string s2 = "eidboaoo";
        System.Console.WriteLine(checkInclusion(s1, s2));
    }
}