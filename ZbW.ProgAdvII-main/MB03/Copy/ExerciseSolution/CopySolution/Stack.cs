using System;

namespace CopySolution {
    public class Stack : ICloneable {
        private object[] items;

        public int Count { get; private set; }

        public Stack(int length = 0) {
            items = new object[length == 0 ? 10 : length];
        }

        public void Push(object item) {
            grow();

            items[Count] = item;

            Count++;
        }

        public object Peek() {
            if (Count == 0)
                throw new InvalidOperationException("No items on stack.");

            return items[Count - 1];
        }

        public object Pop() {
            if (Count == 0)
                throw new InvalidOperationException("No items on stack.");

            object item = items[Count - 1];
            items[Count - 1] = default(object);
            Count--;

            return item;
        }

        public void Clear() {
            items = new object[10];
            Count = 0;
        }

        private void grow() {
            // Überprüfen, ob noch Platz
            if (items.Length >= Count + 1)
                return;

            // Array-Kapazität verdoppeln
            int newLength = items.Length * 2;

            Array.Resize(ref items, newLength);
        }

        public override bool Equals(object value) {
            return Equals(value as Stack);
        }

        public bool Equals(Stack stack) {
            if (Object.ReferenceEquals(null, stack)) return false;
            if (Object.ReferenceEquals(this, stack)) return true;

            if (this.Count == 0 && stack.Count == 0) {
                return true;
            }

            if (this.Count != stack.Count) {
                return false;
            }

            if (stack.items.Equals(this.items)) {
                return true;
            }

            for (var i = 0; i < this.Count; i++) {
                if (!object.Equals(this.items[i], stack.items[i])) {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() {
            unchecked {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, items) ? this.items.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(Stack stackA, Stack stackB) {
            if (Object.ReferenceEquals(stackA, stackB)) {
                return true;
            }

            if (Object.ReferenceEquals(null, stackA)) {
                return false;
            }

            return (stackA.Equals(stackB));
        }

        public static bool operator !=(Stack stackA, Stack stackB) {
            return !(stackA == stackB);
        }

        public object Clone() {
            // MemberwiseClone geht nicht, da dann beide Stacks das gleiche items-Array besitzen
            var ret = new Stack(this.items.Length);
            for (var i =0; i < this.Count ; i++) {
                ret.Push(this.items[i]);
            }
            return ret;
        }

        public static void TestStack() {
            twoEmptyStacksWithSameCapacityShouldBeEqual();
            twoEmptyStacksWithDifferentCapacitiesShouldNotEqual();
            stackIsEqualToSelf();
            stacksWithEqualElementsShouldBeEqual();
            cloningShouldResultInEqualStacks();
            cloningAndChangingAStackShouldNotBeEqual();
        }

        private static void twoEmptyStacksWithSameCapacityShouldBeEqual() {
            Stack stack1 = new Stack(5);
            Stack stack2 = new Stack(5);
            Console.WriteLine(stack1 == stack2);
        }

        private static void twoEmptyStacksWithDifferentCapacitiesShouldNotEqual() {
            Stack stack1 = new Stack(1);
            Stack stack2 = new Stack(2);
            Console.WriteLine(stack1 == stack2);
        }

        private static void stackIsEqualToSelf() {
            Stack stack1 = new Stack(1);
            Console.WriteLine(stack1 == stack1);
        }

        private static void stacksWithEqualElementsShouldBeEqual() {
            Stack stack1 = new Stack(1);
            stack1.Push("ZbW");
            Stack stack2 = new Stack(1);
            stack2.Push("ZbW");
            Console.WriteLine(stack1 == stack2);
        }

        private static void cloningShouldResultInEqualStacks() {
            Stack stack1 = new Stack(2);
            stack1.Push("Hello");
            stack1.Push("ZbW");
            Stack stack2 = (Stack)stack1.Clone();
            Console.WriteLine(stack1 == stack2);
        }

        private static void cloningAndChangingAStackShouldNotBeEqual() {
            Stack stack1 = new Stack(2);
            Stack stack2 = (Stack)stack1.Clone();
            stack1.Push("Hello");
            Console.WriteLine(stack1 != stack2);
        }

    }
}
