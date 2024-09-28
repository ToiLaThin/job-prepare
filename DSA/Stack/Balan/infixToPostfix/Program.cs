//https://www.geeksforgeeks.org/convert-infix-expression-to-postfix-expression/

using System.Collections.Generic;
public class Program {

    private static int getPrecedenceOf(char operatorChar) {
        if (operatorChar == '+' || operatorChar == '-') {
            return 1;
        }
        if (operatorChar == '*' || operatorChar == '/') {
            return 2;
        }
        return 0;
    }

    //time: O(n) number of char in infix expression
    //space: O(m): m number of operator
    //this is ONLY for single digit number
    public static string infixToPostfix(string infix) {
        string postfix = "";
        Stack<char> operatorMonoStack = new Stack<char>(); //store operator & ()

        for (int i = 0; i < infix.Length; i++) {
            if (infix[i] == '+' || infix[i] == '-' || infix[i] == '*' || infix[i] == '/') {
                while (operatorMonoStack.Count > 0 && getPrecedenceOf(infix[i]) <= getPrecedenceOf((char)operatorMonoStack.Peek())) {
                    postfix += operatorMonoStack.Pop();
                }
                operatorMonoStack.Push(infix[i]); //now stack empty OR if push we still maintain increasing precedence
                continue;
            }

            if (infix[i] == '(') {
                operatorMonoStack.Push(infix[i]);
                continue;
            }

            if (infix[i] == ')') {
                while (operatorMonoStack.Count > 0 && operatorMonoStack.Peek() != '(') {
                    postfix += operatorMonoStack.Pop();
                }
                operatorMonoStack.Pop(); //pop the (
                continue;
            }
            if (infix[i] >= '1' && infix[i] <= '9') {
                postfix += infix[i];
            }
        }

        //empty the if operator left in stack
        while (operatorMonoStack.Count > 0) {
            postfix += operatorMonoStack.Pop();
        }
        return postfix;
    }
    public static void Main(string[] args) {
        string infix = "1 + 2 * 3 + 4";
        // string infix = "(1 + 2) * 3 + 4";
        string postfix = infixToPostfix(infix);
        System.Console.WriteLine(postfix);
    }
}