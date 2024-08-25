public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Program {
    public static TreeNode BuildTree(int[] inorder, int[] postorder) {
        return BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }
    public static void Main() {
        int[] inorder = new int[] {9,3,15,20,7};
        int[] postorder = new int[] {9,15,7,20,3};
        // graph representation
        //         3
        //        / \
        //       9  20
        //         /  \
        //        15   7
        
        TreeNode root = BuildTree(inorder, postorder);
    }
}