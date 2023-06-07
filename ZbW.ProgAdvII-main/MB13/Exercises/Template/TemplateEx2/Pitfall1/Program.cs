using System;
using System.Threading.Tasks;

namespace Pitfall1 {
    class Program {
        static void Main() {
            var task = IsPrimeAsync(10000000000000061L);
            Console.WriteLine("Other work");
            Console.WriteLine("Result {0}", task.Result);
        }

        public static async Task<bool> IsPrimeAsync(long number) {
            for (long i = 2; i <= Math.Sqrt(number); i++) {
                if (number % i == 0) { return false; }
            }
            return true;
        }
    }
}
