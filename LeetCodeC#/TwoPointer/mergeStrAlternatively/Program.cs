//https://leetcode.com/problems/merge-strings-alternately/description/?envType=study-plan-v2&envId=leetcode-75

public class Program {
    public static string mergeAlternatively(string word1, string word2) {
        int p1 = 0;
        int p2 = 0;
        bool w1Turn = true;
        string wordMerged = string.Empty;
        while (true) {
            if (w1Turn) {
                wordMerged += word1[p1];
                p1 += 1;
            }
            if (!w1Turn) {
                wordMerged += word2[p2];
                p2 += 1;
            }
            w1Turn = !w1Turn;
            if (p1 == word1.Length) {
                wordMerged += word2.Substring(p2);
                break;
            }
            if (p2 == word2.Length) {
                wordMerged += word1.Substring(p1);
                break;
            }
        }

        return wordMerged;
    }

    public static void Main(string[] args) {
        // string word1 = "abcd";
        // string word2 = "pq";
        string word1 = "ab";
        string word2 = "pqrs";
        string result = mergeAlternatively(word1, word2);
        System.Console.WriteLine(result);
    }
}