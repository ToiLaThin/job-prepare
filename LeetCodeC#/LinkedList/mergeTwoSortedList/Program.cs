// You are given the heads of two sorted linked lists list1 and list2.

// Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

// Return the head of the merged linked list.

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

public class Program {
    public static ListNode mergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) {
            return list2;
        }

        if (list2 == null) {
            return list1;
        }

        ListNode dummy = new ListNode();
        ListNode head = list1.val < list2.val ? list1 : list2;
        while (list1 != null && list2 != null) {
            if (list1.val < list2.val) {
                dummy.next = list1;
                list1 = list1.next;
            }
            else {
                dummy.next = list2;
                list2 = list2.next;
            }
            dummy = dummy.next;
        }

        if (list1 == null) {
            dummy.next = list2;
        } else {
            dummy.next = list1;
        }

        return head;
    }
    public static void Main() {
        ListNode list1 = new ListNode(1);
        list1.next = new ListNode(2);
        list1.next.next = new ListNode(4);

        ListNode list2 = new ListNode(1);
        list2.next = new ListNode(3);
        list2.next.next = new ListNode(4);

        // ListNode mergedList = mergeTwoLists(list1, list2);
        ListNode mergedList = mergeTwoLists(null, new ListNode(0));
        while (mergedList != null) {
            System.Console.WriteLine(mergedList.val);
            mergedList = mergedList.next;
        }
    }
}
