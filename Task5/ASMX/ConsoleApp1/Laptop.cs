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
    public  class LaptopRead
    {
        public static void LapDisplay(dynamic select)                                                 //fn to display laptop variants
        {
            Console.WriteLine("Shop-1: Laptop Store");
            Console.WriteLine();
            Console.WriteLine("-----------------------Available Laptop Variants----------------------");
            foreach (var i in select)
            {
                String id = i.Id;
                String brandname = i.Brand;
                String price_detail = i.Price;
                String model_detail = i.Model;
                //String stock = lap.Element("stock").Value;

                Console.WriteLine("Id: {0}", id);
                Console.WriteLine("Brand: {0}", brandname);
                Console.WriteLine("Model: {0}", model_detail);
                Console.WriteLine("Price: Rs. {0}", price_detail);
                //Console.WriteLine("Stock: {0}", stock);
                Console.WriteLine("-----------------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.Write("Please Enter the Item Id you wish to buy -");

            LapSelection();
        }
        public static void LapSelection()                                            //fn to display laptop variant selected by the user
        {
            int price = 0;
            int qty = 0;
            int localprice = 0;
            var user_id = Console.ReadLine();
            //Console.Clear();
            localhost.WebService1 obj1 = new localhost.WebService1();
            var x = obj1.GetLaptopJSON(); ;

            dynamic variant1 = JsonConvert.DeserializeObject(x);
            Console.WriteLine();
            Console.WriteLine("---------------------------Your Selection-----------------------------");
            Console.WriteLine();
            foreach (var i in variant1)
            {
                if (user_id == i.Id.ToString())
                {
                    String id = i.Id;
                    String brandname = i.Brand;
                    String price_detail = i.Price;
                    String model_detail = i.Model;

                    price = Convert.ToInt32(price_detail);

                    Program.brandcart.Add(brandname);
                    Program.pricecart.Add(price_detail);
                    Program.modelcart.Add(model_detail);

                    Console.WriteLine("Id: {0}", id);
                    Console.WriteLine("Brand: {0}", brandname);
                    Console.WriteLine("Model: {0}", model_detail);
                    Console.WriteLine("Price: Rs. {0}", price_detail);
                    Console.WriteLine("----------------------------------------------------------------------");
                }
            }
            String user_choice;
            Program pur = new Program();

            do
            {
                Console.WriteLine();
                Console.Write("Enter the Quantity Required:");
                qty = Convert.ToInt32(Console.ReadLine());
                localprice = qty * price;
                Console.WriteLine("Total Price: Rs. {0}", localprice);

                Console.WriteLine();
                Console.WriteLine("Do you want to Change quantity? (y/n)");
                user_choice = Console.ReadLine();
                Console.WriteLine();

                if (user_choice == "n")
                {
                    Program.quantity.Add(qty);
                    Program.tprice.Add(localprice);
                    Program.purchaseprice += localprice;
                    Console.WriteLine("Do you want to purchase another item...(Y/N)");
                    string choice = Console.ReadLine();
                    if (choice == "y" || choice == "Y")
                    {
                        pur.purchase1();
                    }
                    if (choice == "N" || choice == "n")
                    {
                        pur.display();
                    }
                    if (choice != "y" || choice != "Y" && choice != "N" || choice != "n")
                    {
                        Console.WriteLine("Invalid entry...");
                        Console.ReadKey();
                    }
                }
                while ((user_choice != "y") && (user_choice != "n"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Option. Please Choose 'y' or 'n'");
                    user_choice = Console.ReadLine();
                }
            } while (user_choice == "y");
        }
    }
}