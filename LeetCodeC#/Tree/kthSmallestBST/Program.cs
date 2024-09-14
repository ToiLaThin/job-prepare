//https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/
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

    //this is wrong since we can move right
    public static int kthSmallestWrong(TreeNode root, int k) {
        if (root == null) {
            return -1;
        }

        TreeNode slow = root;
        TreeNode fast = root;
        for (int time = 1; time <= k; time++) {
            if (fast.left == null) {
                fast = fast.right;
                continue;
            }
            fast = fast.left;
        }

        while (fast != null) {
            //move fast & slow at the same time with same speed
            if (slow.left == null) {
                slow = slow.right;
                goto fastMove;
            }
            slow = slow.left;

            fastMove:
            if (fast.left == null) {
                fast = fast.right;
                continue;
            }
            fast = fast.left;
        }

        return slow.val;
    }

    //use DFS inorder
    //Time O(k)
    //Space O(h) hay O(log n)
    private static int Inorder(TreeNode root, ref int kTemp, int k) {
        if (root == null) {
            return -1; //value range is 0 - 10^4
        }

        int result = -1;
        result = Inorder(root.left, ref kTemp, k);
        //if we found kth smallest on root 's left child, pass result to root parent
        if (result != -1) {
            return result;
        }

        //when backtrack we increase kTemp, not when we go down root childs
        kTemp += 1;
        if (kTemp == k) {
            return root.val;
        }

        result = Inorder(root.right, ref kTemp, k);
        //if we found kth smallest on root 's right child, pass result to root parent
        if (result != -1) {
            return result;
        }
        return -1;
    }

    //another approach take O(2n) time & O(n) space is use list to store node when inorder, then traverse list for k time
    private static int kthSmallest(TreeNode root, int k) {
        int kTemp = 0;
        return Inorder(root, ref kTemp, k);
    }
    public static void Main(string[] args) {
        // TreeNode root = new TreeNode(3);
        // root.right = new TreeNode(4);
        // root.left = new TreeNode(1);
        // root.left.right = new TreeNode(2);

        TreeNode root = new TreeNode(5);
        root.right = new TreeNode(6);
        root.left = new TreeNode(3);
        root.left.right = new TreeNode(4);
        root.left.left = new TreeNode(2);
        root.left.left.left = new TreeNode(1);

        System.Console.WriteLine(kthSmallest(root, 3));
    }
}