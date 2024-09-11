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
    //Time: O(n) n is number of nodes in tree
    //Space: O(m) m is max number of node in a level
    public static List<int> rightSideView(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null) {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int nodesInLevelCount = queue.Count;
            TreeNode node = null;
            for (int i = 0; i < nodesInLevelCount; i++) {
                node = queue.Dequeue();

                if (node.left != null) {
                    queue.Enqueue(node.left);
                }

                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(node.val); //add last node each level
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