using System;

namespace LambdaExpressions.Ueberblick {
    public class Examples {
        public void Test() {
            // Expression Lambda
            Func<int, bool> fe = i => i % 2 == 0;

            // Statement Lambda
            Func<int, bool> fs = i => {
                int rest = i % 2;
                bool isRestZero = rest == 0;
                return isRestZero;
            };

        }
    }
}
