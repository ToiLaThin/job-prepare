//https://www.hackerrank.com/domains/data-structures?filters%5Bsubdomains%5D%5B%5D=linked-lists

public class Program {
    public class SinglyLinkedListNode {
        public int data;
        public SinglyLinkedListNode next;
        public SinglyLinkedListNode(int data = 0) {
            this.data = data;
            this.next = null;
        }
    }

    public static SinglyLinkedListNode InsertHead(SinglyLinkedListNode head, int data) {
        if (head == null) {
            return new SinglyLinkedListNode(data);
        }
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
        newNode.next = head;
        return newNode;

    }

    public static void Print(SinglyLinkedListNode head) {
        SinglyLinkedListNode temp = head;
        while (temp != null) {
            System.Console.Write(temp.data + " ");
            temp = temp.next;
        }
    }

    public static SinglyLinkedListNode InsertTail(SinglyLinkedListNode head, int data) {
        if (head == null) {
            return new SinglyLinkedListNode(data);
        }
        SinglyLinkedListNode temp = head;
        while (temp.next != null) {
            temp = temp.next;
        }

        temp.next = new SinglyLinkedListNode(data);
        return head;
    }

    public static SinglyLinkedListNode InsertAt(SinglyLinkedListNode head, int data, int idx) {
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
        if (idx == 0) {
            newNode.next = head;
            head = newNode;
            return head;
        }

        SinglyLinkedListNode temp = head;
        int idxBefore = 0;
        while (idxBefore < idx - 1) {
            temp = temp.next;
            idxBefore += 1;
        }

        newNode.next = temp.next;
        temp.next = newNode;
        return head;
    }

    public static SinglyLinkedListNode DeleteAt(SinglyLinkedListNode head, int posIdx) {
        if (posIdx == 0) {
            SinglyLinkedListNode newHead = head.next;
            head = null;
            return newHead;
        }

        //make sure posIdx is valid, else at some point beforeDeleteNode is null and have exception
        int idxBefore = 0;
        SinglyLinkedListNode beforeDeleteNode = head;
        while (idxBefore < posIdx - 1) {
            beforeDeleteNode = beforeDeleteNode.next;
            idxBefore += 1;
        }

        SinglyLinkedListNode deleteNode = beforeDeleteNode.next;
        beforeDeleteNode.next = deleteNode.next;
        deleteNode = null;
        return head;
    }

    public static void Main(string[] args) {
        SinglyLinkedListNode head = new SinglyLinkedListNode(5);
        head = InsertHead(head, 2);
        head = InsertTail(head, 15);
        head = InsertTail(head, 17);
        head = InsertAt(head, 20, 2);
        head = DeleteAt(head, 2);
        head = DeleteAt(head, 0);
        Print(head);
    }
}