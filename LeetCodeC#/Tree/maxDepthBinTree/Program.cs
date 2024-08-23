// Given the root of a binary tree, return its maximum depth.
// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

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
    public static int maxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int leftSubTreeDepth = maxDepth(root.left);
        int rightSubTreeDepth = maxDepth(root.right);

        if (leftSubTreeDepth > rightSubTreeDepth) {
            return leftSubTreeDepth + 1;
        } else {
            return rightSubTreeDepth + 1;
        }
    }

    public static void Main() {
        // TreeNode root = new TreeNode(3);
        // root.left = new TreeNode(9);
        // root.right = new TreeNode(20);
        // root.right.left = new TreeNode(15);
        // root.right.right = new TreeNode(7);

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);

        int result = maxDepth(root);
        System.Console.WriteLine(result);
    }
}