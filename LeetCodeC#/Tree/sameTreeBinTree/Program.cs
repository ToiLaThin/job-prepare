//https://leetcode.com/problems/same-tree/description/

using System;
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
        if (p == null &&  q == null) {
            return true;
        }

        if (p == null || q == null) {
            return false;
        }

        if (p.value != q.value) {
            return false;
        }

        return isSameTreeDFS(p.left, q.left) && isSameTreeDFS(p.right, q.right);
    }

    //number of node in each tree is different
    //memory 42.29mb beat 80.54%
    public static bool isSameTreeBFS(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        }

        if (p == null || q == null) {
            //both is null checked before so if one of two is null, return false
            return false;
        }

        Queue<TreeNode> qP = new Queue<TreeNode>();
        Queue<TreeNode> qQ = new Queue<TreeNode>();

        qP.Enqueue(p);
        qQ.Enqueue(q);

        while (true) {
            if (qP.Count == 0 && qQ.Count == 0) {
                return true;
            }

            TreeNode tempP = qP.Dequeue();
            TreeNode tempQ = qQ.Dequeue();

            bool rightOfRootOneIsNullTheOtherNotNull = (tempP.right == null && tempQ.right != null) || (tempP.right != null && tempQ.right == null);
            bool leftOfRootOneIsNullTheOtherNotNull = (tempP.left == null && tempQ.left != null) || (tempP.left != null && tempQ.left == null);
            bool rightOfRootBothNotNull = (tempP.right != null && tempQ.right != null);
            bool leftOfRootBothNotNull = (tempP.left != null && tempQ.left != null);
            if (tempP.value != tempQ.value) {
                return false;
            }

            if (leftOfRootOneIsNullTheOtherNotNull) {
                return false;
            }

            if (rightOfRootOneIsNullTheOtherNotNull) {
                return false;
            }

            if (leftOfRootBothNotNull == true) {
                qP.Enqueue(tempP.left);
                qQ.Enqueue(tempQ.left);
            }

            if (rightOfRootBothNotNull == true) {
                qP.Enqueue(tempP.right);
                qQ.Enqueue(tempQ.right);
            }
        }
    }

    public static void Main() {
        TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode q = new TreeNode(1, new TreeNode(2), new TreeNode(3));

        // TreeNode p = new TreeNode(1, new TreeNode(2), null);
        // TreeNode q = new TreeNode(1, null, new TreeNode(2));

        // TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(1));
        // TreeNode q = new TreeNode(1, new TreeNode(1), new TreeNode(2));
        Console.WriteLine(isSameTreeBFS(p, q));
    }
}