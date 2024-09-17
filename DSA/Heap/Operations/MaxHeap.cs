using HeapProgram.Abstraction;

namespace HeapProgram {
    public class MaxHeap : IHeap{
        public List<int> heap;
        public MaxHeap() {
            heap = new List<int>();
        }

        //since heap is a balance binary tree, parentIdx and lChildIdx, rChildIdx have relationship
        //and can be calculate
        private int parentIdx(int i) {
            return (i - 1) / 2;
        }

        private int lChildIdx (int i) {
            return (2 * i) + 1;
        }

        private int rChildIdx (int i) {
            return (2 * i) + 2;
        }

        private void swapValue(int i, int j) {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        //call from bottom right most element to root to maintain heap properties
        private void maxHeapifyUp(int currIdx) {
            while (currIdx > 0 && heap[parentIdx(currIdx)] < heap[currIdx]) {
                swapValue(currIdx, parentIdx(currIdx));
                currIdx = parentIdx(currIdx);
            }
        }

        //call from root (idx 0) to leaves to maintain heap properties
        private void maxHeapifyDown(int idx) {
            int lIdx = lChildIdx(idx);
            int rIdx = rChildIdx(idx);
            int maxIdx = idx; //swap curr element with max of (curr, left child, right child), then recursive do with just swapped index (now smaller)
            if (lIdx < this.heap.Count && heap[lIdx] > heap[maxIdx]) {
                maxIdx = lIdx;
            }
            if (rIdx < this.heap.Count && heap[rIdx] > heap[maxIdx]) {
                maxIdx = rIdx;
            }

            if (maxIdx == idx) { 
                //element at curr idx is larger than its child, 
                //and since we do this recursively => heap properties are maintained
                return;
            }
            //else swap value and do recursively to leaves nodes
            swapValue(idx, maxIdx);
            maxHeapifyDown(maxIdx);
        }

        public int Size() {
            return heap.Count;
        }

        public int Most() {
            if (heap.Count == 0) {
                return -1;
            }
            return heap[0];
        }

        public void Insert(int x) {
            heap.Add(x);
            maxHeapifyUp(heap.Count - 1);
            
        }    

        public int Extract() {
            if (this.heap.Count == 0) {
                return -1;
            }

            int result = heap[0];
            if (this.heap.Count == 1) {
                heap.RemoveAt(0);
                return result;
            }
            swapValue(0, heap.Count - 1); //now 0idx is smallest value in max heap
            heap.RemoveAt(heap.Count - 1); //remove max, which now in last idx (just swapped value) O(1) since this is list remove last ele
            maxHeapifyDown(0); //O(logn)
            return result;
        }
    }
}