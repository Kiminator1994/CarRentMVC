using System;
using System.Threading.Tasks;

namespace Pitfall4 {
    public class BankAccount {
        private int _balance = 0;

        public void Deposit(int amount) {
            _balance += amount;
        }

        public bool Withdraw(int amount) {
            if (amount <= _balance) {
                _balance -= amount;
                return true;
            } else {
                return false;
            }
        }

        public int Balance {
            get { return _balance; }
        }
    }

    public class RaceSample {
        public async Task CustomerBehaviorAsync(BankAccount account) {
            await Task.Run(() => { Console.WriteLine("Start"); });
            // runs as continuation
            for (int i = 0; i < 1000000; i++) {
                account.Deposit(100);
                account.Withdraw(100);
            }
        }

        public async Task TestRunAsync() {
            var account = new BankAccount();
            var customer1 = CustomerBehaviorAsync(account);
            var customer2 = CustomerBehaviorAsync(account);
            await customer1;
            await customer2;
            if (account.Balance != 0) {
                throw new Exception(string.Format("Race condition occurred: Balance is {0}", account.Balance));
            }
        }
    }
}
