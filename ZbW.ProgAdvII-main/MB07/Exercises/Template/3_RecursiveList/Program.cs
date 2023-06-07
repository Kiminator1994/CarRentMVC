using System;

namespace _3_RecursiveList {
    class Program {
        static void Main(string[] args) {
            RecursiveList<string> list1 = new RecursiveList<string>();
            list1.Append("Hallo");
            list1.Append(".NET");
            list1.Append("C#");
            list1.Append("---");

            // Iteriere über die Liste 
            // TODO: RecursiveList.Traverse implementieren
            Console.WriteLine("RecursiveList.Traverse");
            //foreach (string s in list1.Traverse)
            //{
            //    Console.WriteLine(s);
            //}

            // Iteriere über die Liste im umgekehrter Reihenfolge
            // TODO: RecursiveList.Inverse implementieren
            Console.WriteLine("RecursiveList.Inverse");
            //foreach (string s in list1.Inverse)
            //{
            //    Console.WriteLine(s);
            //}

            // ForEach über die Liste
            // TODO: RecursiveList.ForEach implementieren
            Console.WriteLine("RecursiveList.ForEach");
            //list1.ForEach(delegate(string s) { Console.WriteLine(s); });


            RecursiveList<string> list2 = new RecursiveList<string>();

            // Iteriere über leere Liste 
            Console.WriteLine("RecursiveList.Traverse (leer)");
            //foreach (string s in list2.Traverse)
            //{
            //    Console.WriteLine(s);
            //}

            // Iteriere über leere Liste im umgekehrter Reihenfolge
            Console.WriteLine("RecursiveList.Inverse (leer)");
            //foreach (string s in list2.Inverse)
            //{
            //    Console.WriteLine(s);
            //}

            // ForEach über leere Liste
            Console.WriteLine("RecursiveList.ForEach (leer)");
            //list2.ForEach(delegate(string s) { Console.WriteLine(s); });


            Console.ReadKey();
        }
    }
}