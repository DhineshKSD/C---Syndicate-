using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace Catalogue
{
   public class Laptop
    {
        int _id;
        string _brand;
        string _model;
        int _price;
        int _stock;

        public Laptop(int id, string brand, string model, int price, int stock)                //Constructor fn
        {
            this._id = id;
            this._brand = brand;
            this._model = model;
            this._price = price;
            this._stock = stock;
        }

        public int Id { get { return _id; } }
        public string Brand { get { return _brand; } }
        public string Model { get { return _model; } }
        public int Price { get { return _price; } }
        public int Stock { get { return _stock; } }
    }
     public class LaptopRead
     {
        public static ArrayList brandcart = new ArrayList();
        public static ArrayList pricecart = new ArrayList();
        public static ArrayList modelcart = new ArrayList();
        public static ArrayList quantity = new ArrayList();
        public static ArrayList tprice = new ArrayList();
       
        public void LapDisplay()                                                 //fn to display laptop variants
        {
            
            XElement xelement =  XElement.Load("Laptop.xml");                   //XElement class to load xml data file
            IEnumerable<XElement> Laptops = xelement.Elements();                //IEnumerable Interface to read the loaded file 
            Console.WriteLine("Shop-1: Laptop Store");
            Console.WriteLine();
            Console.WriteLine("-----------------------Available Laptop Variants----------------------");
            foreach (var lap in Laptops)
            {
                String id = lap.Element("ID").Value;
                String brandname = lap.Element("brand").Value;
                String price_detail = lap.Element("price").Value;
                String model_detail = lap.Element("model").Value;
                //String stock = lap.Element("stock").Value;

                Console.WriteLine("Id: {0}",id);
                Console.WriteLine("Brand: {0}",brandname);
                Console.WriteLine("Model: {0}",model_detail);
                Console.WriteLine("Price: Rs. {0}",price_detail);
                //Console.WriteLine("Stock: {0}", stock);
                Console.WriteLine("-----------------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.Write("Please Enter the Item Id you wish to buy -");
            
            LapSelection();
        }
        public void LapSelection()                                            //fn to display laptop variant selected by the user
        {
            
            int price = 0;
            int qty = 0;
            int localprice = 0;
            String user_id = Console.ReadLine();
            //Console.Clear();
            XElement xelement = XElement.Load("Laptop.xml"); 
            IEnumerable<XElement> Laptops = xelement.Elements();
            var x = from Laptop in xelement.Elements("Laptop")               //LINQ query to find an element with a specific attribute
                    where (string)Laptop.Element("ID") == user_id
                    select Laptop;
            Console.WriteLine();
            Console.WriteLine("---------------------------Your Selection-----------------------------");
            Console.WriteLine();
            foreach (XElement lap in x)
            {
                String id = lap.Element("ID").Value;
                String brandname = lap.Element("brand").Value;
                String price_detail = lap.Element("price").Value;
                String model_detail = lap.Element("model").Value;

                price = Convert.ToInt32(price_detail);

                brandcart.Add(brandname);
                pricecart.Add(price_detail);
                modelcart.Add(model_detail);

                Console.WriteLine("Id: {0}", id);
                Console.WriteLine("Brand: {0}", brandname);
                Console.WriteLine("Model: {0}", model_detail);
                Console.WriteLine("Price: Rs. {0}", price_detail);
                Console.WriteLine("----------------------------------------------------------------------");
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
                    quantity.Add(qty);
                    tprice.Add(localprice);
                    Program.purchaseprice += localprice;
                    Console.WriteLine("Do you want to purchase another item...(Y/N)");
                    string choice = Console.ReadLine();
                    if(choice== "y"||choice== "Y")
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
            public static void LapCart()                              //fn to add laptop variant selected by the user into cart
        {
            //Console.WriteLine();
            //Console.WriteLine("---------------------------Shop-1----------------------------");
            //Console.WriteLine();
            foreach (var i in brandcart)
                {
                    Console.WriteLine("Brand: {0}", i);
                }
                foreach (var i in modelcart)
                {
                    Console.WriteLine("Model: {0}", i);
                }
                foreach (var i in pricecart)
                {
                    Console.WriteLine("Price: Rs.{0}", i);
                }
                foreach (var i in quantity)
                {
                    Console.WriteLine("Quantity: {0}", i);
                }
                foreach (var i in tprice)
                {
                    Console.WriteLine("Total_Price: Rs.{0}", i);
                }
            Console.WriteLine();
            Console.ReadLine();
        }
     }
  }
     


