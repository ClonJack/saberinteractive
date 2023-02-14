# saberinteractive





      public class ListNode
      {
        public ListNode Prev;
        public ListNode Next;
        public ListNode Rand;
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
            var current = Head;
            for (var i = 0; i < Count; i++)
            {
                writer.Write(current.Data);
                writer.Write(current.Next.Data);
                writer.Write(current.Prev.Data);
                writer.Write(current.Rand.Data);

                current = current.Next;
            }

            writer.Write(Tail.Data);
        }

        public void Deserialize(FileStream s)
        {
            using var binaryWriter = new BinaryReader(s);

            Count = binaryWriter.ReadInt32();
            Head = new ListNode()
                {
                    Data = binaryWriter.ReadString(),
                    Next = new ListNode(),
                    Prev = null
                };
            Tail = Head;
            
            var current = Head;
            for (var i = 1; i < Count; i++)
            {
                current.Next.Prev = current;
                current = current.Next;

                current.Data = binaryWriter.ReadString();
                current.Prev.Data = binaryWriter.ReadString();
                var node = i != Count - 1 ? current.Next = new ListNode() : Tail = current;
            }
        }
    }


![image](https://user-images.githubusercontent.com/32494392/218607530-9abbffbb-0e2f-472d-ad07-ad621ceb1ca9.png)


