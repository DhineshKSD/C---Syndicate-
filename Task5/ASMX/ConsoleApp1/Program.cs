using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using WebApplication1;

namespace ConsoleApp1
{
    public class Program
    {
        public static int purchaseprice = 0;
        public static ArrayList brandcart = new ArrayList();
        public static ArrayList pricecart = new ArrayList();
        public static ArrayList modelcart = new ArrayList();
        public static ArrayList quantity = new ArrayList();
        public static ArrayList tprice = new ArrayList();
        static void Main(string[] args)
        {   
            localhost.WebService1 obj = new localhost.WebService1();
            
            Console.WriteLine("Laptop Variants:");
            Console.WriteLine();

            string x = obj.GetLaptopJSON();

            dynamic lapvariant = JsonConvert.DeserializeObject(x);
            Console.ReadLine();
            LaptopRead.LapDisplay(lapvariant);
        }
        public static void purchase()
        {
            Console.WriteLine("Cart Total: Rs. {0}", purchaseprice);
            Console.ReadLine();
        }
        public void display()                    //Function to display cart items
        {
            Console.Clear();
            Console.WriteLine("Your Cart Items:");
            Console.WriteLine();
            Program.Cart();
            Program.purchase();
        }
        public void purchase1()                            //Function to display shops for selection
        {
            localhost.WebService1 obj = new localhost.WebService1();
            
            String x = obj.GetLaptopJSON();
            dynamic lapvariant = JsonConvert.DeserializeObject(x);
            String y = obj.GetpendriveJSON();
            dynamic pendrivevariant = JsonConvert.DeserializeObject(y);
            String z = obj.GetmouseJSON();
            dynamic mousevariant = JsonConvert.DeserializeObject(z);
            int choice;

            Console.Clear();
            Console.WriteLine("***************************** Welcome ******************************");
            Console.WriteLine();
            Console.WriteLine("------------Select the Shop 1/2/3 to display the Items--------------");
            Console.WriteLine();
            Console.WriteLine("-------> Shop-1: Laptops  Shop-2: Mouses  Shop-3: Pendrives <-------");

            Console.WriteLine();
            Console.Write("Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    //Console.Clear();
                    LaptopRead.LapDisplay(lapvariant);
                    Console.ReadKey();
                    break;
                case 2:
                    //Console.Clear();
                    MouseRead.MouseDisplay(mousevariant);
                    Console.ReadKey();
                    break;
                case 3:
                    //Console.Clear();
                    PendriveRead.PendriveDisplay(pendrivevariant);
                    Console.ReadKey();
                    //Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice - Please enter 1/2/3");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }
        public static void Cart()                         //fn to add variant selected by the user into cart
        {
            Console.WriteLine("Brand:  ");
            foreach (var i in brandcart)
            {
                Console.WriteLine(i + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("Model:  ");
            foreach (var i in modelcart)
            {
                Console.WriteLine(i + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("Price:  ");
            foreach (var i in pricecart)
            {
                Console.WriteLine("Rs." + i + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("Quantity:  ");
            foreach (var i in quantity)
            {
                Console.WriteLine(i + "   ");
            }
            Console.WriteLine();
            Console.WriteLine("Total Price:  ");
            foreach (var i in tprice)
            {
                Console.WriteLine("Rs." + i + "   ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
