namespace Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in MathExtended.GetFibonacciNums(30))
            {
                Console.WriteLine("{0} ", i);
            }
        }
    }
}