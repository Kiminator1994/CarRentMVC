using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingEquals {
    public class OrderedPair : IPair {
        public OrderedPair(object first, object second) {
            this.First = first;
            this.Second = second;
        }
        public object First { get; }
        public object Second { get; }


        public override bool Equals(object value) {
            return Equals(value as OrderedPair);
        }

        public bool Equals(OrderedPair pair) {
            if (Object.ReferenceEquals(null, pair)) return false;
            if (Object.ReferenceEquals(this, pair)) return true;

            return object.Equals(this.First, pair.First) && object.Equals(this.Second, pair.Second);
        }

        public override int GetHashCode() {
            unchecked {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.First) ? this.First.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.Second) ? this.Second.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(OrderedPair pairA, OrderedPair pairB) {
            if (Object.ReferenceEquals(pairA, pairB)) {
                return true;
            }

            if (Object.ReferenceEquals(null, pairA)) {
                return false;
            }

            return (pairA.Equals(pairB));
        }

        public static bool operator !=(OrderedPair pairA, OrderedPair pairB) {
            return !(pairA == pairB);
        }
    }
}
