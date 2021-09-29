using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using drink_distributor.Models;


namespace drink_distributor.Processing
{
    class DbConnection
    {

        public static List<CoinModel> GetCoinsFromDb()
        {
            string connetionString = null;
            List<CoinModel> coinList = new List<CoinModel>();

            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = "Data Source=localhost;Database=distributor;Integrated Security=true;";
            sql = "SELECT * From coins order by coinValue";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    CoinModel coins = new CoinModel();
                    coins.coinID = Convert.ToString(dataReader["coinID"]);
                    coins.coinPosition = Convert.ToInt32(dataReader["coinPosition"]);
                    coins.coinValue = Convert.ToSingle(dataReader["coinValue"]);
                    coins.coinQuantity = Convert.ToInt32(dataReader["coinQuantity"]);
                    //Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                    coinList.Add(coins);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            return coinList;
        }

        public static List<DrinkModel> GetItemsFromDb()
        {
            string connetionString = null;
            List<DrinkModel> drinkList = new List<DrinkModel>();

            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = "Data Source=localhost;Database=distributor;Integrated Security=true;";
            sql = "SELECT * From dis_items order by itemPosition";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DrinkModel drinks = new DrinkModel();
                    drinks.id = Convert.ToString(dataReader["id"]);
                    drinks.itemPosition = Convert.ToInt32(dataReader["itemPosition"]);
                    drinks.itemName = Convert.ToString(dataReader["itemName"]);
                    drinks.itemQuantity = Convert.ToInt32(dataReader["itemQuantity"]);
                    //Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                    drinkList.Add(drinks);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            return drinkList;
        }
    }
}
