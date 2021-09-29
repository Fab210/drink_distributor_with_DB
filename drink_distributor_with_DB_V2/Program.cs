using System.Collections.Generic;
using System.Data.SqlClient;
using drink_distributor_with_DB_V2.Processing;
using System;


namespace drink_distributor_with_DB_V2
{
    class Program
    {




        static void Main(string[] args)
        {
            // Convert special symbols to show on console ex : €
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            /*var CoinList = Distributor.Index();

            foreach (var item in CoinList)
            {
                Console.WriteLine("\nCoin Value " + item.coinValue + "/ Coin Quantity " + item.coinQuantity);

            }*/



            Distributor p = new Distributor();
            p.SelectDrink();




        }
    }
}
