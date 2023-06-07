using System.Drawing;

namespace medium
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            Go();

        }
        public static void Go()
        {
            string x;
            
            DoSomething(x);
            Console.WriteLine(x.ToString());

        }
        public static void DoSomething( string pValue)
        {
            pValue = "12345";
        }
    }

    internal class MyInt
    {
        public int MyValue { get; internal set; }
    }
}