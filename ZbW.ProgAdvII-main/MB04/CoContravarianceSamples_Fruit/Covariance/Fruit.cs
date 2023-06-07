using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariance
{
    public class Fruit {
        public decimal Weight { get; set; }
    }

    public class Apple : Fruit {
        public override string ToString() {
            return "Apple";
        }
    }

    public class Banana : Fruit {
        public override string ToString() {
            return "Banana";
        }
    }
}
