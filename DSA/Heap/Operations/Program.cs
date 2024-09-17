//https://www.geeksforgeeks.org/introduction-to-heap/
namespace HeapProgram {
    public class Program {        
        public static void Main(string[] args) {
            
            MaxHeap mh = new MaxHeap();
            mh.Insert(3);
            mh.Insert(10);
            mh.Insert(12);
            mh.Insert(8);
            mh.Insert(2);
            mh.Insert(14);
            
            System.Console.WriteLine("The current size of the heap is " + mh.Size());
            System.Console.WriteLine("The current maximum element is " + mh.Most());
            foreach (var val in mh.heap)
            {
                System.Console.Write(val + " ");
            }
            System.Console.WriteLine();
            mh.Extract();
            foreach (var val in mh.heap)
            {
                System.Console.Write(val + " ");
            }

            // MinHeap mh = new MinHeap();
            // mh.Insert(3);
            // mh.Insert(10);
            // mh.Insert(12);
            // mh.Insert(8);
            // mh.Insert(2);
            // mh.Insert(14);
            
            // System.Console.WriteLine("The current size of the heap is " + mh.Size());
            // System.Console.WriteLine("The current minimun element is " + mh.Most());
            // foreach (var val in mh.heap)
            // {
            //     System.Console.Write(val + " ");
            // }
            // System.Console.WriteLine();
            // mh.Extract();
            // foreach (var val in mh.heap)
            // {
            //     System.Console.Write(val + " ");
            // }
        }
    }
}