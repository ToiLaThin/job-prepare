// Given a binary tree, determine if it is 
// height-balanced.

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

    public static bool isBalanced(TreeNode root) {
        return height(root) != -1;
    }

    public static int height(TreeNode root) {
        if (root == null) {
            return 0;
        }
        int left = height(root.left);
        int right = height(root.right);
        if (left == -1 || right == -1) {
            return -1; //PROPAGATE UNBALANCED
        }

        if (Math.Abs(left - right) > 1) {
            return -1;
        }

        return Math.Max(left, right) + 1;
    }
    public static void Main() {
        TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
        Console.WriteLine(isBalanced(root)); //True
    }
}