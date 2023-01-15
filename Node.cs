namespace HuffmanCodingAlgorithm;

public class Node : IComparable<Node>
{
    public char Character { get; set; }
    public int Frequency { get; set; }
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }

    public Node(char Character, int Frequency, Node LeftNode, Node RightNode)
    {
        this.Character = Character;
        this.Frequency = Frequency;
        this.LeftNode = LeftNode;
        this.RightNode = RightNode;
    }

    public int CompareTo(Node? other)
    {
        return this.Frequency - other.Frequency;
    }
    public bool IsLeaf()
    {
        if (this.LeftNode == null && this.RightNode == null)
            return true;
        return false;
    }
}