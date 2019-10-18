using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace Catalogue
{
    public class Pendrive
    {
        int _id;
        string _brand;
        string _model;
        int _price;

        public Pendrive(int id, string brand, string model, int price)
        {
            this._id = id;
            this._brand = brand;
            this._model = model;
            this._price = price;
        }

        public int Id { get { return _id; } }
        public string Brand { get { return _brand; } }
        public string Model { get { return _model; } }
        public int Price { get { return _price; } }
    }
    class PendriveRead
    {
        public static ArrayList brandcart = new ArrayList();
        public static ArrayList pricecart = new ArrayList();
        public static ArrayList modelcart = new ArrayList();
        public static ArrayList quantity = new ArrayList();
        public static ArrayList tprice = new ArrayList();

        public void PendriveDisplay()
        {
            Console.WriteLine("Shop-3: Pendrive Store");
            Console.WriteLine();
            XElement xelement = XElement.Load("Pendrive.xml");
            IEnumerable<XElement> Pendrive = xelement.Elements();
            Console.WriteLine("--------------------Available Pendrive Variants-----------------------");
            foreach (var pendrive in Pendrive)
            {
                String id = pendrive.Element("ID").Value;
                String brandname = pendrive.Element("brand").Value;
                String price_detail = pendrive.Element("price").Value;
                String model_detail = pendrive.Element("model").Value;

                Console.WriteLine("Id: {0}", id);
                Console.WriteLine("Brand: {0}", brandname);
                Console.WriteLine("Model: {0}", model_detail);
                Console.WriteLine("Price: Rs. {0}", price_detail);
                Console.WriteLine("----------------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.Write("Please Enter the Item Id you wish to buy -");
            
            PendriveSelection();
        }

        public void PendriveSelection()
        {
            int price = 0;
            int qty = 0;
            int localprice = 0;
            String user_id = Console.ReadLine();
            //Console.Clear();
            XElement xelement = XElement.Load("Pendrive.xml");
            IEnumerable<XElement> Pendrives = xelement.Elements();
            var x = from Pendrive in xelement.Elements("Pendrive")
                    where (string)Pendrive.Element("ID") == user_id
                    select Pendrive;
            Console.WriteLine();
            Console.WriteLine("---------------------------Your Selection-----------------------------");
            Console.WriteLine();
            foreach (XElement pendrive in x)
            {
                String id = pendrive.Element("ID").Value;
                String brandname = pendrive.Element("brand").Value;
                String price_detail = pendrive.Element("price").Value;
                String model_detail = pendrive.Element("model").Value;

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
                Program pur2 = new Program();
                if (user_choice == "n")
                {
                    quantity.Add(qty);
                    tprice.Add(localprice);
                    Program.purchaseprice += localprice;
                    Console.WriteLine("Do you want to purchase another item...(Y/N)");
                    string choice = Console.ReadLine();
                    if (choice == "y" || choice == "Y")
                    {
                        pur2.purchase1();
                    }
                    if (choice == "N" || choice == "n")
                    {
                        pur2.display();
                    }
                    if (choice != "y" || choice != "Y" && choice != "N" || choice != "n")
                    {
                        Console.WriteLine("Invalid entry...");
                        Console.ReadKey();
                    }
                }
            } while (user_choice == "y");
        }
        public static void PendriveCart()
        {
            //Console.WriteLine();
            //Console.WriteLine("---------------------------Shop-3----------------------------");
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
        }
    }
}

