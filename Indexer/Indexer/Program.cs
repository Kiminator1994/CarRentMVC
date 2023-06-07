using System.Collections;

namespace Indexer
{
    internal class Program
    {

        public static void Print(ArrayList list)
        {
            foreach (object o in list)
            {
                Console.Write("{0}", o);
            }
        }
        public static void Main()
        {
            ArrayList myList = new ArrayList();
            object o1 = 1;
            object o2 = 2;
            myList.Add(o1);
            myList.Add(o2);
            Print(myList);
            o1 = 4;
            Print(myList);
        }
    }
}