namespace RefactoringDemo {
    internal class Program {
        static void Main(string[] args) {

            int[] numbers = Numbers.Func(1000, false);

            foreach (var n in numbers) {
                Console.WriteLine(n);
            }

            Console.ReadLine();
        }
    }
}