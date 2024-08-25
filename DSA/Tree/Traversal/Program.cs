public class TreeNode {
    public int data;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int data = 0, TreeNode left = null, TreeNode right = null) {
        this.data = data;
        this.left = left;
        this.right = right;
    }
}

public class Program {
    //PreOrder: root, left, right
    //Time complexity: O(n) where n is the number of nodes in the tree
    //Space complexity: O(h) where h is the height of the tree
    //Used to create a copy of the tree
    //Used to get prefix expression of an expression tree
    public static void PreOrder(TreeNode root) {
        if (root == null) return;
        Console.Write(root.data + " ");
        PreOrder(root.left);
        PreOrder(root.right);
    }

    //InOrder: left, root, right
    //Time complexity: O(n) where n is the number of nodes in the tree
    //Space complexity: O(h) where h is the height of the tree
    //Used to get the elements in sorted order in a BST
    //Used to evaluate arithmetic expressions in a tree
    public static void InOrder(TreeNode root) {
        if (root == null) return;
        InOrder(root.left);
        Console.Write(root.data + " ");
        InOrder(root.right);
    }

    //PostOrder: left, right, root
    //Time complexity: O(n) where n is the number of nodes in the tree
    //Space complexity: O(h) where h is the height of the tree
    //Used to delete the tree
    //Used to get postfix expression of an expression tree
    public static void PostOrder(TreeNode root) {
        if (root == null) return;
        PostOrder(root.left);
        PostOrder(root.right);
        Console.Write(root.data + " ");
    }

    //LevelOrder: level by level from left to right
    //Time complexity: O(n) where n is the number of nodes in the tree
    //Space complexity: O(n) where n is the number of nodes in the tree
    //Used to print the tree level by level
    public static void LevelOrder(TreeNode root) {
        if (root == null) {
            return;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            TreeNode current = queue.Dequeue();
            Console.Write(current.data + " ");
            if (current.left != null) {
                queue.Enqueue(current.left);
            }
            if (current.right != null) {
                queue.Enqueue(current.right);
            }
        }
    }

    //visual representation of the tree
    //         1
    //        / \
    //       2   3
    //      / \ / \
    //     4  5 6  7
    public static void Main() {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(7);

        Console.Write("PreOrder: ");
        PreOrder(root);
        Console.WriteLine();

        Console.Write("InOrder: ");
        InOrder(root);
        Console.WriteLine();

        Console.Write("PostOrder: ");
        PostOrder(root);
        Console.WriteLine();

        Console.Write("LevelOrder: ");
        LevelOrder(root);
        Console.WriteLine();
    }
}