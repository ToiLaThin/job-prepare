// https://www.youtube.com/watch?v=pMfoyc6zmZo
// https://www.geeksforgeeks.org/introduction-to-red-black-tree/?ref=shm
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

    public static TreeNode rotateLeft(TreeNode root) {
        if (root == null) {
            return null;
        }
        if (root.right == null) {
            return root; //do nothing, root.right will be new root
        }

        TreeNode rootMovedSubTree = root.right.left; //left subtree will be moved, because new root(curr root.right) left will be root
        TreeNode newRoot = root.right;
        newRoot.left = root;
        root.right = rootMovedSubTree;
        return newRoot;
    }

    public static TreeNode rotateRight(TreeNode root) {
        if (root == null) {
            return null;
        }
        if (root.left == null) {
            return root;
        }

        //root.left will be new root
        TreeNode rootMovedSubTree = root.left.right;
        TreeNode newRoot = root.left;
        newRoot.right = root;
        root.left = rootMovedSubTree;
        return newRoot;
    }


    public static void Inorder(TreeNode root) {
        if (root == null) {
            return;
        }
        Inorder(root.left);
        System.Console.Write(root.val + " ");
        Inorder(root.right);
    }

    public static void Main(string[] args) {
        //rotate BST
        TreeNode root = new TreeNode(9);
        root.right = new TreeNode(12);
        root.left = new TreeNode(4);
        root.left.right = new TreeNode(7);
        root.left.left = new TreeNode(2);
        root.left.left.left = new TreeNode(1);

        TreeNode newRoot = rotateRight(root);
        newRoot = rotateRight(newRoot);
        System.Console.WriteLine(newRoot.val);
        Inorder(newRoot); //1 2 4 7 9 12

    }
}