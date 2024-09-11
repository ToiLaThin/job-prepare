//https://leetcode.com/problems/binary-tree-level-order-traversal/description/

public class Program {
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    //time complexity: O(n) n is number of nodes
    //space complexity: O(l * v) l is level and v is avg node per level
    public static List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> finalResult = new List<List<int>>();
        if (root == null) {
            return finalResult;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int nodeCountInLevel = queue.Count;
            List<int> nodesInLevel = new List<int>();
            for (int i = 0; i < nodeCountInLevel; i++) {
                TreeNode node = queue.Dequeue();
                nodesInLevel.Add(node.val);

                if (node.left != null) {
                    queue.Enqueue(node.left);
                }

                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            finalResult.Add(nodesInLevel);
        }
        return finalResult;
    }
    public static void Main(string[] args) {
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.right = new TreeNode(7);
        root.right.left = new TreeNode(15);

        var result = LevelOrder(root);
        foreach (var level in result)
        {
            foreach (var nodeVal in level)
            {
                System.Console.Write(nodeVal + " ");
            }
            System.Console.WriteLine();
        }
    }
}