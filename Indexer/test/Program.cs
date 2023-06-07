namespace test
{
    internal class Program
    {
        public delegate void Action();

            public static void Publish(Action observers)
            {
                try
                {
                    observers();
                }
                catch(System.NullReferenceException  e)
                {
                    Console.WriteLine("Fehler");
                }
            }
            static void Main(string[] args)
            {
                Action observers = null;
                Publish(observers);
                observers = new Action(delegate { throw new Exception(); });
                observers = new Action(delegate { Console.WriteLine("ok"); });
                Publish(observers);
            }
        
    }
    
}