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

    //https://www.geeksforgeeks.org/deletion-in-binary-search-tree/
    public static TreeNode DeleteDFS(TreeNode root, int key) {
        if (root == null) {
            return null;
        }

        //root is node to deleted
        if (root.val == key) {
            if (root.left == null & root.right == null) {
                return null; //root is leaf node, set it to null
            }
            if (root.left == null) {
                return root.right; //root is replaced by its right child
            }

            if (root.right == null) {
                return root.left; //root is replaced by its left child
            }
            //not need to recurse DeleteDFS for new key
            Tuple<TreeNode, TreeNode> tuple = GetRightSuccessorAndItsParent(root);
            TreeNode successor = tuple.Item1;
            TreeNode successorParent = tuple.Item2;
            root.val = successor.val;
            successorParent.left = null; //successor is left child of successorParent on the right subtree of root
        }

        //node to delete in left => recursive in left
        if (key < root.val) {
            root.left = DeleteDFS(root.left, key);
        }
        //node to delete in right => recursive in right
        if (key > root.val) {
            root.right = DeleteDFS(root.right, key);
        }
        //if the root is not the node to be deleted, then must return itself for previous DeleteDFS call in recursion
        return root;

    }

    //get the leftmost leaf node on the right subtree of root (node smallest in right subtree but larger than all node in leftsubtree of current root)
    private static Tuple<TreeNode, TreeNode> GetRightSuccessorAndItsParent(TreeNode root) {
        TreeNode temp = root.right;
        TreeNode previous = root;
        while (temp.left != null) {
            previous = temp;
            temp = temp.left;
        }
        return Tuple.Create(temp, previous);
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

        DeleteDFS(root, 3);
        InOrder(root);

    }
}