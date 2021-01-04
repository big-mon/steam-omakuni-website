using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamOmakuni.Models.Data
{
    public class Price
    {
        public enum Currencys
        {
            USD,
            JPY
        }

        public string Currency { get; }
        public decimal Initial { get; }
        public decimal Final { get; }
        public int DiscountPercent { get; }

        public Price(string currency, decimal initial, decimal final, int discount)
        {
            Currency = currency;
            Initial = initial;
            Final = final;
            DiscountPercent = discount;

            if (Currencys.JPY.ToString() == Currency)
            {
                Initial = Math.Round(Initial);
                Final = Math.Round(Final);
            }
        }
    }
}
