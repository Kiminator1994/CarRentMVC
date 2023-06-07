using System;

namespace OverridingEquals {
    public class PhoneNumber {
        // First part of a phone number: (XXX) 000-0000
        public string AreaCode { get; set; }

        // Second part of a phone number: (000) XXX-0000
        public string Exchange { get; set; }

        // Third part of a phone number: (000) 000-XXXX
        public string SubscriberNumber { get; set; }

        // TODO: Implement Equals 
        // TODO: Implement == and !=
        // TODO: Implement GetHashCode
    }
}