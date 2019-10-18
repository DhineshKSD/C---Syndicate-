using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace Catalogue
{
    public class Mouse
    {
        int _id;
        string _brand;
        string _model;
        int _price;

        public Mouse(int id, string brand, string model, int price)
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
    public class MouseRead
    {
        public static ArrayList brandcart = new ArrayList();
        public static ArrayList pricecart = new ArrayList();
        public static ArrayList modelcart = new ArrayList();
        public static ArrayList quantity = new ArrayList();
        public static ArrayList tprice = new ArrayList();

        public void MouseDisplay()                                    //fn to display mouse variants
        {
            Console.WriteLine("Shop-2: Mouse Store");
            Console.WriteLine();
            XElement xelement = XElement.Load("Mouse.xml");          //XElement class to load xml data file
            IEnumerable<XElement> Mouse = xelement.Elements();        //IEnumerable Interface to read the loaded file 
            Console.WriteLine("--------------------Available Mouse Variants------------------------");
            foreach (var mouse in Mouse)
            {
                String id = mouse.Element("ID").Value;
                String brandname = mouse.Element("brand").Value;
                String price_detail = mouse.Element("price").Value;
                String model_detail = mouse.Element("model").Value;

                Console.WriteLine("Id: {0}", id);
                Console.WriteLine("Brand: {0}", brandname);
                Console.WriteLine("Model: {0}", model_detail);
                Console.WriteLine("Price: Rs. {0}", price_detail);
                Console.WriteLine("--------------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.Write("Please Enter the Item Id you wish to buy -");

            MouseSelection();
        }
        public void MouseSelection()                                   //fn to display mouse variant selected by the user
        {
            int price = 0;
            int qty = 0;
            int localprice = 0;
            String user_id = Console.ReadLine();
            //Console.Clear();
            XElement xelement = XElement.Load("Mouse.xml");
            IEnumerable<XElement> Mouses = xelement.Elements();
            var x = from Mouse in xelement.Elements("Mouse")           //LINQ query to find an element with a specific attribute
                    where (string)Mouse.Element("ID") == user_id
                    select Mouse;
            Console.WriteLine();
            Console.WriteLine("---------------------------Your Selection-----------------------------");
            Console.WriteLine();
            foreach (XElement mouse in x)
            {
                String id = mouse.Element("ID").Value;
                String brandname = mouse.Element("brand").Value;
                String price_detail = mouse.Element("price").Value;
                String model_detail = mouse.Element("model").Value;

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
                Program pur1 = new Program();
                if (user_choice == "n")
                {
                    quantity.Add(qty);
                    tprice.Add(localprice);
                    Program.purchaseprice += localprice;
                    Console.WriteLine("Do you want to purchase another item...(Y/N)");
                    string choice = Console.ReadLine();
                    if (choice == "y" || choice == "Y")
                    {
                        pur1.purchase1();
                    }
                    if (choice == "N" || choice == "n")
                    {
                        pur1.display();
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
        public static void MouseCart()                               //fn to add mouse variant selected by the user into cart
        {
            //Console.WriteLine();
            //Console.WriteLine("---------------------------Shop-2----------------------------");
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
    class Mouseadd
    {
        public void updation()
        {
            Console.WriteLine("Enter the operation to be done..(1/2/3)");
            Console.WriteLine();
            Console.WriteLine("-----> 1.) ADD  2.) DELETE  3.) EDIT <------");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    add();
                    Console.ReadKey();
                    break;
                case 2:
                    delete();
                    Console.ReadKey();
                    break;
                case 3:
                    edit();
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid choice - Please enter 1/2/3");
                    Console.ReadKey();
                    break;
            }
        }
        public void add()
        {
            Console.WriteLine("Enter the details of Mouse to be added");
            Console.ReadKey();
            Console.Write("Enter the ID :");
            String x = Console.ReadLine();

            Console.Write("Enter the Brand :");
            String y = Console.ReadLine();

            Console.Write("Enter the Model :");
            String z = Console.ReadLine();

            Console.Write("Enter the Price :");
            String w = Console.ReadLine();

            XDocument xDocument = XDocument.Load("Mouse.xml");
            XElement root = xDocument.Element("Mouses");
            IEnumerable<XElement> rows = root.Descendants("Mouse");
            XElement firstRow = rows.First();
            firstRow.AddBeforeSelf(
            new XElement("Mouse",
            new XElement("ID", x),
            new XElement("brand", y),
            new XElement("model", z),
            new XElement("price", w)));
            xDocument.Save("Mouse.xml");

            Console.WriteLine("Mouse Added and Saved");

        }
        public void delete()
        {
            Console.Write("Enter the MOUSE_ID to be deleted :");
            String user_id = Console.ReadLine();

            XElement xelement = XElement.Load("Mouse.xml");
            IEnumerable<XElement> Mouses = xelement.Elements();
            var x = from Mouse in xelement.Elements("Mouse")
                    where (string)Mouse.Element("ID") == user_id
                    select Mouse;
            x.Remove();
            xelement.Save("Mouse.xml");
            Console.WriteLine("The MOUSE_ID " + user_id + "is deleted Successfully");

        }
        public void edit()
        {
            Console.Write("Enter the Id to be edited :");
            String user_id = Console.ReadLine();

            Console.Write("Enter the new updated price of the  " + user_id + "  :");
            String pricenew = Console.ReadLine();

            XElement xelement = XElement.Load("Mouse.xml");
            IEnumerable<XElement> Mouses = xelement.Elements();
            var x = from Mouse in xelement.Elements("Mouse")
                    where (string)Mouse.Element("ID") == user_id
                    select Mouse;

            foreach (XElement id in x)
            {
                String price_detail = id.Element("price").Value;

                id.SetElementValue("price", pricenew);
            }
            xelement.Save("Mouse.xml");
            Console.WriteLine("Editing done");
        }
    }
}
