//Common Tree Types
using System;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Tree Types");
        //Binary Tree
        //A tree in which each node has at most two children
        //Visual representation of a binary tree
        //         1
        //        / \
        //       2   3
        //      / \ / \
        //     4  5 6  7
        //Binary Search Tree
        //A binary tree in which for each node, all elements in the left subtree 
        //are less than the node and all elements in the right subtree 
        //are greater than the node
        //Visual representation of a binary search tree (same as before)

        //Balanced Tree
        //A tree in which the height of the left and right subtrees of any node
        //differ by at most 1 => ensure O(log n) time complexity for search
        //Visual representation of a balanced tree
        //         1
        //        / \
        //       2   3
        //      / \ 
        //     4  5 

        //Complete Tree => Perfect Tree(All levels are completely filled 2 children)
        //A tree in which every level, except possibly the last, is completely filled
        //and all nodes are as far left as possible 
        //Applicable for heaps, heap sort
        //Visual representation of a complete tree
        //         1
        //        / \
        //       2   3
        //      / \ /
        //     4  5 6

        //Degenerate Tree => Skewed Tree
        //A tree in which each parent node has only one child
        //Visual representation of a degenerate tree
        //         1
        //          \
        //           2
        //            \
        //             3

        //Balanced Tree: AVL Tree, Red-Black Tree
        //Complete Tree: Heap
        //B Tree, B+ Tree, Trie, Heap

    }
}