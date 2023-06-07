using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Linq.ExpressionTrees {
    public class Examples {
        public static void TestIntro() {
            Func<int, bool> f = n => n < 5;
            Expression<Func<int, bool>> e = n => n < 5;

            // isSmall is now true
            bool isSmall = f(2);
            //isSmall = e(2); // compile error, expressions == data

            Expression<Func<string, int, bool>> filter = (str, num) => num > str.Length;
            BinaryExpression body = (BinaryExpression) filter.Body;
            ParameterExpression left = (ParameterExpression) body.Left;
            MemberExpression right = (MemberExpression) body.Right;
            ParameterExpression rightParam = (ParameterExpression) right.Expression;

            Console.WriteLine("{0} {1} {2}", left.Name, body.NodeType, right);
        }

        public static void TestPrintExpressionTree() {
            Expression<Func<int, bool>> f1 = n => n < 5;
            Expression<Func<int, bool>> f2 = n => n >= 0;

            PrintExpressionTree(f1);
            PrintExpressionTree(f2);

            Func<int, bool> f = f1.Compile();
            bool res = f(4); //works


            Expression<Func<int, double, double>> expression = (m, x) => m * x + 10;

            Func<int, double, double> f3 = expression.Compile();
            double y = f3(2, 7.5);

        }

        private static void PrintExpressionTree(Expression<Func<int, bool>> filter) {
            BinaryExpression body = (BinaryExpression) filter.Body;
            ParameterExpression left = (ParameterExpression) body.Left;
            ConstantExpression right = (ConstantExpression) body.Right;

            Console.WriteLine($"{filter.NodeType}: {left.Name} {body.NodeType} {right.Value}");
        }

        public static void TestBuildAnExpressionTree() {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "n");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);

            Expression<Func<int, bool>> lambda =
                Expression.Lambda<Func<int, bool>>(
                    numLessThanFive,
                    new ParameterExpression[] {numParam}
                );

            //compile expression to IL
            Func<int, bool> F6 = lambda.Compile();

            // Let the compiler generate the expression tree for 
            //the lambda expression n=> n< 5.
            Expression<Func<int, bool>> lambda2 = n => n <= 5;

            bool isF6 = F6(2);
            bool isLambda2 = lambda2.Compile()(2);
        }

    }
}