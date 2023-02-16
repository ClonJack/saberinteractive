# saberinteractive


КОД С 1 ЗАДАНИЯ:


         public class ListNode
         {
             public ListNode Previous;
             public ListNode Next;
             public ListNode Random;
             public string Data;
          }


          public class ListRandom
          {
          public ListNode Head;
          public ListNode Tail;
          public int Count;

          public void Serialize(FileStream s)
          {
              using var writer = new BinaryWriter(s);
              writer.Write(Count);

              var randomNode = GetIndexRandomNode(Head); // получаем порядковые номера рандомных нод. 
              var current = Head;
              foreach (var indexRandomMode in randomNode)
              {
                  writer.Write(current.Data);
                  writer.Write(current.Next.Data);
                  writer.Write(current.Previous.Data);
                  writer.Write(current.Random.Data);

                  writer.Write(indexRandomMode);

                  current = current.Next;
              }
          }

          private List<int> GetIndexRandomNode(ListNode currentNode)
          {
              var nextNode = currentNode.Next;
              var indexRandomNode = new List<int>(Count);
              for (var i = 0; i < Count; i++)
              {
                  if (nextNode == Tail)
                  {
                      break;
                  }

                  if (currentNode != nextNode && currentNode.Random == nextNode)
                  {
                      indexRandomNode.Add(i);
                      (currentNode, nextNode) = (nextNode, currentNode);
                      i = 0;
                  }

                  nextNode = nextNode.Next;
              }

              return indexRandomNode;
          }

          private ListNode GetNodeAt(int index)
          {
              var current = Head;
              for (var i = 0; i < index; i++)
              {
                  current = Head.Next;
              }

              return current;
          }

          public void Deserialize(FileStream s)
          {
              using var binaryWriter = new BinaryReader(s);

              Count = binaryWriter.ReadInt32();
              Head = new ListNode()
              {
                  Data = binaryWriter.ReadString(),
                  Next = new ListNode(),
                  Previous = null,
                  Random = new ListNode()
              };
              Tail = Head;

              var randomNode = new List<int>(Count);
              var current = Head;
              for (var i = 1; i < Count; i++)
              {
                  current.Next.Previous = current;

                  current = current.Next;

                  current.Data = binaryWriter.ReadString();
                  current.Previous.Data = binaryWriter.ReadString();

                  var node = i != Count - 1 ? current.Next = new ListNode() : Tail = current;

                  randomNode[i] = binaryWriter.ReadInt32();
              }

              current = Head;
              var j = 0;
              for (var i = 0; i < Count; i++)
              {
                  var nodeRandom = GetNodeAt(j);
                  if (current == nodeRandom)
                  {
                      current.Random = nodeRandom;
                      j++;
                      i = 0;
                  }

                  current.Next = current.Next;
              }
          }




РЕАЛИЗАЦИЯ БЛОК СХЕМЫ :

-Сущность SOLDIER:
![image](https://user-images.githubusercontent.com/32494392/218611159-8529f6e6-90df-4016-8faa-6c62d2325157.png)
-ЛОГИКА СОСТОЯНИЯ ПАТРУЛЯ:
![image](https://user-images.githubusercontent.com/32494392/218612820-dbb2bcd3-5e7f-4974-beae-1e45d39aa288.png)
-ЛОГИКА СОСТОЯНИЯ АТАКИ:
![image](https://user-images.githubusercontent.com/32494392/218613407-bfdd6149-fde1-4262-b6c2-9140396aad9d.png)
-ЛОГИКА ИГРОВОГО ЦИКЛА:
![image](https://user-images.githubusercontent.com/32494392/218613974-7d64e22e-0b2d-4298-95ee-127e96c32ee6.png)







