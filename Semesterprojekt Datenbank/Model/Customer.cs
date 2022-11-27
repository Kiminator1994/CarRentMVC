﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semesterprojekt_Datenbank.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public Town TownId { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
