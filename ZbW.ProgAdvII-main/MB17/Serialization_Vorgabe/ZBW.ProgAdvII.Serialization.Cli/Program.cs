using System;
using ZBW.ProgAdvII.Serialization.BusinessLogic;

namespace ZBW.ProgAdvII.Serialization.Cli
{
    public class Program
    {
        static void Main(string[] args)
        {
            var process = new ApplicationProcess();
            
            process.Run();
            Console.ReadLine();
        }
    }
}