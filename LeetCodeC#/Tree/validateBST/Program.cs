// https://leetcode.com/problems/validate-binary-search-tree/description/
//https://www.enjoyalgorithms.com/blog/validate-binary-search-tree
public class Program {
    public class TreeNode {
        public int val;
        public TreeNode right;
        public TreeNode left;
        public TreeNode(int val = 0, TreeNode right = null, TreeNode left = null) {
            this.val = val;
            this.right = right;
            this.left = left;
        }
    }

    //the idea is inorder traversal: we must make sure the value before less than curr value
    //Time: O(n) n number of node
    //Space: O(h) h height of tree call stack
    public static void inOrderValidateBST(TreeNode root, ref TreeNode prevNode,ref bool result) {
        //do nothing
        if (root == null) {
            return;
        }

        inOrderValidateBST(root.left, ref prevNode, ref result);
        if (result == false) {
            return;
        }

        if (prevNode != null && prevNode.val >= root.val) {
            result = false;
            return;
        }

        //case prev == null => result = true or prev != null and condition match
        result = true;
        prevNode = root;
        inOrderValidateBST(root.right, ref prevNode, ref result);
        if (result == false) {
            return;
        }
    }

    public static bool isValidBST(TreeNode root) {
        bool result = true;
        TreeNode prev = null;
        inOrderValidateBST(root, ref prev, ref result);
        return result;
    }

    public static bool isValidBSTPreorder(TreeNode root) {
        System.Console.WriteLine(long.MinValue);
        System.Console.WriteLine(long.MinValue);
        return preorerValidateBST(root, long.MinValue, long.MaxValue);
    }

    //Time: O(n) n number of node
    //Space: O(h) h height of tree call stack
    public static bool preorerValidateBST(TreeNode root, long left, long right) {
        if (root == null) {
            return true;
        }

        //preorder
        if (!(root.val > left && root.val < right)) {
            return false;
        }

        return preorerValidateBST(root.left, left, root.val) && preorerValidateBST(root.right, root.val, right);
    }

    public static void Main(string[] args) {
        // TreeNode root = new TreeNode(2);
        // root.right = new TreeNode(3);
        // root.left = new TreeNode(1);

        // TreeNode root = new TreeNode(1);
        // root.left = new TreeNode(1);

        // TreeNode root = new TreeNode(5);
        // root.right = new TreeNode(4);
        // root.left = new TreeNode(1);
        // root.right.left = new TreeNode(3);
        // root.right.right = new TreeNode(6);

        TreeNode root = new TreeNode(2147483647);

        System.Console.WriteLine(isValidBSTPreorder(root));
    }
}