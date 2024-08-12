// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

// Example 1:
// Input: s = "anagram", t = "nagaram"
// Output: true

// Example 2:
// Input: s = "rat", t = "car"
// Output: false
 
// Constraints:
// 1 <= s.length, t.length <= 5 * 104
// s and t consist of lowercase English letters.

bool IsAnagram(string s, string t) {
   if (s.Length != t.Length) {
    return false;
   }


    //use an array to track the count of each character
    //for s +1, for t -1
    //if the array is all 0s, then it is an anagram
    int[] charCount = new int[26];

    for (int i = 0; i < s.Length; i++) {
        charCount[s[i] - 'a']++;
        charCount[t[i] - 'a']--;
    }

    foreach (int count in charCount) {
        if (count != 0) {
            return false;
        }
    }
    return true;
}

System.Console.WriteLine(IsAnagram("anagram", "nagaram")); // true
System.Console.WriteLine(IsAnagram("rat", "car")); // false