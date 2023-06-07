
Programm.StartCalculcation(3);
Console.ReadLine();

public class Programm {
    private static int result;
    private static int Result {
        get {
            return result;
        }
        set {
            // Zuweisung erfolgt wieder im Main-Thread.
            result = value;
        }
    }

    static int LongCalculation(int number) {
        var sleep = number * 1000;
        Thread.Sleep(sleep);
        return sleep;
    }








    public static async void StartCalculcation(int number) {
        Console.WriteLine("(computing)");
        Result = await Task<int>.Factory.StartNew(() => LongCalculation(number));
        Console.WriteLine(result.ToString());
    }
}