// https://www.geeksforgeeks.org/zigzag-tree-traversal/

using System;
public class Program {
    public class TreeNode {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int data) {
            this.data = data;
            left = null;
            right = null;
        }
    }    

    private static void pushNextLevelStackStrategy(bool leftToRightNextLevel, TreeNode currNode, Stack<TreeNode> nextLevelStack) {
        if (leftToRightNextLevel == true) {
            if (currNode.right != null) {
                nextLevelStack.Push(currNode.right);
            }
            if (currNode.left != null) {
                nextLevelStack.Push(currNode.left);
            }
        }
        else {
            if (currNode.left != null) {
                nextLevelStack.Push(currNode.left);
            }
            if (currNode.right != null) {
                nextLevelStack.Push(currNode.right);
            }
        }
    }
    public static void zigzagTraversal(TreeNode root) {
        if (root == null) {
            return;
        }

        Stack<TreeNode> currentLevelStack = new Stack<TreeNode>();
        Stack<TreeNode> nextLevelStack = new Stack<TreeNode>();
        bool leftToRightNextLevel = false;

        currentLevelStack.Push(root);
        while (true) {
            while (true) {
                TreeNode temp = currentLevelStack.Pop();
                System.Console.Write(temp.data + " ");
                pushNextLevelStackStrategy(leftToRightNextLevel, temp, nextLevelStack);
                if (currentLevelStack.Count == 0) {
                    break;
                }
            }

            if (nextLevelStack.Count == 0) {
                break;
            }

            System.Console.WriteLine();
            leftToRightNextLevel = !leftToRightNextLevel;
            Stack<TreeNode> tempStack = currentLevelStack;
            currentLevelStack = nextLevelStack;
            nextLevelStack = tempStack;
        }
    }

    public static void Main(string[] args) {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(7);
        root.left.right = new TreeNode(6);
        root.right.left = new TreeNode(5);
        root.right.right = new TreeNode(4);

        // 1
        // 2 3
        // 7 6 5 4

        //traversal result should be 1 3 2 7 6 5 4
        Console.WriteLine("Zigzag Traversal of binary tree is ");
        zigzagTraversal(root);
    }
}