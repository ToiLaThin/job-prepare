namespace HeapProgram.Abstraction {
    public interface IHeap {
        int Most();

        int Size();

        void Insert(int x);

        int Extract();
    }
}