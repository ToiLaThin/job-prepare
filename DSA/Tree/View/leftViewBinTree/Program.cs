//https://www.geeksforgeeks.org/print-left-view-binary-tree/
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

    public static void InOrder(TreeNode root) {
        if (root == null) {
            return;
        }
        InOrder(root.left);
        System.Console.Write(root.val + " ");
        InOrder(root.right);

    }

    public static void leftViewDFS(TreeNode root, SortedDictionary<int, int> dict, int currDepth) {
        if (root == null) {
            return;
        }

        if (!dict.ContainsKey(currDepth)) {
            dict.Add(currDepth, root.val);
        }
        leftViewDFS(root.left, dict, currDepth + 1);
        leftViewDFS(root.right, dict, currDepth + 1);
    }

     public static void leftViewDFSMaxDepth(TreeNode root,ref int currMaxDepth, int currDepth) {
        if (root == null) {
            return;
        }
        if (currDepth > currMaxDepth) {
            System.Console.Write(root.val + " ");
            currMaxDepth = currDepth;
        }
        leftViewDFSMaxDepth(root.left, ref currMaxDepth, currDepth + 1);
        leftViewDFSMaxDepth(root.right, ref currMaxDepth, currDepth + 1);
    }

    public static void Main(string[] args) {
        // TreeNode root = new TreeNode(1);
        // root.left = new TreeNode(2);
        // root.right = new TreeNode(3);
        // root.left.left = new TreeNode(4);
        // root.left.right = new TreeNode(5);

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.right.left = new TreeNode(4);
        root.right.left.right = new TreeNode(5);

        SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
        leftViewDFS(root, dict, 1);
        var dictNodeValues = dict.Values;
        foreach (var nodeVal in dictNodeValues) 
        {
            System.Console.WriteLine(nodeVal);
        }

        int initMaxDepth = 0;
        leftViewDFSMaxDepth(root,ref initMaxDepth, 1);
        System.Console.WriteLine();
    }
}