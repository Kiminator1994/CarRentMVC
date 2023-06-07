using System;
using System.Collections.Generic;
using System.Linq;

namespace IoCContainerDemo {
    class Program {
        static void Main(string[] args) {
            // 1. Variante (einfache Dependency Injection ohne Container)
            //     Shopper ist nicht abhängig von MasterCard - nur vom Interface ICreditCard
            ICreditCard creditCard = new MasterCard();
            var shopper = new Shopper(creditCard);
            shopper.Charge();
            // Nachteil: Jeder Code der Shopper verwendet muss wissen, wie 
            //           ICreditCard erstellt werden muss

            // ******************************************************************************************





            Console.Read();
        }
    }


    public abstract class CreditCard : ICreditCard {
        public CreditCard() {
        }

        public abstract string Charge();
    }
    public class Visa : CreditCard {
        public Visa()  { }
        public override string Charge() {
            return "Chaaaarging with the Visa!";
        }
    }

    public class MasterCard : CreditCard {
        public MasterCard()  { }
        public override string Charge() {
            return "Swiping the MasterCard!";
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


}
