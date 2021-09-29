using System;
using System.Collections.Generic;
using System.Text;

namespace drink_distributor.Models
{
    public class DrinkModel
    {

        public string itemName { get; set; }
        public float itemPrice { get; set; }
        public int itemQuantity { get; set; }
        public int itemPosition { get; set; }
        public string id { get; set; }

        public DrinkModel(string Name = "", float Price = 0.0f ,int Quantity = 0, int Position = 0)
        {
            itemName = Name;
            itemPrice = Price;
            itemQuantity = Quantity;
            itemPosition = Position;

        }
    }
}
