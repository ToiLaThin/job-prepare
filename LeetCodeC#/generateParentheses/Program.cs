// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
// Example 1:
// Input: n = 3
// Output: ["((()))","(()())","(())()","()(())","()()()"]
// Example 2:

// Input: n = 1
// Output: ["()"]
 

// Constraints:

// 1 <= n <= 8

//openBrac == closeBrac == n: return the string
//backtrack
//openBrac < n: continue exec
//n > openBrac > closeBrack: 
//visit openBrac + 1, closeBrac, add "("
//visit openBrac, closeBrac + 1, add ")"

using System;
using System.Collections.Generic;

//beat 70% of c# submission
IList<string> generateParenthesis(int n) {
    var result = new List<string>();
    backTrack(result, "", 0, 0, n);
    return result;
}

void backTrack(IList<string> result, string currentStr, int nOpenBrac, int nCloseBrac, int n) {
    if (nOpenBrac == n && nCloseBrac == nOpenBrac) {
        result.Add(currentStr);
        return;
    }

    if (nOpenBrac < nCloseBrac || nOpenBrac > n) {
        return;
    }

    if (nOpenBrac == nCloseBrac) {
        backTrack(result, currentStr + "(", nOpenBrac + 1, nCloseBrac, n);
    } else if (nOpenBrac > nCloseBrac) {
        backTrack(result, currentStr + "(", nOpenBrac + 1, nCloseBrac, n);
        backTrack(result, currentStr + ")", nOpenBrac, nCloseBrac + 1, n);
    }
}
var re = generateParenthesis(3);
foreach (var paren in re) {
    Console.WriteLine(paren);
}