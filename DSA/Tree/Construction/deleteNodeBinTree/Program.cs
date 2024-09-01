// https://www.geeksforgeeks.org/deletion-binary-tree/

using System;
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

    public static void inOrderTraversal(TreeNode root) {
        if (root == null) {
            return;
        }
        inOrderTraversal(root.left);
        System.Console.Write(root.data + " ");
        inOrderTraversal(root.right);
    }

    //Time complexity: O(n + d) where n is the number of nodes in the binary tree, d is the depth of the binary tree
    //Space complexity: O(n) where n is the number of nodes in the binary tree
    public static void deleteNodeBinTree(TreeNode root, int keyOfNodeToDelete) {
        if (root == null) {
            return;
        }
        if (root.left == null && root.right == null) {
            if (root.data != keyOfNodeToDelete) {
                return;
            }
            root = null;
            return;
        }

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        TreeNode temp = null;
        TreeNode nodeToDel = null;
        while (q.Count != 0) {
            temp = q.Dequeue();
            if (temp.data == keyOfNodeToDelete) {
                nodeToDel = temp;
            }
            if (temp.left != null) {
                q.Enqueue(temp.left);
            }
            if (temp.right != null) {
                q.Enqueue(temp.right);
            }
        }
        //temp is the rightmost node at the last level)
        if (nodeToDel != null) {
            //nodeToDel is not really deleted but its data is replaced with the data of the rightmost deepest node, 
            //right most deepest node is deleted
            int x = temp.data;
            deleteRightMostDeepestNode(root, temp);
            nodeToDel.data = x;
        }
    }

    //rightmostDeepest node could be the rightmost of last level (but the LEFT child)
    //for ex:
    //          10
    //         /  \
    //        11   9
    //       / \   /
    //      7  12 15

    //delete 11 will replace 11 with 15 and delete 15 (left child of 9) so the rightmost deepest node could be the LEFT CHILD of 9
    //make sure rightmostDeepest node is really exists in the tree and it is not the root node
    private static void deleteRightMostDeepestNode(TreeNode root, TreeNode rightmostDeepestNode) {
        TreeNode temp = root;
        TreeNode parent = null;
        //slow fast pointer technique
        while (temp != rightmostDeepestNode) {
            parent = temp;
            if (temp.right != null) {
                temp = temp.right;
            }
            else if (temp.left != null) {
                temp = temp.left;
            }
            if (temp == rightmostDeepestNode) {
                break;
            }
        }

        if (parent.right == temp) {
            parent.right = null;
            return;
        }
        parent.left = null;

    }
    public static void Main() {
        TreeNode root = new TreeNode(10);
        root.left = new TreeNode(11);
        root.left.left = new TreeNode(7);
        root.left.right = new TreeNode(12);
        root.right = new TreeNode(9);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(8);

        System.Console.WriteLine("Inorder traversal before deletion:");
        inOrderTraversal(root);
        System.Console.WriteLine();
        deleteNodeBinTree(root, 11);
        deleteNodeBinTree(root, 8);
        System.Console.WriteLine("Inorder traversal after deletion:");
        inOrderTraversal(root);
    }
}