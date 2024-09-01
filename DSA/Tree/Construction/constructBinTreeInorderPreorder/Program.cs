// https://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/

using System;
public class Program {
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

    // the return node is root of the built tree
    public static TreeNode BuildTree(int[] preorder, int[] inorder, int preIndex, int inStart, int inEnd) {
        //build root
        if (preIndex >= preorder.Length || inStart > inEnd) {
            return null;
        }
        TreeNode root = new TreeNode(preorder[preIndex]);
        //find root in inorder
        for (int i = inStart; i <= inEnd; i++) {
            if (inorder[i] == root.val) {
                if (i > inStart) {
                    root.left = BuildTree(preorder, inorder, preIndex + 1, inStart, i - 1);
                }
                if (i < inEnd) {
                    root.right = BuildTree(preorder, inorder, preIndex + i - inStart + 1, i + 1, inEnd);
                }
                else {
                    //if instart == inend, it means the root is leaf node
                    break;
                }
            }
        }
        return root;
        
    }

    public static void PrintTree(TreeNode root) {
        if (root == null) {
            return;
        }
        PrintTree(root.left);
        Console.Write(root.val + " ");
        PrintTree(root.right);
    }

    public static void Main() {
        int[] preorder = new int[] {3, 9, 20, 15, 7};
        int[] inorder = new int[] {9, 3, 15, 20, 7};
        TreeNode root = BuildTree(preorder, inorder, 0, 0, inorder.Length - 1);
        //print the tree in inorder
        PrintTree(root);
    }
}