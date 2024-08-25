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
public class Solution
{
    public static List<int> rightSideView(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null) {
            return result;
        }

        Queue<TreeNode> nodesWillView = new Queue<TreeNode>();
        nodesWillView.Enqueue(root);
        while (nodesWillView.Count > 0) {
            TreeNode viewNode = nodesWillView.Dequeue();
            result.Add(viewNode.val);
            if (viewNode.left == null && viewNode.right == null) {
                continue;
            }

            if (viewNode.right == null) {
                nodesWillView.Enqueue(viewNode.left);
                continue;
            }

            nodesWillView.Enqueue(viewNode.right);
        }
        return result;
    }

    public static void Main()
    {
        TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
        List<int> result = rightSideView(root);
        foreach (int item in result) {
            Console.WriteLine(item);
        }
    }
}