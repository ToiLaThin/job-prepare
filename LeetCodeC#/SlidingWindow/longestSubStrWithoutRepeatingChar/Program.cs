// Given a string s, find the length of the longest 
// substring without repeating characters.

// Example 1:
// Input: s = "abcabcbb"
// Output: 3
// Explanation: The answer is "abc", with the length of 3.

// Example 2:
// Input: s = "bbbbb"
// Output: 1
// Explanation: The answer is "b", with the length of 1.

// Example 3:
// Input: s = "pwwkew"
// Output: 3
// Explanation: The answer is "wke", with the length of 3.
// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 
// Constraints:
// 0 <= s.length <= 5 * 104
// s consists of English letters, digits, symbols and spaces.

int lengthOfLongestSubStr(string s) {
    //unique char in the current window
    HashSet<char> charSet = new HashSet<char>();
    //current window contains unique chars
    Queue<char> uniqueCharsWindow = new Queue<char>();
    int maxLen = 0;

    foreach (char c in s) {
        if (charSet.Contains(c)) {
            while (uniqueCharsWindow.Count > 0 && uniqueCharsWindow.Peek() != c) {
                //because substring must be continuous, we can't skip chars in the middle
                char removedChar = uniqueCharsWindow.Dequeue();
                charSet.Remove(removedChar);
            }
        }
        charSet.Add(c);
        uniqueCharsWindow.Enqueue(c);
        maxLen = Math.Max(maxLen, charSet.Count);
    }

    return maxLen;
}

// string s = "abcabcbb";
string s = "pwwkewabc";
System.Console.WriteLine(lengthOfLongestSubStr(s)); //3