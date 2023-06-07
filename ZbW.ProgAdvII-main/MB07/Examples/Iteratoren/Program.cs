using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteratoren.Extensions;
using Iteratoren.Yield;

namespace Iteratoren {
    public class Program {
        public static void Main(string[] args) {
            new ForeachLoop().TestBasic();
            new ForeachLoop().TestOwn();
            new Iterator.Examples().TestGeneric();
            new Iterator.Examples().TestNonGeneric();
            new Iteratoren.Yield.Examples().TestYield();
            new Specific.Examples().TestStandard();
            new Specific.Examples().TestSpecificMethod();
            new Specific.Examples().TestSpecificProperty();
            new ExtensionTest().Test();
            new DeferredEvaluation.Examples().TestDeferredEvaluation();
            new DeferredEvaluation.Examples().TestDeferredEvaluationChained();
            Iteratoren.DeferredEvaluationLinq.Extensions.Test();

            Console.ReadKey();
        }
    }
}