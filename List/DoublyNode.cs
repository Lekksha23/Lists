
namespace List
{
    class DoublyNode
    {
        public int Val { get; set; }
        public DoublyNode Next { get; set; }
        public DoublyNode Prev { get; set; }

        public DoublyNode(int val)
        {
            Val = val;
            Next = null;
            Prev = null;
        }
    }
}
