//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

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

    //assume that p.val < q.val
    //all node val is unique, p != q and they exist in BST
    public static TreeNode lowestCommonAncestorBST(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) {
            return null;
        }
        TreeNode small = null;
        TreeNode large = null;
        if (p.val < q.val) {
            small = p;
            large = q;
        }
        else {
            small = q;
            large = p;
        }
        TreeNode temp = root;

        //just move the temp until small <= temp <= large
        while (true) {
            if (temp.val < small.val) {
                temp = temp.right;
            }
            else if (temp.val > large.val) {
                temp = temp.left;
            }
            else { //if equal either small, or left, return itself
                return temp;
            }
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

    public static void InOrder(TreeNode root) {
        if (root == null) {
            return;
        }
        InOrder(root.left);
        Console.Write(root.val + " ");
        InOrder(root.right);
    }
    public static void Main(string[] args) {
        TreeNode root = new TreeNode(5);
        InsertBSTRecursively(root, 3);
        InsertBSTRecursively(root, 8);
        InsertBSTRecursively(root, 1);
        InsertBSTRecursively(root, 4);
        InsertBSTRecursively(root, 2);
        InsertBSTRecursively(root, 7);
        InsertBSTRecursively(root, 9);

        InOrder(root);
        System.Console.WriteLine();

        var result = lowestCommonAncestorBST(root, root.left, root.left.right);
        System.Console.WriteLine(result.val);
    }
}