using System;

namespace ShopperAutofac {
    class Program {
        static void Main(string[] args) {
            // TODO: Configure and use Autofac


            shopper.Charge();
            // Erwartete Ausgabe:
            //    Do Eft-Transaction.
            //    Chaaaarging with the Visa!

            Console.Read();
        }
    }

    public abstract class CreditCard : ICreditCard {
        public readonly ITerminal terminal;
        public CreditCard(ITerminal terminal) {
            this.terminal = terminal;
        }
        public void TrxTerminal() {
            this.terminal.Trx();
        }
        public abstract string Charge();
    }

    public class Visa : CreditCard {
        public Visa(ITerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Chaaaarging with the Visa!";
        }
    }

    public class MasterCard : CreditCard {
        public MasterCard(ITerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Swiping the MasterCard!";
        }
    }

    public class EftTerminal : ITerminal {
        public void Trx() {
            Console.WriteLine("Do Eft-Transaction.");
        }
    }

    public class Shopper {
        private readonly ICreditCard creditCard;

        public Shopper(ICreditCard creditCard) {
            this.creditCard = creditCard;
        }

        public void Charge() {
            var chargeMessage = creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }

    public interface ICreditCard {
        string Charge();
    }

    public interface ITerminal {
        void Trx();
    }
}
