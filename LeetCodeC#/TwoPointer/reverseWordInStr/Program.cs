//https://leetcode.com/problems/reverse-words-in-a-string/description/

public class Program {
    //O(n^2) because of loop & substring
    public static string ReverseWords(string input) {
        string temp  = input;
        string result = "";
        int i, j;
        string word;
        while (true) {
            //move to index char is not ' '
            j = temp.Length - 1;
            while (j > 0 && temp[j] == ' ') {
                j--;
            }        
            if (j == 0 && temp[j] == ' ') {
                break;
            }
            temp = temp.Substring(0, j + 1);

            ////move to index char is ' ', get the word
            i = temp.Length - 1;
            while (i > 0 && temp[i] != ' ') {
                i--;
            }
            word = (i == 0 && temp[i] != ' ') ? temp.Substring(i) : temp.Substring(i + 1); //i + 1 -> length - 1
            result = result + " " + word;
            if (i == 0) {
                break;
            }
            temp = temp.Substring(0, i + 1); //0 -> i
            // System.Console.WriteLine("Word: " + word);
            // System.Console.WriteLine("Now temp is: " + temp);
        }
        return result.Trim(); //case " result" because of first + " "
    }
    public static void Main(string[] args) {
        // string s = "a  hello world";
        string s = " asdasd df f";
        string result = ReverseWords(s);
        System.Console.WriteLine(result);
    }
}