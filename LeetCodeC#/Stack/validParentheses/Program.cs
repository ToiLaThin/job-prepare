using System;
using System.Collections.Generic;

bool isValidParentheses(string s) {
    Stack<char> stack = new Stack<char>();
    for (int i = 0; i < s.Length; i++) {
        if (s[i] == '(' || s[i] == '[' || s[i] == '{') {
            stack.Push(s[i]);
        }
        else {
            //close bracket
            if (stack.Count == 0) {
                //no open bracket to match current close bracket
                return false;
            }
            char top = stack.Pop();
            //open bracket type not match current close bracket
            if (s[i] == ')' && top != '(') {
                System.Console.WriteLine("Case 1");
                return false;
            }

            if (s[i] == '[' && top != ']') {
                return false;
            }

            if (s[i] == '{' && top != '}') {
                return false;
            }
        }
    }

    return stack.Count == 0;
}

// string str = "()[]{}";
// string str = "([)]";
string str = ")(){}";
System.Console.WriteLine(isValidParentheses(str));
