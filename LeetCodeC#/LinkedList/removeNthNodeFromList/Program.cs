//https://leetcode.com/problemset/?search=remove+nth+node&page=1

public class Program {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
     }

    public static ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0, head);
        ListNode fast = head;
        ListNode slow = dummy;
        int count = 1;
        while (count < n) {
            fast = fast.next;
            count += 1;
        }

        while (fast.next != null) {
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next.next;
        return dummy.next;
    } 

    public static void printList(ListNode head) {
        while (head != null) {
            System.Console.WriteLine(head.val);
            head = head.next;
        }
    }
    public static void Main(string[] args) {
        // ListNode head = new ListNode(1);
        // head.next = new ListNode(2);
        // head.next.next = new ListNode(3);
        // head.next.next.next = new ListNode(4);
        // head.next.next.next.next = new ListNode(5);
        // RemoveNthFromEnd(head, 2);

        // ListNode head = new ListNode(1);
        // RemoveNthFromEnd(head, 1);

        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head = RemoveNthFromEnd(head, 2);

        printList(head);
    }
}