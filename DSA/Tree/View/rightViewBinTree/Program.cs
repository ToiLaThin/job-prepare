//https://www.geeksforgeeks.org/print-right-view-binary-tree-2/?ref=gcse_ind
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

    public static void rightViewDFS(TreeNode root, SortedDictionary<int, int> dict, int currDepth) {
        if (root == null) {
            return;
        }
        if (dict.ContainsKey(currDepth) == false) {
            dict.Add(currDepth, root.val);
        }
        else {
            dict[currDepth] = root.val;
        }
        rightViewDFS(root.left, dict, currDepth + 1);
        rightViewDFS(root.right, dict, currDepth + 1);
    }

    public static void rightViewDFS(TreeNode root, ref int currMaxDepth, int currDepth) {
        if (root == null) {
            return;
        }
        if (currDepth > currMaxDepth) {
            System.Console.Write(root.val + " ");
            currMaxDepth = currDepth;
        }
        //right before left, that way we can use write the first node reach that depth
        rightViewDFS(root.right, ref currMaxDepth, currDepth + 1);
        rightViewDFS(root.left, ref currMaxDepth, currDepth + 1);
    }

    //this keep track the node count of each level
    public static void rightViewBFS(TreeNode root) {
        if (root == null) {
            return;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int currLevelNodes = queue.Count;
            //traverse through all the nodes of current level
            TreeNode currNode = null;
            for (int i = 0; i< currLevelNodes; i++) {
                currNode = queue.Dequeue();
                
                if (currNode.left != null) {
                    queue.Enqueue(currNode.left);
                }

                if (currNode.right != null) {
                    queue.Enqueue(currNode.right);
                }

                System.Console.Write(currNode.val + " ");
            }
            // print(currNode.val + " "); //end of the loop currNode is rightMost node of this level
            System.Console.WriteLine();
        }
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
        rightViewDFS(root, dict, 1);
        var dictNodeValues = dict.Values;
        foreach (var nodeVal in dictNodeValues) 
        {
            System.Console.WriteLine(nodeVal);
        }

        int initMaxDepth = 0;
        rightViewDFS(root,ref initMaxDepth, 1);
        System.Console.WriteLine();

        rightViewBFS(root);
    }
}