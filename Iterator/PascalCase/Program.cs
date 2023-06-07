namespace PascalCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = null;
            Console.WriteLine(String.ToPascalCase(s));
        }
    }

    public class String
    {
        public static string ToPascalCase(string text)
        {
            if (text != null)
            {
                string[] splittedTextArray = text.Split("_");
                string[] pascalArray = new string[splittedTextArray.Length];
                string pascalString = "";

                for (int i = 0; i < splittedTextArray.Length; i++)
                {
                    pascalArray[i] = char.ToUpper(splittedTextArray[i][0]) + splittedTextArray[i].Substring(1);
                }

                foreach (var s in pascalArray)
                {
                    pascalString += s;
                }

                return pascalString;
            }

            return null;
        }
           
    }
}