// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and 
// removing all non-alphanumeric characters, it reads the same forward and backward. 
// Alphanumeric characters include letters and numbers.
// Given a string s, return true if it is a palindrome, or false otherwise.

 

// Example 1:

// Input: s = "A man, a plan, a canal: Panama"
// Output: true
// Explanation: "amanaplanacanalpanama" is a palindrome.

// Example 2:
// Input: s = "race a car"
// Output: false
// Explanation: "raceacar" is not a palindrome.

// Example 3:
// Input: s = " "
// Output: true
// Explanation: s is an empty string "" after removing non-alphanumeric characters.
// Since an empty string reads the same forward and backward, it is a palindrome.
 

// Constraints:
// 1 <= s.length <= 2 * 105
// s consists only of printable ASCII characters.

using System;
using System.Collections.Generic;

bool isPalindrome(string s) {
    //lowercase, remove non-alphanumeric characters
    s = s.ToLower();
    s = new string(s.ToCharArray().Where(c => Char.IsLetterOrDigit(c)).ToArray());

    //check if string is palindrome
    //use 2 pointer move from 2 opposite directions to check palindrome    
    int left = 0;
    int right = s.Length - 1;
    while (left < right) {
        if (s[left] != s[right]) {
            return false;
        }
        left += 1;
        right -= 1;
    }

    return true;
}

// string str = "A man, a plan, a canal: Panama";
// string str = "race a car";
string str = " ";

System.Console.WriteLine(isPalindrome(str));