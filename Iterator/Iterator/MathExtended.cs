using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal static class MathExtended
    {
        public static IEnumerable GetFibonacciNums(int n)
        {
            int firstFiboNum = 0;
            int secondFiboNum = 1;
            for (int i = 0; i < n; i++)
            {
                if (i == 0) yield return 0;
                if (i == 1) yield return 1;
                if (i > 1)
                {
                    int nextFiboNum = firstFiboNum + secondFiboNum;
                    firstFiboNum = secondFiboNum;
                    secondFiboNum = nextFiboNum;
                    yield return nextFiboNum;
                }
                
            }
        }


    }
}
