//https://leetcode.com/problems/add-two-numbers/
public class Solution {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
     }

    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode temp = dummy;
        int carry = 0;
        while (l1 != null || l2 != null || carry != 0) {
            int val1 = l1 != null ? l1.val : 0;
            int val2 = l2 != null ? l2.val : 0;
            int sum = val1 + val2 + carry;
            carry = sum >= 10 ? 1 : 0;
            ListNode newDigit = new ListNode(sum % 10);
            temp.next = newDigit;
            temp = temp.next;

            if (l1 != null) {
                l1 = l1.next;
            }

            if (l2 != null) {
                l2 = l2.next;
            }
        }

        return dummy.next;
    }

    public static void Main(string[] args) {
        // ListNode l1 = new ListNode(2);
        // l1.next = new ListNode(4);
        // l1.next.next = new ListNode(3);

        // ListNode l2 = new ListNode(5);
        // l2.next = new ListNode(6);
        // l2.next.next = new ListNode(4);

        ListNode l1 = new ListNode(9);
        l1.next = new ListNode(9);
        l1.next.next = new ListNode(9);
        l1.next.next.next = new ListNode(9);
        l1.next.next.next.next = new ListNode(9);
        l1.next.next.next.next.next = new ListNode(9);
        l1.next.next.next.next.next.next = new ListNode(9);

        ListNode l2 = new ListNode(9);
        l2.next = new ListNode(9);
        l2.next.next = new ListNode(9);
        l2.next.next.next = new ListNode(9);

        ListNode result = AddTwoNumbers(l1, l2);
        while (result != null) {
            System.Console.WriteLine(result.val);
            result = result.next;
        }
    }
}