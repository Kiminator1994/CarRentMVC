using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopySolution {
    class Program {
        static void Main(string[] args) {
            var rect1 = new Rectangle(new Point2D(10, 20), 100, 80, Color.Red);
            var rect2 = rect1.CopyDeep();
            rect2.Location.X += 10;
            var eq = rect1.Location.X == rect2.Location.X; // false;

            var circle1 = new Circle(new Point2D(20, 50), 100, Color.Green);
            var circle2 = (Circle) circle1.CopyShallow();
            circle2.Location.Y += 100;
            eq = circle1.Location.Y == circle2.Location.Y; // true
            circle1.AreaColor = Color.Yellow;
            eq = circle1.AreaColor == circle2.AreaColor; // false

            Stack.TestStack();
        }

    }
}