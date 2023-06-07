namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSpooler ps = PrintSpooler.GetInstance();
            PrintJob p = new PrintJob();
            ps.Print(p);
            PrintJob p2 = new PrintJob();
            ps.Print(p2);
            PrintJob p3 = new PrintJob();
            ps.Print(p3);
            PrintJob p4 = new PrintJob();
            ps.Print(p4);
        }
    }
}