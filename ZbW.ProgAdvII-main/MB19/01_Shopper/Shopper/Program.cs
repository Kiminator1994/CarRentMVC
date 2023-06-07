using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper {
    class Program {
        static void Main(string[] args) {
            var masterCard = new MasterCard(new EftTerminal());
            var shopper = new Shopper(masterCard);

            //var visa = new Visa(new EftTerminal());
            //var shopper = new Shopper(visa);
            shopper.Charge();

            Console.ReadKey();
        }
    }

    public class Shopper {
        private readonly MasterCard creditCard;

        public Shopper(MasterCard creditCard) {
            this.creditCard = creditCard;
        }

        public void Charge() {
            var chargeMessage = creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }

    public abstract class CreditCard {
        public readonly EftTerminal terminal;
        public CreditCard(EftTerminal terminal) {
            this.terminal = terminal;
        }
        public void TrxTerminal() {
            this.terminal.Trx();
        }
        public abstract string Charge();
    }

    public class Visa : CreditCard {
        public Visa(EftTerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Chaaaarging with the Visa!";
        }
    }

    public class MasterCard  : CreditCard {
        public MasterCard(EftTerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Swiping the MasterCard!";
        }
    }

    public class EftTerminal {
        public void Trx() {
            Console.WriteLine("Do Eft-Transaction.");
        }
    }
}
