using System.Collections;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace HuffmanCodingAlgorithm;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your string:");
        string input = Console.ReadLine();
        // var priority = new PriorityQueue<string, int>();
        // priority.Enqueue("sangam", 1);
        // priority.Enqueue("Rimal", 2);
        // Console.WriteLine(JsonConvert.SerializeObject(priority));
        // string input = "my name is sangam";

        var frequencies = HuffmanTree.BuildFrequenciesTable(input);

        var root = HuffmanTree.BuildTree(frequencies);

        var bitArray = HuffmanTree.Encode(root);

        Console.WriteLine(JsonConvert.SerializeObject(bitArray));

        var encoded = "";

        foreach (var c in input)
        {
            encoded += bitArray[c];
        }

        Console.WriteLine("encoded bit array is=>" + encoded);

        //decode string
        var decodeInput = HuffmanTree.Decode(root, encoded);
        Console.WriteLine(decodeInput);
    }
}
