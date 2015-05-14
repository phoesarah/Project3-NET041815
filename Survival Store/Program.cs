using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Survival_Store
{
    class Program
    {
        static void Main(string[] args) 
        {
            var listofallproducts = new List<Product>(); 
            var shoppingcart = new List<Product>();
            var productlist = File.ReadAllLines("D:/Workprograms/Projects for class/Project3-NET041815/resources/New Text Document.txt");
            
            // for each line in excel document I want to create a product and send that to the list. listofallproducts
            
            foreach (var line in productlist)
            {
                //split the line on tab
               var items = line.Split('\t');
                //take the things it splits on each line, and create a product out of each index add that product to listofallproducts
                //for (int i = 0; i < items.Length; i++)
              
               var product = new Product(items[0],  items[1], items[2], Convert.ToDouble(items[3]), Convert.ToInt32(items[4]));
                    listofallproducts.Add(product);
            }

//write what i'm getting so i know what it's doing-- YES IT IS ACTUALLY PUTTING THE STUFF IN THE LIST THANK THE LORD 
//            for (int i = 0; i < listofallproducts.Count; i++)
//          {
              
//             Console.WriteLine(listofallproducts[i].Category + listofallproducts[i].ItemNumber +
//               listofallproducts[i].ItemName + listofallproducts[i].Price + listofallproducts[i].NumberInStock);
//          }

            double walletamount = 3000; //make into a random later
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


        private static void makepurchase(Product product)
        {
            //write code here for what happens if you want to buy something on one of the lists, then put the writelines in the methods that call this
            //method and then do all the calculating and wallet stuff here.
        }
        private static void ViewWallet(Double walletamount)
        {
            Console.WriteLine("You currently have $" + Convert.ToString(walletamount));
        }

        private static void ViewShoppingCart(List<Product> shoppingcartlist)
        {
            for (int i = 0; i < shoppingcartlist.Count; i++)
            {

                Console.WriteLine("Product Number: " + shoppingcartlist[i].ItemNumber + " Category: " + shoppingcartlist[i].Category + " Product: " +
                  shoppingcartlist[i].ItemName + " Price: " + shoppingcartlist[i].Price + " We currently have " + shoppingcartlist[i].NumberInStock + " in stock.");
            }
        }

        private static void ViewAllProducts(List<Product> listofallproducts)
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

   
    class Product
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
