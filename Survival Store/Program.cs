using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Survival_Store
{
    class Program
    {
       static List<Product> listofallproducts = new List<Product>();
        static List<Product> shoppingcart = new List<Product>();
        private static double walletamount;
        public static Product producttopurchase = null;
        static void Main(string[] args) 
        {
            
            var productlist = File.ReadAllLines("D:/Workprograms/Projects for class/Project3-NET041815/resources/New Text Document.txt");
            walletamount = 3000; 

            // for each line in document create a product and send that to the listofallproducts
            foreach (var line in productlist)
            {
                //split the line on tab
               var items = line.Split('\t');
                //take the things it splits on each line, and create a product out of each index add that product to listofallproducts
               var product = new Product(items[0],  items[1], items[2], Convert.ToDouble(items[3]), Convert.ToInt32(items[4]));
               listofallproducts.Add(product);
            }
            //make into a random later
            
            Console.WriteLine("Welcome, customer!");
            CallMenu();
            string input = Console.ReadLine();
            
            while (input != null && input.ToLower() != "q")
            {
               switch (input)

            {
                case "A":
                case "a":
                {
                    ViewAllProducts(listofallproducts);
                    break;  
                }

                    break;
                case "P":
                case "p":
                {
                    Console.WriteLine("Our categories are as follows: ");
                    Console.WriteLine("food");
                    Console.WriteLine("tools");
                    Console.WriteLine("first aid and medical");
                    Console.WriteLine("warmth and shelter");
                    Console.WriteLine("clothing");
                    Console.WriteLine("cooking and fuel");
                    Console.WriteLine("tools and supplies");
                    Console.WriteLine("survival kits");
                    Console.WriteLine("sanitation and hygiene");
                    Console.WriteLine("emergency power");
                    Console.WriteLine("light and communication");
                    Console.WriteLine("backpacks");
                    Console.WriteLine("Please enter the name of the category you would like to search for:");
               
               string category = Console.ReadLine().ToLower();
                    ViewProductsByCategory(listofallproducts, category);
                    break; 
                }
                    
                case "C":
                case "c":
                {
                    ViewShoppingCart(shoppingcart);
                    break;
                }
                    
                case "W":
                case "w":
                {
                    ViewWallet(walletamount);
                    break;
                }
                default:

                {
                    Console.WriteLine("Sorry, I didn't understand you");
                    break;
                }

            }
               CallMenu();
                input = Console.ReadLine();
                
            }
            

            if (input == "q" || input == "Q")
            {
                Environment.Exit(0);
            }
            
            
        }

      //  private static void makepurchase();
     //   {
            //to make purchase in your shopping cart and deduct the money and items in list. 
       // }
        


        private static void pickproducttobuy(List<Product> listofallproducts)
        {
            
            Console.WriteLine("To make a purchase please type in the product number of the item you would like to purchase");
            string purchasenumber = Console.ReadLine();
            Product  producttopurchase = null;
            for (int i = 0; i < listofallproducts.Count; i++)
            {
                if (listofallproducts[i].ItemNumber == purchasenumber)
                {
                    Console.WriteLine("Type 'Y' to confirm you would like to purchase: " +
                                      listofallproducts[i].ItemNumber + " Category: " +
                                      listofallproducts[i].Category + " Product: " +
                                      listofallproducts[i].ItemName + " Price: " + listofallproducts[i].Price +
                                      " We currently have " + listofallproducts[i].NumberInStock + " in stock.");
                    string confirmation = Console.ReadLine();
                    if (confirmation.ToLower() == "y")
                    {
                        producttopurchase = listofallproducts[i];
                        AddtoShoppingCart(producttopurchase);
                        break;
                    }
                   

                }

                

            }

                
        }

        private static void AddtoShoppingCart(Product producttopurchase)
        {
            shoppingcart.Add(producttopurchase);
        }
        private static void ViewWallet(Double walletamount)
        {
            Console.WriteLine("You currently have $" + Convert.ToString(walletamount));
        }

        private static void ViewShoppingCart(List<Product> shoppingcartlist)
        {
            if(shoppingcartlist != null)
            for (int i = 0; i < shoppingcartlist.Count; i++)
            {

                Console.WriteLine("Product Number: " + shoppingcartlist[i].ItemNumber + " Category: " + shoppingcartlist[i].Category + " Product: " +
                  shoppingcartlist[i].ItemName + " Price: " + shoppingcartlist[i].Price + " We currently have " + shoppingcartlist[i].NumberInStock + " in stock.");
            }
            else
            {
                Console.WriteLine("Sorry, you don't have anything in your cart");
            }
        }

        private static void ViewAllProducts(List<Product> listofallproducts)
        {
            ListProducts(listofallproducts);
             

            Console.WriteLine("To buy a product, please press Type 'B', to categorize all products, please press 'C', If not, please press enter");
            string input = Console.ReadLine();
            if (input.ToUpper() == "B")
            {
                pickproducttobuy(listofallproducts);
            }
            else if (input.ToUpper() == "C")
            {
                Console.WriteLine("Please type the option of which you would like to sort by: ");
                Console.WriteLine("1:   Category");
                Console.WriteLine("2:   Item Name");
                Console.WriteLine("3:   Price");
                Console.WriteLine("4:   Number we have in stock");
                Console.WriteLine("5:   Item Number");
                string sortby = Console.ReadLine();
                switch (sortby)
                {
                    case "1":

                    {
                        listofallproducts.Sort();

                        break;
                    }
                    case "2":
                    {
                        break;
                    }
                    case "3":
                    {
                        break;
                    }
                    case "4":
                    {
                        break;
                    }
                    case "5":
                    {
                        break;
                    }
                    default:
                        break;
                }

            }
           

        }

        private static void ListProducts(List<Product> listofallproducts)
        {
            for (int i = 0; i < listofallproducts.Count; i++)
            {

                Console.WriteLine("Product Number: " + listofallproducts[i].ItemNumber + " Category: " + listofallproducts[i].Category + " Product: " +
                  listofallproducts[i].ItemName + " Price: " + listofallproducts[i].Price + " We currently have " + listofallproducts[i].NumberInStock + " in stock.");
            }
        }

        private static void ViewProductsByCategory(List<Product> listofallproducts, string input)
        {
            if (input == "food" || input == "tools" || input == "first aid and medical" ||
                input == "warmth and shelter" || input == "clothing" || input == "cooking and fuel" ||
                input == "tools and supplies" || input == "survival kits" || input == "sanitation and hygiene" ||
                input == "emergency power" || input == "light and communication" || input == "backpacks")
            {


                for (int i = 0; i < listofallproducts.Count; i++)
                {
                    if (listofallproducts[i].Category == input)

                        Console.WriteLine("Product Number: " + listofallproducts[i].ItemNumber + " Category: " +
                                          listofallproducts[i].Category + " Product: " +
                                          listofallproducts[i].ItemName + " Price: " + listofallproducts[i].Price +
                                          " We currently have " + listofallproducts[i].NumberInStock + " in stock.");
                }
            }
            else
            {
                Console.WriteLine("I'm sorry, We don't have that category, please check your spelling");
            }
        }

       
        private static void CallMenu()
        {
            
            Console.WriteLine("If you would like to view all products, please type 'A'");
            Console.WriteLine("If you would like to view products by category, please type 'P'");
            Console.WriteLine("If you would like to view your shopping cart, please type 'C'");
            Console.WriteLine("If you would like to view your wallet, please type 'W'");
            Console.WriteLine("To quit, type'Q");
        }
        
    }
    // if i make a customer class that has a wallet and a shopping cart, and then pass that class. 
   
    public class Product
    {
        public string ItemNumber { get; set; }
        public string Category { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int NumberInStock { get; set; }

        public Product(string itemnumber, string category, string itemname, double price, int number)
        {
            ItemNumber = itemnumber;
            Category = category;
            ItemName = itemname;
            Price = price;
            NumberInStock = number;

        }
    }
}
