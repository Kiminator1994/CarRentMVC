using System.ComponentModel;

namespace ReflectionAttributes.Reflection
{
    public class Counter : INotifyPropertyChanged
    {
        private Counter() {}
        public Counter(int value) { this.countValue = value; }

        private int countValue;
        public event PropertyChangedEventHandler PropertyChanged;

        public int CountValue
        {
            get { return countValue; }
            set
            {
                countValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountValue"));
            }
        }

        public void Increment() { CountValue++; }
        public void Decrement() { CountValue--; }

    }
}
