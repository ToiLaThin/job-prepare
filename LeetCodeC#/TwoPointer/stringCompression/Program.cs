//https://leetcode.com/problems/string-compression/description/?envType=study-plan-v2&envId=leetcode-75

public class Program {

    //works but not modify chars inplace
    public static int compress1(char[] chars) {
        if (chars.Length == 1) {
            return 1;
        }

        int left = 0;
        int right = left + 1;
        string compressed = "";
        bool rightReachEnd = false;
        while (right < chars.Length && left < chars.Length) {
            while (chars[right] == chars[left]) {
                right += 1;
                if (right == chars.Length) {
                    rightReachEnd = true;
                    break;
                }
            }

            int groupLen = (right - left);
            if (groupLen == 1) {
                compressed += chars[left];
                goto checkEnd;
            }
            compressed += chars[left] + groupLen.ToString();

            checkEnd:
            if (rightReachEnd) {
                chars = compressed.ToCharArray();
                return compressed.Length;
            }


            left = right;
            right = left + 1;
        }
        chars = compressed.ToCharArray();
        return compressed.Length;
    }

    //wrong for case char[] chars = { "a","b","c","d","e","f","g","g","g","g","g","g","g","g","g","g","g","g","a","b","c"};
    public static int compress2(char[] chars) {
        if (chars.Length == 1) {
            return 1;
        }
        int l = 0;
        int lastIdxCharsModified = 0;
        int r = -1;

        for (r = 1; r < chars.Length; r++) {
            if (r == chars.Length - 1 && chars[r] == chars[l]) {
                if (r - l  + 1 == 1) {
                    chars[lastIdxCharsModified] = chars[l];
                    Console.WriteLine(chars);
                    return lastIdxCharsModified + 1;
                }

                chars[lastIdxCharsModified] = chars[l];
                lastIdxCharsModified += 1;
                foreach (char numChar in (r - l + 1).ToString()) {
                    chars[lastIdxCharsModified] = numChar;
                    lastIdxCharsModified += 1;
                }
                Console.WriteLine(chars);
                return lastIdxCharsModified;
            }
            
            if (chars[r] == chars[l]) {
                continue;
            }
            //different now
            int groupLen = r - l;
            if (groupLen == 1) {
                chars[lastIdxCharsModified] = chars[l];
                lastIdxCharsModified += 1;
                l = r;                
                continue;
            }

            chars[lastIdxCharsModified] = chars[l];
            lastIdxCharsModified += 1;
            foreach (char numChar in groupLen.ToString()) {
                chars[lastIdxCharsModified] = numChar;
                lastIdxCharsModified += 1;
            }

            l = r;

            if (r == chars.Length - 1) {
                chars[lastIdxCharsModified] = chars[r];
                Console.WriteLine(chars);
                return lastIdxCharsModified + 1;                
            }
        }
        Console.WriteLine(chars);
        return lastIdxCharsModified + 1;

    }

    public static int compress3(char[] chars){
        int r = 0;
        int lastIdxCharsModified = 0;
        while (r < chars.Length) {
            char currentChar = chars[r];
            int groupLen = 0;
            while (r < chars.Length && chars[r] == currentChar) {
                groupLen++;
                r++;
            }

            chars[lastIdxCharsModified] = currentChar;
            lastIdxCharsModified += 1;

            if (groupLen <= 1) {
                continue;
            }
            foreach (char numChar in groupLen.ToString()) {
                chars[lastIdxCharsModified] = numChar;
                lastIdxCharsModified += 1;
            }
        }
        return lastIdxCharsModified;
    }

    public static void Main(string[] args) {
        // char[] chars = { 'a','a','b','b','c','c','c'};
        // char[] chars = { 'a'};
        // char[] chars = { 'a','b','b','b','b','b','b','b','b','b','b','b','b'};
        char[] chars = { 'a','a','a','b','b','a','a'};
        // char[] chars = { 'a','a','a','a','a','b'};
        int result = compress3(chars);
        System.Console.WriteLine(result);
    }
}