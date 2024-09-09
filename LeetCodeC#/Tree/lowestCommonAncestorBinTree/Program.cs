//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/

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


        //Time complexity O(n * logn) n là số node vì dùng BFS
        //Space complexity O(2n)
        public static TreeNode lowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null) {
                return null;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node;
            queue.Enqueue(root);
            while (queue.Count > 0) {
                node = queue.Dequeue();
                if (isAncestorOf(node, p) == true && isAncestorOf(node, q) == true) {
                    stack.Push(node);
                }
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            return stack.Pop();
        }

        public static bool isAncestorOf(TreeNode root, TreeNode node) {
            if (root == null) {
                return false;
            }

            if (root == node) {
                return true;
            }

            bool leftChildIsAncestorOf = isAncestorOf(root.left, node);
            bool rightChildIsAncestorOf = isAncestorOf(root.right, node);
            if (leftChildIsAncestorOf == false && rightChildIsAncestorOf == false) {
                return false;
            }

            //root have left or right child contains node => then root contains the node is true
            return true;
        }


        //Time complexity O(log n)
        //Space complexity O(1)
        public static TreeNode lowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null) {
                return null;
            }

            if (root == p || root == q) {
                return root;
            }

            //lowest node that have p/q on the left
            TreeNode leftChild = lowestCommonAncestor2(root.left, p, q);

            //lowest node that have p/q on the right
            TreeNode rightChild = lowestCommonAncestor2(root.right, p, q);

            //current node have p/q on left and p/q on the right => it is the LCA
            if (leftChild != null && rightChild != null) {
                return root;
            }

            //if only left or right have p/q => have to go up to find LCA of both p and q, return lowest node that have p/q on the left or lowest node that have p/q on the right
            return leftChild != null ? leftChild : rightChild;
        }
        public static void Main(string[] args) {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(5);
            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(2);
            root.left.right.right = new TreeNode(4);
            root.left.right.left = new TreeNode(7);

            root.right = new TreeNode(1);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(8);

            var result = lowestCommonAncestor2(root, root.left, root.left.right.right);
            System.Console.WriteLine(result.val);
        }
    }
}