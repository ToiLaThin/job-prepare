using HeapProgram.Abstraction;

namespace HeapProgram {
    public class MinHeap: IHeap {
        public List<int> heap;

        public MinHeap() {
            heap = new List<int>();
        }

        private void swapValue(int idx1, int idx2) {
            int temp = heap[idx1];
            heap[idx1] = heap[idx2];
            heap[idx2] = temp;
        }

        private int parentIdx(int idx) {
            return (idx - 1) / 2;
        }

        private int lChildIdx(int idx) {
            return 2 * idx + 1;
        }

        private int rChildIdx(int idx) {
            return 2 * idx + 2;
        }

        public int Most() {
            return heap[0];
        }

        public int Size() {
            return heap.Count;
        }

        private void minHeapifyUp(int currIdx) {
            if (currIdx <= 0) {
                return;
            }

            if (heap[parentIdx(currIdx)] <= heap[currIdx]) {
                //this is min heap, so parent if already less or equal => do nothing
                return;
            }

            swapValue(currIdx, parentIdx(currIdx));
            minHeapifyUp(parentIdx(currIdx));
        }

        //find the min node and push move to before
        private void minHeapifyDown(int currIdx) {
            while (true) {
                int lIdx = lChildIdx(currIdx);
                int rIdx = rChildIdx(currIdx);
                int minIdx = currIdx; 

                if (lIdx < heap.Count && heap[lIdx] < heap[minIdx]) {
                    minIdx = lIdx;
                }

                if (rIdx < heap.Count && heap[rIdx] < heap[minIdx]) {
                    minIdx = rIdx;
                }

                if (minIdx == currIdx) {
                    return;
                }

                //else
                swapValue(currIdx, minIdx);
                currIdx = minIdx;
            }
        }
        public void Insert(int x) {
            heap.Add(x);
            int currIdx = heap.Count - 1;
            minHeapifyUp(currIdx);
        }

        public int Extract() {
            if (heap.Count == 0) {
                return -1;
            }
            int result = heap[0];
            if (heap.Count == 1) {
                heap.RemoveAt(0);
                return result;
            }

            swapValue(0, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            minHeapifyDown(0); //log n
            return result;
        }
    }
}