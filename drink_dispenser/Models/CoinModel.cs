using System;
using System.Collections.Generic;
using System.Text;

namespace drink_distributor.Models
{
    public class CoinModel
    {
        public float coinValue { get; set; }
        public int coinQuantity { get; set; }
        public int coinPosition { get; set; }

        public string coinID { get; set; }
        public CoinModel(float Value = 0, int Quantity = 0)
        {
            coinValue = Value;
            coinQuantity = Quantity;
        }
    }
}
