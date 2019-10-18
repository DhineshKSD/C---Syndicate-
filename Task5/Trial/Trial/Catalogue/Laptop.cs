using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using System.Xml;


namespace Catalogue
{
    class Laptop
    {
        int _id;
        string _brand;
        string _model;
        int _price;

        public Laptop(int id, string brand, string model, int price)
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
     class Laptopread
     {
        public ArrayList brandcart = new ArrayList();
        public ArrayList pricecart = new ArrayList();
        public ArrayList modelcart = new ArrayList();
        public ArrayList quantity = new ArrayList();
        public ArrayList tprice = new ArrayList();

        public void lapdisplay()
        {
            XElement xelement =  XElement.Load("Laptop.xml");
            IEnumerable<XElement> Laptops = xelement.Elements();
                Console.WriteLine("-----------------------Available Laptop Variants----------------------");
            foreach (var lap in Laptops)
            {
                String id = lap.Element("ID").Value;
                String brandname = lap.Element("brand").Value;
                String price_detail = lap.Element("price").Value;
                String model_detail = lap.Element("model").Value;
                
                Console.WriteLine("Id: {0}",id);
                Console.WriteLine("Brand: {0}",brandname);
                Console.WriteLine("Model: {0}",model_detail);
                Console.WriteLine("Price: Rs. {0}",price_detail);
                Console.WriteLine("-----------------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("----Please Enter the Item Id you wish to buy---");
            lapdisplay1();
        }
        public void lapdisplay1()
        {
            int price = 0;
            int qty = 0;
            String user_id = Console.ReadLine();
            //Console.Clear();
            XElement xelement = XElement.Load("Laptop.xml");
            IEnumerable<XElement> Laptops = xelement.Elements();
            var x = from Laptop in xelement.Elements("Laptop")
                    where (string)Laptop.Element("ID") == user_id
                    select Laptop;
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
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter the Quantity Required:");
                qty = Convert.ToInt32(Console.ReadLine());
                quantity.Add(qty);
                Console.WriteLine("Total Price: Rs. {0}", qty * price);
                tprice.Add(qty * price);
                Console.WriteLine();
                Console.WriteLine("Do you want to Change quantity? (y/n)");
                user_choice = Console.ReadLine();
                Console.WriteLine();

                if (user_choice == "n")

                    Console.WriteLine("Press enter to checkout the item");
                    Console.WriteLine();

                while ((user_choice != "y") && (user_choice != "n"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Option. Please Choose 'y' or 'n'");
                    user_choice = Console.ReadLine();
                }
            } while (user_choice == "y");
        }
            public void lapcart()
            {
            Console.WriteLine();
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
                    Console.WriteLine("Quantity: Rs.{0}", i);
                }
                foreach (var i in tprice)
                {
                    Console.WriteLine("Total_Price: Rs.{0}", i);
                }
            Console.WriteLine();
        }
        

    /*class Lapadd
        {
        public void add()
            {
                 XDocument xmlDocument = XDocument.Load("C:\\Users\\Dell\\Downloads\\Task\\Task5\\Catalogue\\bin\\Debug\\Laptop.xml");

                 xmlDocument.Element("Laptops").Add(
                 new XElement("Laptop", new XAttribute("id", 105),
                 new XElement("brand", "Todd"),
                 new XElement("model", "Male"),
                 new XElement("price", 980)
                    ));
                 xmlDocument.Save("C:\\Users\\Dell\\Downloads\\Task\\Task5\\Catalogue\\bin\\Debug\\Laptop.xml");
                 Console.WriteLine("Laptop Added and Saved");
            }
        }*/
    }
  }
     


