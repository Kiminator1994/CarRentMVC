﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }



    }
}
