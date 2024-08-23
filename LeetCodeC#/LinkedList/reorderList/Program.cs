// You are given the head of a singly linked-list. The list can be represented as:

// L0 → L1 → … → Ln - 1 → Ln
// Reorder the list to be on the following form:

// L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
// You may not modify the values in the list's nodes. Only nodes themselves may be changed.

// Input: head = [1,2,3,4,5]
// Output: [1,5,2,4,3]
 

// Constraints:
// The number of nodes in the list is in the range [1, 5 * 104].
// 1 <= Node.val <= 1000

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

public class Program {
    public static void reorderList(ListNode head) {
        // use list and two pointers to solve the problem
        // Time complexity: O(n)
        // Space complexity: O(n)
        List<ListNode> list = new List<ListNode>();
        ListNode temp = head;
        while (temp != null) {
            list.Add(temp);
            temp = temp.next;
        }

        int i = 0, j = list.Count - 1;
        while (i < j) {
            list[i].next = list[j];
            i += 1;
            if (i == j) {
                break;
            }
            list[j].next = list[i];
            j -= 1;
        }
        list[i].next = null;
    }
    public static void Main() {
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);
        head.next.next.next.next.next = new ListNode(6);

        reorderList(head);
        while (head != null) {
            System.Console.WriteLine(head.val);
            head = head.next;
        }
    }
}