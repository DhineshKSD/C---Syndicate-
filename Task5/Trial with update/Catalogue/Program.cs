using System;
using System.Xml;

namespace Catalogue
{
    public class Program
    {
        public static int purchaseprice = 0;
        public static void Main()
        {
            Laptop[] laptops = new Laptop[5];                 // Array of laptop objects

            laptops[0] = new Laptop(11, "Dell", "Inspiron3481", 27990,50);
            laptops[1] = new Laptop(22, "Asus", "ROG Strix G", 74990,50);
            laptops[2] = new Laptop(33, "Acer", "Nitro 5", 57990,50);
            laptops[3] = new Laptop(44, "Lenovo", "Ideapad", 27990,50);
            laptops[4] = new Laptop(55, "Apple", "MacBook Air", 67990,50);

            using (XmlWriter writer = XmlWriter.Create("Laptop.xml"))      // To create XML data file of Laptop objects
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Laptops");

                foreach (Laptop lap in laptops)
                {
                    writer.WriteStartElement("Laptop");

                    writer.WriteElementString("ID", lap.Id.ToString());
                    writer.WriteElementString("brand", lap.Brand);
                    writer.WriteElementString("model", lap.Model);
                    writer.WriteElementString("price", lap.Price.ToString());
                    writer.WriteElementString("stock", lap.Stock.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Pendrive[] pendrive = new Pendrive[5];                              // Array of Pendrive objects
            pendrive[0] = new Pendrive(111, "Sandisk", "Ultra Dual -64 GB", 899);
            pendrive[1] = new Pendrive(122, "HP", "V215 B -32 GB", 360);
            pendrive[2] = new Pendrive(133, "Toshiba", "TransMemory -32 GB", 415);
            pendrive[3] = new Pendrive(144, "Kingston", "DTIG4 USB 3.0 -16 GB", 475);
            pendrive[4] = new Pendrive(155, "Sony", "Ultra 3.1 -32 GB", 785);

            using (XmlWriter writer1 = XmlWriter.Create("Pendrive.xml"))       // To create XML data file of Pendrive objects
            {
                writer1.WriteStartDocument();
                writer1.WriteStartElement("Pendrives");

                foreach (Pendrive pd in pendrive)
                {
                    writer1.WriteStartElement("Pendrive");

                    writer1.WriteElementString("ID", pd.Id.ToString());
                    writer1.WriteElementString("brand", pd.Brand);
                    writer1.WriteElementString("model", pd.Model);
                    writer1.WriteElementString("price", pd.Price.ToString());

                    writer1.WriteEndElement();
                }

                writer1.WriteEndElement();
                writer1.WriteEndDocument();
            }

            Mouse[] mousevariant = new Mouse[5];                                  // Array of Mouse objects
            mousevariant[0] = new Mouse(211, "Lenovo", "M110 Optical Wired", 269);
            mousevariant[1] = new Mouse(222, "HP", "HP S500", 660);
            mousevariant[2] = new Mouse(233, "Logitech", "M-171", 649);
            mousevariant[3] = new Mouse(244, "Dell", "WM 126", 719);
            mousevariant[4] = new Mouse(255, "Zebronics", "Optical Wired", 285);

            using (XmlWriter writer2 = XmlWriter.Create("Mouse.xml"))            // To create XML data file of Mouse objects
            {
                writer2.WriteStartDocument();
                writer2.WriteStartElement("Mouses");

                foreach (Mouse mv in mousevariant)
                {
                    writer2.WriteStartElement("Mouse");

                    writer2.WriteElementString("ID", mv.Id.ToString());
                    writer2.WriteElementString("brand", mv.Brand);
                    writer2.WriteElementString("model", mv.Model);
                    writer2.WriteElementString("price", mv.Price.ToString());

                    writer2.WriteEndElement();
                }

                writer2.WriteEndElement();
                writer2.WriteEndDocument();
            }
            LaptopRead client1 = new LaptopRead();
            MouseRead client2 = new MouseRead();
            client1.LapDisplay();
            //client2.MouseDisplay();
        }
        public void purchase1()                            //Function to display shops for selection
        {
            LaptopRead readx = new LaptopRead();
            MouseRead ready = new MouseRead();
            PendriveRead readz = new PendriveRead();

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
                    readx.LapDisplay();
                    Console.ReadKey();
                    break;
                case 2:
                    //Console.Clear();
                    ready.MouseDisplay();
                    Console.ReadKey();
                    break;
                case 3:
                    //Console.Clear();
                    readz.PendriveDisplay();
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
            LaptopRead.LapCart();
            MouseRead.MouseCart();
            PendriveRead.PendriveCart();
            Program.purchase();
        } 
    }
}




