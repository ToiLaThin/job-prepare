// https://leetcode.com/problems/copy-list-with-random-pointer/description/

using System;
using System.Collections.Generic;

public class Node {
    public int val;
    public Node next;

    public Node random;

    public Node(int _val) {
        this.val = _val;
        next = null;
        random = null;

    }

    //time O(2n): 1 loop to create reference to created node (oldNode: newNode), 1 to copy node
    
    public static Node CopyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();
        Node temp = head;
        while (temp != null) {
            Node newNode = new Node(temp.val);
            oldToCopy[temp] = newNode;
            temp = temp.next;
        }
        //saved all old node -> new created node to quickly reference & avoid create duplicate node

        temp = head;
        while (temp != null) {
            //cannot be temp.next / temp.random : point to wrong node
            //also, use dict to avoid create duplicate node
            Node node = oldToCopy[temp];
            node.next = temp.next == null ? null : oldToCopy[temp.next];
            node.random = temp.random == null ? null : oldToCopy[temp.random];
            temp = temp.next;
        }

        return oldToCopy[head];


    }
    public static void Main(string[] args) {
        Node node = new Node(7);        
        Node node1 = new Node(13);
        Node node2 = new Node(11);
        Node node3 = new Node(10);
        Node node4 = new Node(1);

        node.next = node1;
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;

        node.random = null;
        node1.random = node;
        node2.random = node4;
        node3.random = node2;
        node4.random = node1;

        Node result = CopyRandomList(node);
        while (result != null) {
            System.Console.WriteLine("Val: " + result.val + " Random: " + result.random.val);
            result = result.next;
        }

    }
}