public class TreeNode {
    public int data;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int data = 0, TreeNode left = null, TreeNode right = null) {
        this.data = data;
        this.left = left;
        this.right = right;
    }
}

public class Program {
    //visual representation of the tree
    //         1
    //        / \
    //       2   3
    //      / \ / \
    //     4  5 6  7
    public static void Main () {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(7);
        Console.WriteLine("Iterative InOrder with stack: ");
        InOrderIterative(root);

        Console.WriteLine("\nIterative PreOrder with stack");
        PreOrderIterative(root);

        Console.WriteLine("\nIterative PostOrder with 2 stack");
        PostOrderIterative2Stack(root);
    }
    //iterative implementation is using stack
    public static void InOrderIterative(TreeNode root) {
        if (root == null) {
            return;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>(); //stack stack up node to write data in the future
        TreeNode currNodeTraverse = root;

        while (stack.Count > 0 || currNodeTraverse != null) {
            while (currNodeTraverse != null) {
                stack.Push(currNodeTraverse);
                currNodeTraverse = currNodeTraverse.left;
            }
            //null at this point
            currNodeTraverse = stack.Pop();
            System.Console.Write(currNodeTraverse.data + " ");
            currNodeTraverse = currNodeTraverse.right;
        }
    }
 
    public static void PreOrderIterative(TreeNode root) {
        if (root == null) {
            return;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = root;
        while (true) {
            while (curr != null) {
                System.Console.Write(curr.data + " ");
                stack.Push(curr);
                curr = curr.left;
            }

            if (stack.Count <= 0) {
                return;
            }
            curr = stack.Pop();
            curr = curr.right;
        }
    }

    //https://www.geeksforgeeks.org/iterative-postorder-traversal/
    //use 2 stack
    public static void PostOrderIterative2Stack(TreeNode root) {
        if (root == null) {
            return;
        }

        Stack<TreeNode> s1 = new Stack<TreeNode>();
        Stack<TreeNode> s2 = new Stack<TreeNode>();
        s1.Push(root);

        while (true) {         
            if (s1.Count <= 0) {
                break;
            }   
            TreeNode lastNodeToExecuteInExecutionPlan = s1.Pop();
            if (lastNodeToExecuteInExecutionPlan.left != null) {
                s1.Push(lastNodeToExecuteInExecutionPlan.left);
            }
            if (lastNodeToExecuteInExecutionPlan.right != null) {
                s1.Push(lastNodeToExecuteInExecutionPlan.right);
            }
            //s1 will store the nodes plan to execute in s2, but since in s2, we want it 
            //to be rightsubtree - leftsubtree (so s2 pop will result in leftsubtree -> rightsubtree)
            //that's why s1 push root 's leftnode first, root's rightnode then


            //s2 will store the postorder inreverse order
            //postorder order: leftsubtree - rightsubtree - root
            //s2 order = postorder reverse order: root - all node's in right subtree - all nodes in left subtree
            s2.Push(lastNodeToExecuteInExecutionPlan);
        }

        while(s2.Count > 0) {
            TreeNode traverseNode = s2.Pop();
            System.Console.Write(traverseNode.data + " ");
        }
    }
}