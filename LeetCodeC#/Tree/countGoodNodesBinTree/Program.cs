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

    public static int GoodNodes(TreeNode root) {
        int count = 0;
        //to track max val in the path of root to BEFORE current node
        Stack<int> maxStack = new Stack<int>();
        CountGoodNodesDFS(root, ref count, maxStack);        
        return count;
    }

    //Time: O(n) n is number of nodes
    //Space O(h * h) h for stack and h for recursion | why h = log n ? => there is a solution only pass maxVal
    public static void CountGoodNodesDFS(TreeNode root,ref int count, Stack<int> maxStack) {
        if (root == null) {
            return;
        }

        //curr node is root of whole tree => good node
        if (maxStack.Count == 0) {
            count += 1;
            maxStack.Push(root.val);
            goto next;
        }
        //curr node is  good node
        int maxInPath = maxStack.Peek();
        if (root.val >= maxInPath) {
            count += 1;
            maxStack.Push(root.val);
        }

        next:
        if (root.left != null) {
            CountGoodNodesDFS(root.left, ref count, maxStack);
        }

        if (root.right != null) {
            CountGoodNodesDFS(root.right, ref count, maxStack);
        }

        //when backtrack, curr node no longer in the path => must remove from max stack if it in maxStack
        if (root.val == maxStack.Peek()) {
            maxStack.Pop();
        }
    }

    public static void Main(String[] args) {
        // TreeNode root = new TreeNode(3);
        // root.left = new TreeNode(1);
        // root.right = new TreeNode(4);
        // root.left.left = new TreeNode(3);
        // root.right.right = new TreeNode(5);
        // root.right.left = new TreeNode(1);

        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(3);
        root.left.right = new TreeNode(2);
        root.left.left = new TreeNode(4);

        int countGoodNodes = GoodNodes(root);
        System.Console.WriteLine(countGoodNodes);
    }
}