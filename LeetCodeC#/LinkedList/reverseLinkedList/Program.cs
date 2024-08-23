// Given the head of a singly linked list, reverse the list, and return the reversed list.
// Input: head = [1,2,3,4,5]
// Output: [5,4,3,2,1]

public class ListNode {
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}


public class Program {

    public static ListNode reverseList(ListNode head) {
        ListNode pre = null;
        ListNode curr = pre;
        ListNode post = head;
        while (post != null) {
            curr = post;
            post = post.next;
            curr.next = pre;
            pre = curr;
        }

        return curr;
    }
    public static void Main() {
        ListNode head = new ListNode(0);
        head.next = new ListNode(1);
        head.next.next = new ListNode(2);
        head.next.next.next = new ListNode(3);

        ListNode reversedHead = reverseList(head);
        while (reversedHead != null) {
            System.Console.WriteLine(reversedHead.val);
            reversedHead = reversedHead.next;
        }
    }
}
