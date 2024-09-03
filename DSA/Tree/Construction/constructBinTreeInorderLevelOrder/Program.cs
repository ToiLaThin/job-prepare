//https://www.geeksforgeeks.org/construct-tree-inorder-level-order-traversals/


using System;
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

    // the return node is root of the built tree
    public static TreeNode BuildTree(
        int[] inOrder, 
        int[] levelOrder, 
        int inStart, 
        int inEnd) {
        if (inStart > inEnd) {
            return null;
        }

        if (inStart == inEnd) {
            return new TreeNode(inOrder[inStart]);
        }

        //level order ko lẫn lộn nút của right và left subtree, và chúng nằm xen kẽ nhau, nên ta cần tìm trong inorder
        //inorder sẽ bị giới hạn từ inStart và inEnd, phân đoạn này thuộc left/right subtree, nên nếu levelOrder element đầu tiên được tìm tìm thấy trong inorder sẽ là root
        bool foundRootSubTree = false;
        int hypothesisRootSubTreeKey = -1; //dummy
        int idxRootSubTreeInOrder = -1; //dummy
        for (int i = 0; i < levelOrder.Length; i++) {
            if (foundRootSubTree) {
                break;
            }
            hypothesisRootSubTreeKey = levelOrder[i];
            //keyToFind đầu tiên đc tìm thấy trong inOrder từ inStart đến inEnd thì là root của subtree đó
            for (int j = inStart; j < inEnd; j++) {
                if (hypothesisRootSubTreeKey == inOrder[j]) {
                    idxRootSubTreeInOrder = j;
                    foundRootSubTree = true;
                    break;
                }
            }
        }
        TreeNode rootSubTree = new TreeNode(hypothesisRootSubTreeKey);
        if (idxRootSubTreeInOrder > inStart) {
            rootSubTree.left = BuildTree(inOrder, levelOrder, inStart, idxRootSubTreeInOrder - 1);
        }
        if (idxRootSubTreeInOrder < inEnd) {
            rootSubTree.right = BuildTree(inOrder, levelOrder, idxRootSubTreeInOrder + 1, inEnd);
        }
        return rootSubTree;
    }

    public static void PrintTree(TreeNode root) {
        if (root == null) {
            return;
        }
        PrintTree(root.left);
        Console.Write(root.val + " ");
        PrintTree(root.right);
    }

    public static void Main() {
        int[] inOrder = {4, 8, 10, 12, 14, 20, 22};
        int[] levelOrder = {20, 8, 22, 4, 12, 10, 14};
        TreeNode root = BuildTree(inOrder, levelOrder, 0, inOrder.Length - 1);
        //print the tree in inorder
        PrintTree(root); //4, 8, 10, 12, 14, 20, 22 is exactly as inOrder input arr because tree constructed correctly
    }
}