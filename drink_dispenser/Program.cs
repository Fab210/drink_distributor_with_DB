using drink_distributor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using drink_distributor.Processing;


namespace drink_distributor
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
