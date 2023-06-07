using System;

namespace Linq.ExpressionBodiedMembers {
    public class Examples {
        private int value;

        // Constructors / Destructors (C# 7.0)
        public Examples(int value) => this.value = value;
        ~Examples() => this.value = 0;

        // Methods (C# 6.0)
        public int Sum(int x, int y) => x + y;

        public int GetZero() => 0;
        public void Print() => Console.WriteLine("Hello");

        // Properties (C# 6.0)
        public int Zero => 0;
        public int Bla => Sum(Zero, 2);

        // Getters/Setters (C# 7.0)
        public int Value {
            get => this.value;
            set => this.value = value;
        }
    }
}
