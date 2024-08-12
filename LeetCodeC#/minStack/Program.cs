// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
// Implement the MinStack class:
// MinStack() initializes the stack object.
// void push(int val) pushes the element val onto the stack.
// void pop() removes the element on the top of the stack.
// int top() gets the top element of the stack.
// int getMin() retrieves the minimum element in the stack.
// You must implement a solution with O(1) time complexity for each function.

// Example 1:
// Input
// ["MinStack","push","push","push","getMin","pop","top","getMin"]
// [[],[-2],[0],[-3],[],[],[],[]]

// Output
// [null,null,null,null,-3,null,0,-2]

// Explanation
// MinStack minStack = new MinStack();
// minStack.push(-2);
// minStack.push(0);
// minStack.push(-3);
// minStack.getMin(); // return -3
// minStack.pop();
// minStack.top();    // return 0
// minStack.getMin(); // return -2
 
using System;
using System.Collections.Generic;
public class MinStack {
    Stack<int> stackValues;
    Stack<int> stackMins;
    public MinStack() {
        stackValues = new Stack<int>();
        stackMins = new Stack<int>();
    }

    public void Push(int val) {
        stackValues.Push(val);
        if (stackMins.Count == 0 || val <= stackMins.Peek()) {
            stackMins.Push(val);
        } 
    }

    public void Pop() {
        if (stackValues.Count > 0) {
            int val = stackValues.Pop();
            if (val == stackMins.Peek()) {
                stackMins.Pop();
            }
        }
    }

    public int Top() {
        return stackValues.Peek();
    }

    public int GetMin() {
        return stackMins.Peek();
    }
}

// ["MinStack","push","push","push","getMin","pop","getMin"]
// [[],[0],[1],[0],[],[],[]]

namespace Prep {
    class Program {
        static void Main(string[] args) {
            MinStack minStack = new MinStack();
            // minStack.Push(-2);
            // minStack.Push(0);
            // minStack.Push(-3);
            // Console.WriteLine(minStack.GetMin()); // return -3
            // minStack.Pop();
            // Console.WriteLine(minStack.Top());    // return 0
            // Console.WriteLine(minStack.GetMin()); // return -2

            minStack.Push(0);
            minStack.Push(1);
            minStack.Push(0);
            Console.WriteLine(minStack.GetMin()); // return 0
            minStack.Pop();
            Console.WriteLine(minStack.GetMin()); // return 0

        }
    }
}
