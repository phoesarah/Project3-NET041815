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

            
            // for each line in excel document I want to create a product and send that to the list. listofallproducts
           // Product productbyline = new Product();

            var productlist = File.ReadAllLines("D:/Workprograms/Projects for class/Project3-NET041815/resources/New Text Document.txt");
            foreach (var line in productlist)
            {
                //split the line on tab
               var items = line.Split('\t');
                //take the things it splits on each line, and create a product out of each index add that product to listofallproducts
                //for (int i = 0; i < items.Length; i++)
               // 
                 //outside bounds of array... fix ? 
                    var product = new Product(items[0],  items[1], items[2], Convert.ToDouble(items[3]), Convert.ToInt32(items[4]));
                    listofallproducts.Add(product);
                //}
                //add product just created to the list ? 
                
            }
//write what i'm getting so i know what it's doing-- YES IT IS ACTUALLY PUTTING THE STUFF IN THE LIST THANK THE LORD 
          //  for (int i = 0; i < listofallproducts.Count; i++)
         //  {
              
        //       Console.WriteLine(listofallproducts[i].Category + listofallproducts[i].ItemNumber +
         //          listofallproducts[i].ItemName + listofallproducts[i].Price + listofallproducts[i].NumberInStock);
        //   }




            Random walletamount = new Random(); 
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
                    ViewProductsByCategory();
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
               
                input = Console.ReadLine();
            }

            if (input == "q" || input == "Q")
            {
                Environment.Exit(0);
            }
           
            
        }

       

        private static void ViewWallet(Random walletamount)
        {
            throw new NotImplementedException();
        }

        private static void ViewShoppingCart(List<Product> shoppingcart)
        {
            throw new NotImplementedException();
        }

        private static void ViewAllProducts(List<Product> listofallproducts)
        {
            throw new NotImplementedException();
        }

        private static void ViewProductsByCategory()
        {
            throw new NotImplementedException();
        }

       
        private static void CallMenu()
        {
            Console.WriteLine("Welcome, customer!");
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
