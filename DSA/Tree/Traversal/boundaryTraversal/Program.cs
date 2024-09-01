//https://www.geeksforgeeks.org/boundary-traversal-of-binary-tree/

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

    private static void leftBoundaryTraversal(TreeNode root) {
        if (root == null) {
            return;
        }

        if (root.left == null && root.right == null) {
            //skip the leaf nodes
            return;
        }

        System.Console.Write(root.data + " ");
        if (root.left != null) {
            leftBoundaryTraversal(root.left);
        }
        else if (root.right != null) {
            leftBoundaryTraversal(root.right);
        }
    }

    private static void rightBoundaryTraversal(TreeNode root) {
        if (root == null) {
            return;
        }

        if (root.right != null) {
            rightBoundaryTraversal(root.right);
            System.Console.Write(root.data + " ");
        }
        else if (root.left != null) {
            rightBoundaryTraversal(root.left);
            System.Console.Write(root.data + " ");
        }
        else {
            //skip the leaf nodes
            return;
        }
    }

    private static void leafTraversal(TreeNode root) {
        if (root == null) {
            return;
        }

        if (root.left == null && root.right == null) {
            System.Console.Write(root.data + " ");
            return;
        }

        leafTraversal(root.left);
        leafTraversal(root.right);
    }

    public static void boundaryTraversal(TreeNode root) {
        leftBoundaryTraversal(root);
        leafTraversal(root.left); //leaf of left subtree from left to right
        leafTraversal(root.right); //leaf of right subtree from left to right
        rightBoundaryTraversal(root.right);
    }
    public static void Main() {
        TreeNode root = new TreeNode(20);
        root.left = new TreeNode(8);
        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(12);
        root.left.right.left = new TreeNode(10);
        root.left.right.right = new TreeNode(14);
        root.right = new TreeNode(22);
        root.right.right = new TreeNode(25);

        //visualization of the tree
        //          20
        //         /  \
        //        8    22
        //       / \     \
        //      4  12     25
        //         / \
        //        10 14

        //Output: 20 8 4 10 14 25 22
        boundaryTraversal(root);
    }
}