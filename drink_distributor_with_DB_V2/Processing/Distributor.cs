using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using drink_distributor.Models;


namespace drink_distributor_with_DB_V2.Processing
{
    class Distributor
    {
        // VARIABLES
        static float selectedCoinValue = 0.0f;
        static string selectedDrink;
        static float moneyDifference = 0.0f;

        // static List<CoinModel> CoinList = DbConnection.Index();
        // static float d = CoinList[1].coinValue;

        static List<CoinModel> CoinList = DbConnection.GetCoinsFromDb();
        static List<DrinkModel> ItemList = DbConnection.GetItemsFromDb();

        static CoinModel coin1C = new CoinModel(CoinList[0].coinValue, CoinList[0].coinQuantity, CoinList[0].coinID);
        static CoinModel coin2C = new CoinModel(CoinList[1].coinValue, CoinList[1].coinQuantity, CoinList[1].coinID);
        static CoinModel coin5C = new CoinModel(CoinList[2].coinValue, CoinList[2].coinQuantity, CoinList[2].coinID);
        static CoinModel coin10C = new CoinModel(CoinList[3].coinValue, CoinList[3].coinQuantity, CoinList[3].coinID);
        static CoinModel coin20C = new CoinModel(CoinList[4].coinValue, CoinList[4].coinQuantity, CoinList[4].coinID);
        static CoinModel coin50C = new CoinModel(CoinList[5].coinValue, CoinList[5].coinQuantity, CoinList[5].coinID);
        static CoinModel coin1Eur = new CoinModel(CoinList[6].coinValue, CoinList[6].coinQuantity, CoinList[6].coinID);
        static CoinModel coin2Eur = new CoinModel(CoinList[7].coinValue, CoinList[7].coinQuantity, CoinList[7].coinID);

        DrinkModel coca = new DrinkModel(ItemList[0].itemName, 1.35f, 12, 1);
        DrinkModel fanta = new DrinkModel(ItemList[1].itemName, 1.49f, 20, 2);
        DrinkModel sprite = new DrinkModel(ItemList[2].itemName, 1.23f, 22, 3);



        // METHODES
        public void SelectDrink()
        {

            Console.WriteLine("_____________________________________________");
            Console.WriteLine("");
            Console.WriteLine("Hello");
            Console.WriteLine();
            Console.WriteLine("Please select a drink : ");

            foreach (var drink in ItemList)
            {
                Console.WriteLine(drink.itemPosition + " : " + drink.itemName);
            }


            Console.WriteLine();
            selectedDrink = Console.ReadLine();
            int selectedDrink_num = int.Parse(selectedDrink);


            if (ItemList.Any(a => a.itemPosition == selectedDrink_num))
            {
                Console.WriteLine("You selected " + ItemList.FirstOrDefault(a => a.itemPosition == selectedDrink_num).itemName);
                PayDrink(selectedDrink_num);
            }
            else
            {
                Console.WriteLine("Please Select again");
                SelectDrink();
            }

        }


        public float SelectedCoin()
        {
            Console.WriteLine("Select coin for paying");
            Console.WriteLine("______________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("[1] " + coin1C.coinValue + " cent");
            Console.WriteLine("[2] " + coin2C.coinValue + " cents");
            Console.WriteLine("[3] " + coin5C.coinValue + " cents");
            Console.WriteLine("[4] " + coin10C.coinValue + " cents");
            Console.WriteLine("[5] " + coin20C.coinValue + " cents");
            Console.WriteLine("[6] " + coin50C.coinValue + " cents");
            Console.WriteLine("[7] " + coin1Eur.coinValue + " euro");
            Console.WriteLine("[8] " + coin2Eur.coinValue + " euro");
            Console.WriteLine("______________________________________");
            Console.WriteLine(" ");


            string selectedcoin = Console.ReadLine();
            selectedcoin = selectedcoin.Trim();
            if (selectedcoin == "")
            {
                Console.WriteLine("*** PLEASE SELECT A COIN ***");
                return 0;

            }
            else
            {
                int selectedcoin_num = int.Parse(selectedcoin);
                float coinSelected = 0.0f;

                switch (selectedcoin_num)
                {
                    case 1:
                        coinSelected = coin1C.coinValue;
                        break;
                    case 2:
                        coinSelected = coin2C.coinValue;
                        break;
                    case 3:
                        coinSelected = coin5C.coinValue;
                        break;
                    case 4:
                        coinSelected = coin10C.coinValue;
                        break;
                    case 5:
                        coinSelected = coin20C.coinValue;
                        break;
                    case 6:
                        coinSelected = coin50C.coinValue;
                        break;
                    case 7:
                        coinSelected = coin1Eur.coinValue;
                        break;
                    case 8:
                        coinSelected = coin2Eur.coinValue;
                        break;


                }
                return coinSelected;
            }
        }

        public void PayDrink(int drinkSelection)
        {

            try
            {
                switch (drinkSelection)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("PRICE FOR --> " + coca.itemName + " " + coca.itemPrice + " €");
                        Console.WriteLine();
                        selectedCoinValue = SelectedCoin();
                        CalculateitemPrice(selectedCoinValue, coca.itemPrice);
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("PRICE FOR --> " + fanta.itemName + " " + fanta.itemPrice + " €");
                        Console.WriteLine();
                        selectedCoinValue = SelectedCoin();
                        CalculateitemPrice(selectedCoinValue, fanta.itemPrice);
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("PRICE FOR --> " + sprite.itemName + " " + sprite.itemPrice + " €");
                        Console.WriteLine();
                        selectedCoinValue = SelectedCoin();
                        CalculateitemPrice(selectedCoinValue, sprite.itemPrice);
                        break;
                }
            }
            catch
            {
                /*Console.WriteLine("Please insert a Coin");
                Console.WriteLine("*************************************************");
                Console.WriteLine("There is still " + moneyDifference + " € missing");
                Console.WriteLine("*************************************************");*/
                PayDrink(drinkSelection);
            }
        }

        public void CalculateitemPrice(float coins, float itemPrice)
        {

            if (coins < itemPrice)
            {
                moneyDifference = itemPrice - coins;
                moneyDifference = RoundNumber(moneyDifference);
                Console.WriteLine("");
                Console.WriteLine("there is still " + moneyDifference + "€ missing");
                Console.WriteLine("");
                float missingMoneyValueF = SelectedCoin();

                moneyDifference = moneyDifference - missingMoneyValueF;
                moneyDifference = RoundNumber(moneyDifference);

                while (moneyDifference > 0.00)
                {
                    Console.WriteLine();
                    Console.WriteLine("there is still " + moneyDifference + "€ missing");
                    missingMoneyValueF = SelectedCoin();

                    moneyDifference = moneyDifference - missingMoneyValueF;
                    moneyDifference = RoundNumber(moneyDifference);
                }
                ReturnMoney(moneyDifference);
            }
            else
            {
                moneyDifference = itemPrice - coins;
                ReturnMoney(moneyDifference);
            }
            Console.WriteLine();

            moneyDifference = ConvertToPositivNumber(moneyDifference);
            moneyDifference = RoundNumber(moneyDifference);
            Console.WriteLine("Here is your change " + moneyDifference + "€ ");
            Console.WriteLine();
            Console.WriteLine("And drink number " + selectedDrink);

            SelectDrink();
        }


        // Convert negativ number into positiv
        public float ConvertToPositivNumber(float number)
        {
            number = number * -1;

            return number;
        }

        // Round Number to 2 decimal places
        public float RoundNumber(float coinsValue)
        {
            //coinsValue = (float)Math.Round(coinsValue * 100f) / 100f;

            coinsValue = (float)Math.Round(coinsValue, 2);

            return coinsValue;
        }

        public void ReturnMoney(float moneyGiveBack)
        {
            moneyGiveBack = RoundNumber(moneyGiveBack);
            moneyGiveBack = ConvertToPositivNumber(moneyGiveBack);

            Console.WriteLine("Coins before Quantity : " + coin1C.coinQuantity + " / value : " + coin1C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin2C.coinQuantity + " / value : " + coin2C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin5C.coinQuantity + " / value : " + coin5C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin10C.coinQuantity + " / value : " + coin10C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin20C.coinQuantity + " / value : " + coin20C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin50C.coinQuantity + " / value : " + coin50C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin1Eur.coinQuantity + " / value : " + coin1Eur.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin2Eur.coinQuantity + " / value : " + coin2Eur.coinValue);

            Console.WriteLine("Monnaie rendu de : (" + selectedCoinValue + ")");

            while (moneyGiveBack != 0.0f)
            {
                if ((coin2Eur.coinValue <= moneyGiveBack) && (coin2Eur.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin2Eur.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin2Eur.coinQuantity = coin2Eur.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 2 euro");
                }
                else if ((coin1Eur.coinValue <= moneyGiveBack) && (coin1Eur.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin1Eur.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin1Eur.coinQuantity = coin1Eur.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 1 euro");
                }
                else if ((coin50C.coinValue <= moneyGiveBack) && (coin50C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin50C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin50C.coinQuantity = coin50C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 50 cents");
                }
                else if ((coin20C.coinValue <= moneyGiveBack) && (coin20C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin20C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin20C.coinQuantity = coin20C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 20 cents");
                }
                else if ((coin10C.coinValue <= moneyGiveBack) && (coin10C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin10C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin10C.coinQuantity = coin10C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 10 cents");
                }
                else if ((coin5C.coinValue <= moneyGiveBack) && (coin5C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin5C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin5C.coinQuantity = coin5C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 5 cents");
                }
                else if ((coin2C.coinValue <= moneyGiveBack) && (coin2C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin2C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin2C.coinQuantity = coin2C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 2 cents");
                }
                else if ((coin1C.coinValue <= moneyGiveBack) && (coin1C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin1C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin1C.coinQuantity = coin1C.coinQuantity - 1;
                    coin1C.coinValue = (float)Math.Round(coin1C.coinValue, 2);
                    Console.WriteLine("\t - Piece : 1 cent");
                }
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Coins after Quantity : " + coin1C.coinQuantity + " / value : " + coin1C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin2C.coinQuantity + " / value : " + coin2C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin5C.coinQuantity + " / value : " + coin5C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin10C.coinQuantity + " / value : " + coin10C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin20C.coinQuantity + " / value : " + coin20C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin50C.coinQuantity + " / value : " + coin50C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin1Eur.coinQuantity + " / value : " + coin1Eur.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin2Eur.coinQuantity + " / value : " + coin2Eur.coinValue);



            List<CoinModel> UpdatedCoinList = new List<CoinModel>();
            UpdatedCoinList.Add(new CoinModel(coin1C.coinValue, coin1C.coinQuantity , coin1C.coinID));
            UpdatedCoinList.Add(new CoinModel(coin2C.coinValue, coin2C.coinQuantity, coin2C.coinID));
            UpdatedCoinList.Add(new CoinModel(coin5C.coinValue, coin5C.coinQuantity, coin5C.coinID));
            UpdatedCoinList.Add(new CoinModel(coin10C.coinValue, coin10C.coinQuantity, coin10C.coinID));
            UpdatedCoinList.Add(new CoinModel(coin20C.coinValue, coin20C.coinQuantity, coin20C.coinID));
            UpdatedCoinList.Add(new CoinModel(coin50C.coinValue, coin50C.coinQuantity, coin50C.coinID));
            UpdatedCoinList.Add(new CoinModel(coin1Eur.coinValue, coin1Eur.coinQuantity, coin1Eur.coinID));
            UpdatedCoinList.Add(new CoinModel(coin2Eur.coinValue, coin2Eur.coinQuantity, coin2Eur.coinID));


            string connetionString = null;
            //List<CoinModel> coinList = new List<CoinModel>();

            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            //SqlDataReader dataReader;
            connetionString = "Data Source=localhost;Database=distributor;Integrated Security=true;";
            sql = "UPDATE coins SET coinQuantity = @Quantity where coinID = @ID";
            connection = new SqlConnection(connetionString);
            try
            {
                
                connection.Open();
                foreach (var co in UpdatedCoinList)
                {
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Quantity", co.coinQuantity);
                    command.Parameters.AddWithValue("@ID", co.coinID);
                    
                    int count = command.ExecuteNonQuery();
                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }
      

    }
}
