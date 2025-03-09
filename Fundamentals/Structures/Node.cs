namespace Structures
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;

        public bool IsLeaf => !HasLeft && !HasRight;
        public bool HasLeft => Left != null;
        public bool HasRight => Right != null;
    }

    public class IntNode {

        public int Value;
        public IntNode Left;
        public IntNode Right;

        public bool IsLeaf => !HasLeft && !HasRight;
        public bool HasLeft => Left != null;
        public bool HasRight => Right != null;


        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
