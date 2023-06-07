using System;
using Linq.ExtensionMethods;

namespace Linq {
    public class Program {
        public static void Main(string[] args) {
            new Linq.Ueberblick.Examples().Test();

            //ExpressionTrees.Examples.TestIntro();
            //LinqToXml.LinqToXml.Execute();

            new Linq.ExtensionMethods.Examples().TestDeferredEvaluation();

            ExpressionTrees.Examples.TestPrintExpressionTree();
            ExpressionTrees.Examples.TestBuildAnExpressionTree();

            //new LambdaExpressions.TypeInference.cs.Examples().TestRefOut();

            //new Linq.Initializers.Examples().TestCollectionInitializers();
            //new Linq.Initializers.Examples().TestObjectInitializers();
            //new Linq.Initializers.Examples().TestCombination();

            new Linq.LambdaExpressions.AnonymousTypes.Examples().Test();

            //new Linq.LambdaExpressions.QueryExpressions.Examples().TestQuerySyntaxSelectMany();
            //new Linq.LambdaExpressions.QueryExpressions.Examples().TestQuerySyntaxGroup();
            new Linq.LambdaExpressions.QueryExpressions.Examples().TestQuerySyntaxGroupInto();
            //new Linq.LambdaExpressions.QueryExpressions.Examples().TestQuerySyntaxLeftOuterJoin();

            new Linq.LambdaExpressions.QueryExpressions.Examples().TestQuerySyntaxSelectMany();

            new Examples().TestDeferredEvaluation();
        }
    }
}