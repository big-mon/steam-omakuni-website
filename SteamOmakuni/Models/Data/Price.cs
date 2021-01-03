using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamOmakuni.Models.Data
{
    public class Price
    {
        public string Currency { get; }
        public decimal Initial { get; }
        public decimal Final { get; }
        public int DiscountPercent { get; }
    }
}
