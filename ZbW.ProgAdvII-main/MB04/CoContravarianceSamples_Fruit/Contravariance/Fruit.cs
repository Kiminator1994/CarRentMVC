using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance {
    public class Fruit {
        public string Name { get; set; }
        public double Weight { get; set; }

        public override string ToString() {
            return $"{Name} ({Weight}g)";
        }
    }

    public class Apple : Fruit {
        public bool ForEating { get; set; }

        public override string ToString() {
            return $"{base.ToString()} is for {(ForEating ? "eating" : "cooking")}";
        }
    }

    public class Banana : Fruit {
        public override string ToString() {
            return $"{base.ToString()}";
        }
    }
}