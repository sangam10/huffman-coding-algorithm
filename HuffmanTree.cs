using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HuffmanCodingAlgorithm;

class HuffmanTree
{
    public static Dictionary<char, int> BuildFrequenciesTable(string input)
    {
        Dictionary<char, int> frequencies = new Dictionary<char, int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (frequencies.ContainsKey(input[i]))
            {
                frequencies[input[i]]++;
            }
            else
            {
                frequencies.Add(input[i], 1);
            }
        }

        return frequencies;
    }

    public static Node BuildTree(Dictionary<char, int> frequencies)
    {
        PriorityQueue<Node, int> priorityQueue = new PriorityQueue<Node, int>();

        foreach (var item in frequencies)
        {
            Node node = new Node(item.Key, item.Value, null, null);
            priorityQueue.Enqueue(node, item.Value);
        }


        while (priorityQueue.Count > 1)
        {
            Node RightNode = priorityQueue.Dequeue();
            Node LeftNode = priorityQueue.Dequeue();
            int Frequency = RightNode.Frequency + LeftNode.Frequency;
            Node parent = new Node('\0', Frequency, LeftNode, RightNode);
            priorityQueue.Enqueue(parent, Frequency);

        }
        //this is root node
        return priorityQueue.Dequeue();
    }

    public static Dictionary<char, string> Encode(Node root)
    {
        Dictionary<char, string> codes = new Dictionary<char, string>();
        EncodeHelper(root, "", codes);
        return codes;
    }

    public static void EncodeHelper(Node node, string code, Dictionary<char, string> codes)
    {
        if (node.IsLeaf())
        {
            codes.Add(node.Character, code);
        }
        else
        {
            EncodeHelper(node.LeftNode, code + "0", codes);
            EncodeHelper(node.RightNode, code + "1", codes);
        }
    }

    public static string Decode(Node root, string bitArray)
    {
        Node current = root;
        string input = "";
        foreach (char bit in bitArray)
        {
            if (bit == '0')
            {
                current = current.LeftNode;
            }
            else
            {
                current = current.RightNode;
            }
            if (current.IsLeaf())
            {
                input += current.Character;
                current = root;
            }
        }
        return input;
    }
}
