﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semesterprojekt_Datenbank.Model
{
    public class Position
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal PriceNetto { get; set; }
        public decimal PriceBrutto { get; set; }
        public int ArticleId { get; set; }
        public int OrderId { get; set; }
        public Article Article { get; set; }
        public Order Order { get; set; }
    }
}
