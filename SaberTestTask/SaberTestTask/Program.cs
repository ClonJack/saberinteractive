using SaberTestTask;


var l1 = new ListNode() { Data = "Node 1" };
var l2 = new ListNode() { Data = "Node 2" };
var l3 = new ListNode() { Data = "Node 3" };
var l4 = new ListNode() { Data = "Node 4" };
var l5 = new ListNode() { Data = "Node 5" };

l1.Next = l2;
l2.Next = l3;
l3.Next = l4;
l4.Next = l5;


l2.Previous = l1;
l3.Previous = l2;
l4.Previous = l3;
l5.Previous = l5;


l1.Random = null;
l2.Random = l1;
l3.Random = l5;
l4.Random = l4;
l5.Random = l1;

var list = new ListRandom()
{
    Head = l1,
    Tail = l5,
    Count = 5
};


list.Serialize(File.Open("Node.data", FileMode.OpenOrCreate));
list.Deserialize(File.Open("Node.data", FileMode.Open));