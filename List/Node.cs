
namespace List
{
    public class Node
    {
        public int Val { get; set; }
        public Node Next { get; set; }

        public Node(int val)
        {
            Val = val;
            Next = null;
        }
    }
}
