//https://www.geeksforgeeks.org/insertion-in-a-binary-tree-in-level-order/

using System;
public class Program {
    public class TreeNode {
        public int data;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int data = 0, TreeNode left = null, TreeNode right = null) {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }


    // Time complexity: O(n) with n is the number of nodes in the tree
    // Space complexity: O(b) with b is the maximum number of nodes at any level in the binary tree
    // this help tree be balanced because the number of nodes at the last level is 2^h
    public static TreeNode insertNode(int key, TreeNode root) {
        if (root == null) {
            return new TreeNode(key);
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            TreeNode temp = queue.Dequeue();
            if (temp.left == null) {
                temp.left = new TreeNode(key);
                break;
            }
            if (temp.right == null) {
                temp.right = new TreeNode(key);
                break;
            }
            else {
                queue.Enqueue(temp.left);
                queue.Enqueue(temp.right);
            }
        }
        return root;
    }

    public static void inorderTraversal(TreeNode root) {
        if (root == null) {
            return;
        }
        inorderTraversal(root.left);
        Console.Write(root.data + " ");
        inorderTraversal(root.right);
    }
    public static void Main() {
        TreeNode root = new TreeNode(10);
        root.left = new TreeNode(11);
        root.left.left = new TreeNode(7);
        root.right = new TreeNode(9);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(8);

        Console.WriteLine("inorderTraversal traversal before insertion:");
        inorderTraversal(root);

        int key = 12;
        insertNode(key, root);

        Console.WriteLine();
        Console.WriteLine("inorderTraversal traversal after insertion:");
        inorderTraversal(root);
    }
}