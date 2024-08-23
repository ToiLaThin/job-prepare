// Given the root of a binary tree, invert the tree, and return its root.

// Input: root = [4,2,7,1,3,6,9]
// Output: [4,7,2,9,6,3,1]

using System.Diagnostics.Contracts;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public static TreeNode invertBinTree(TreeNode root) {
        if (root == null) {
            return null;
        }

        TreeNode right = invertBinTree(root.right);
        TreeNode left = invertBinTree(root.left);

        root.left = right;
        root.right = left;
        return root;
    }
    public static void Main() {
        TreeNode root = new TreeNode(4);
        root.left = new TreeNode(2);
        root.right = new TreeNode(7);
        root.left.left = new TreeNode(1);
        root.left.right = new TreeNode(3);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(9);

        TreeNode result = invertBinTree(root);
        Stack<int> stack = new Stack<int>();
        while (result != null) {
            stack.Push(result.val);
            result = result.left;
        }

        while (stack.Count > 0) {
            System.Console.WriteLine(stack.Pop());
        }
    }
}