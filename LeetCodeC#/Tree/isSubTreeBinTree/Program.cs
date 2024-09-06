// https://leetcode.com/problems/subtree-of-another-tree/description/

public class Program {
    public class TreeNode {
        public int value;

        public TreeNode left;

        public TreeNode right;

        public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null) {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }

    public static bool isSameTreeDFS(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        }

        if (p == null || q == null) {
            return false;
        }

        return isSameTreeDFS(p.right, q.right) && isSameTreeDFS(p.left, q.left);
    }

    public static bool isSubTree(TreeNode root, TreeNode subRoot) {
        //find the node in root with same value as subRoot
        if (root == null) {
            return false;
        }

        TreeNode findSubRootValNode = null;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0) {
            TreeNode temp = q.Dequeue();
            if (temp.value == subRoot.value) {
                findSubRootValNode = temp;
                //break; //do not break to find the last node with that value, because 1 tree can have multiple node with value: 1
                //but if we take the last value, we might miss the previous value that match
                //[1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,2]
                //[1,null,1,null,1,null,1,null,1,null,1,2]

                //this should be true but this approach it return false
            }
            if (temp.left != null) {
                q.Enqueue(temp.left);
            }

            if (temp.right != null) {
                q.Enqueue(temp.right);
            }
        }

        //cannot find the node with  subRoot value in subtree of root
        if (findSubRootValNode == null) {
            return false;
        }

        //then call it p, and subRoot is q, we check isSameTreeDFS for p & q
        return isSameTreeDFS(findSubRootValNode, subRoot);

    }

    public static bool isSubTreeDFS(TreeNode root, TreeNode subRoot) {
        if (root == null && subRoot != null) {
            return false;
        }

        if (root == null && subRoot == null) {
            return false;
        }

        //root is not null but subRoot is null, return false
        if (subRoot == null) {
            return false;
        }

        if (root.value == subRoot.value && isSubTreeDFS(root.left, subRoot.left) && isSubTreeDFS(root.right, subRoot.right)) {
            return true;
        };
        return isSubTreeDFS(root.right, subRoot) || isSubTreeDFS(root.left, subRoot);
    }
    public static void Main(string[] args) {
        // TreeNode root = new TreeNode(3);
        // root.right = new TreeNode(5);
        // root.left = new TreeNode(4);
        // root.left.right = new TreeNode(2);
        // root.left.right.left = new TreeNode(0);
        // root.left.left = new TreeNode(1);

        // TreeNode subRoot = new TreeNode(4);
        // subRoot.right = new TreeNode(2);
        // subRoot.left = new TreeNode(1);

        //[1, 1] & [1] return true, not false
        // TreeNode root = new TreeNode(1);
        // root.left = new TreeNode(1);

        // TreeNode subRoot = new TreeNode(1);


        //[3,4,5,1,null,2]
        //[3,1,2]
        //exptect false, reality: true
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(4);
        root.right = new TreeNode(5);
        root.left.left = new TreeNode(1);
        root.right.left = new TreeNode(2);

        TreeNode subRoot = new TreeNode(3);
        subRoot.left = new TreeNode(1);
        subRoot.right = new TreeNode(2);

        System.Console.WriteLine(isSubTreeDFS(root, subRoot));
    }
}