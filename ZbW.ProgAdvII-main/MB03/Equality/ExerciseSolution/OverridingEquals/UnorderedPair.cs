using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingEquals {
    public class UnorderedPair : IPair {
        public UnorderedPair(object first, object second) {
            this.First = first;
            this.Second = second;
        }
        public object First { get;  }
        public object Second { get; }

        public override bool Equals(object value) {
            return Equals(value as UnorderedPair);
        }

        public bool Equals(UnorderedPair pair) {
            if (Object.ReferenceEquals(null, pair)) return false;
            if (Object.ReferenceEquals(this, pair)) return true;

            return (object.Equals(this.First, pair.First) && object.Equals(this.Second, pair.Second)) || (object.Equals(this.First, pair.Second) && object.Equals(this.Second, pair.First));
        }

        public override int GetHashCode() {
            unchecked {
                // Hier nur zusammenzählen - sonst ist der HashCode wieder von der Reihenfolge abhängig.
                // Choose large primes to avoid hashing collisions
                return  (!Object.ReferenceEquals(null, this.First) ? this.First.GetHashCode() : 0) + (!Object.ReferenceEquals(null, this.Second) ? this.Second.GetHashCode() : 0);
            }
        }

        public static bool operator ==(UnorderedPair pairA, UnorderedPair pairB) {
            if (Object.ReferenceEquals(pairA, pairB)) {
                return true;
            }

            if (Object.ReferenceEquals(null, pairA)) {
                return false;
            }

            return (pairA.Equals(pairB));
        }

        public static bool operator !=(UnorderedPair pairA, UnorderedPair pairB) {
            return !(pairA == pairB);
        }
    }
}
