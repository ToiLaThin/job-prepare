//https://www.geeksforgeeks.org/insertion-in-binary-search-tree/

//Search, Insert, Delete
//https://www.geeksforgeeks.org/problems/top-view-of-binary-tree/1?ref=gcse_ind
//https://www.geeksforgeeks.org/print-nodes-top-view-binary-tree/
using System;
using System.Collections.Generic;

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

    public static TreeNode InsertBSTRecursively(TreeNode root, int key) {
        if (root == null) {
            return new TreeNode(key);
        }

        if (root.val == key) {
            return root;
        }

        if (key > root.val) {
            root.right = InsertBSTRecursively(root.right, key);
        }

        if (key < root.val) {
            root.left = InsertBSTRecursively(root.left, key);
        }

        return root;
    }

    public static TreeNode InsertBSTSlowFast(TreeNode root, int key) {
        if (root == null) {
            return new TreeNode(key);
        }

        if (root.val == key) {
            return root;
        }

        TreeNode slow = null;
        TreeNode fast = root;
        while (fast != null) {
            if (key > fast.val) {
                slow = fast;
                fast = fast.right;    
                continue;
            }
            if (key < fast.val) {
                slow = fast;
                fast = fast.left;
            }
        }
        
        if (key > slow.val) {
            slow.right = new TreeNode(key);
        }
        else {
            slow.left = new TreeNode(key);
        }

        return root;
    }

    public static TreeNode SearchBSTRecursively(TreeNode root, int key) {
        if (root == null || root.val == key) {
            return root;
        }

        if (key > root.val) {
            return SearchBSTRecursively(root.right, key);
        }

        return SearchBSTRecursively(root.left, key);
    }
    public static void InOrder(TreeNode root) {
        if (root == null) {
            return;
        }
        InOrder(root.left);
        System.Console.WriteLine(root.val);
        InOrder(root.right);
    }
    public static void Main(string[] args) {
        TreeNode root = new TreeNode(1);
        InsertBSTSlowFast(root, 5);
        InsertBSTSlowFast(root, 4);
        InsertBSTSlowFast(root, 3);
        InsertBSTSlowFast(root, 11);

        InOrder(root);

        TreeNode find = SearchBSTRecursively(root, 100);
        if (find == null) {
            System.Console.WriteLine("No item in BST");
        }
        else {
            System.Console.WriteLine(find.val);
        }
    }
}