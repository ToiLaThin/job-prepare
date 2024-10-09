//https://leetcode.com/problems/reverse-vowels-of-a-string/description/?envType=study-plan-v2&envId=leetcode-75
using System;
using System.Text;
public class Program {

    //O(n^2): use set to quick lookup
    public static string reverseVowels(string s) {
        if (s.Length == 0) {
            return s;
        }

        IEnumerable<char> acceptedVowels = ['a', 'e', 'i', 'o', 'u'];
        IEnumerable<char> uppercaseAcceptedVowels = acceptedVowels.Select(v => char.ToUpper(v));
        acceptedVowels = acceptedVowels.Concat(uppercaseAcceptedVowels);
        var sReversedVowels = new StringBuilder(s);
        int left = 0;
        int right = sReversedVowels.Length - 1;
        while (left < right) {
            while (acceptedVowels.Contains(sReversedVowels[left]) == false && left < right) {
                left += 1;
            }

            while (acceptedVowels.Contains(sReversedVowels[right]) == false && left < right) {
                right -= 1;
            }

            if (left >= right) {
                break;
            }
            char temp = sReversedVowels[left];
            sReversedVowels[left] = sReversedVowels[right];
            sReversedVowels[right] = temp;
            left += 1;
            right -= 1;            
        }
        return sReversedVowels.ToString();
    }
    public static void Main(string[] args) {
        string result = reverseVowels("IceCreAm");
        System.Console.WriteLine(result);
    }
}