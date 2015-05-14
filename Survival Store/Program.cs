using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Products> listofallproducts = new List<Products>(); 
            List<Products> shoppingcart = new List<Products>();
            Random walletamount = new Random(); 
            CallMenu();
            string input = Console.ReadLine();
            
            while (input != "q" || input != "Q")
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

                    break;
                }

            }
                input = Console.ReadLine();
            }
           
            
        }

        private static void ViewShoppingCart(List<Products> shoppingcart)
        {
            throw new NotImplementedException();
        }

        private static void ViewAllProducts(List<Products> listofallproducts)
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

   
    class Products
    {
    }
}
