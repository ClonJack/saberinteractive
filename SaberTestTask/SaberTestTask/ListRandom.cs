using System.IO;

namespace SaberTestTask;

public class ListRandom
{
    public ListNode Head;
    public ListNode Tail;
    public int Count;

    private Dictionary<ListNode, int> GetIndexNode()
    {
        var dictionary = new Dictionary<ListNode, int>(Count);

        var id = 0;
        for (var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
        {
            dictionary.Add(currentNode, id);
            id++;
        }

        return dictionary;
    }

    public void Serialize(FileStream s)
    {
        using var writer = new BinaryWriter(s);
        writer.Write(Count);

        var indexNode = GetIndexNode();
        for (var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
        {
            writer.Write(currentNode.Data);
        }

        for (var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
        {
            var writeValue = currentNode?.Random != null ? indexNode[currentNode.Random] : -1;
            Console.WriteLine($"WriteValue:{writeValue}");
            writer.Write(writeValue);
        }

        Console.WriteLine("Serialize");
    }


    private ListNode ReadNode(int randomId, Dictionary<int, ListNode> dictionaryNodes) => randomId >= 0 ? dictionaryNodes[randomId] : null;

    public void Deserialize(FileStream s)
    {
        using var binaryReader = new BinaryReader(s);
        Count = binaryReader.ReadInt32();

        var dictionaryNodes = new Dictionary<int, ListNode>();
        for (var i = 0; i < Count; i++)
        {
            dictionaryNodes.Add(i, new ListNode() { Data = binaryReader.ReadString() });
        }


        Head = dictionaryNodes[0];
        Tail = dictionaryNodes[Count - 1];

        for (var i = 0; i < Count; i++)
        {
            if (i > 0)
            {
                dictionaryNodes[i].Previous = dictionaryNodes[i - 1];
            }

            if (i < Count - 1)
            {
                dictionaryNodes[i].Next = dictionaryNodes[i + 1];
            }

            var randomId = binaryReader.ReadInt32();
            dictionaryNodes[i].Random = randomId >= 0 ? dictionaryNodes[randomId] : null;
        }

        Console.WriteLine("Deserialize");
    }



}