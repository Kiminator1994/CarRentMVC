using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class PrintSpooler
    {
        private static PrintSpooler Instance;
        private Node First { get; set; }
        private Node Last { get; set; }
        private int Counter { get; set; }
        private PrintSpooler()
        {

        }

        public static PrintSpooler GetInstance()
        {
            if (Instance == null)
                return new PrintSpooler();
            else
                return Instance;
        }
        public void Print(PrintJob printJob)
        {
            Add(printJob);
            var toPrint = Remove();
            Console.WriteLine(toPrint.ToString() + Counter);
        }

        public sealed class Node 
        {
            public object Item { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

        }

        public void Add(object item)
        {
            var node = new Node(){Item = item};
            if (First == null)
            {
                First = node;
                Last = node;
            }
            else if (Last.Previous == null)
            {
                First.Next = node;
                Last = node;
                Last.Previous = First;

            }
            else
            {
                var temp = new Node();
                Last.Next = node;
                temp = Last;
                Last = node;
                Last.Previous = temp;
            }

            Counter++;
        }

        public Node Remove()
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                var first = new Node();
                first = First;
                First = First.Next;
                return first;
            }
        }
    }
}
