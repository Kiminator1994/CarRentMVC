using System;
using System.Reflection;

namespace Attribute4 {
    // Attribute which allows one to annotate methods with
    // a text that serves as an abbreviation of their signature.
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    class AbbreviationAttribute : Attribute {
        string text;

        public AbbreviationAttribute(string text) {
            this.text = text;
        }

        public string Text {
            get { return text; }
        }
    }

    // A sample class for testing the new attribute
    class Stack {
        int[] data = new int[10];
        int top = 0;

        [Abbreviation("+ Push")]
        public void Push(int value) {
            data[top++] = value;
        }

        [Abbreviation("+ Pop")]
        public int Pop() {
            return data[--top];
        }
    }


    public class Test {

        static void Main() {
            Stack stack = new Stack();
            Type t = stack.GetType();
            foreach (MethodInfo m in t.GetMethods()) {
                object[] attr = m.GetCustomAttributes(typeof(AbbreviationAttribute), true);
                if (attr.Length > 0) {
                    AbbreviationAttribute abbr = (AbbreviationAttribute) (attr[0]);
                    Console.WriteLine(abbr.Text);
                }
            }
        }
    }
}