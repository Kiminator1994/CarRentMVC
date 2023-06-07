namespace RecursiveList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecursiveList<string> list1 = new RecursiveList<string>();
            // ...
            list1.Add("1");
            list1.Add("2");
            list1.Add("3");
            list1.Add("4");
            // Iteriere über die Liste
            foreach (string s in list1.Traverse())
            {
                Console.WriteLine(s);
            }
            // Iteriere über die Liste im umgekehrter Reihenfolge
            foreach (string s in list1.Inverse())
            {
                Console.WriteLine(s);
            }
            // ForEach über die Liste
            list1.ForEach(delegate (string s) { Console.WriteLine(s); });
        }
    }
}