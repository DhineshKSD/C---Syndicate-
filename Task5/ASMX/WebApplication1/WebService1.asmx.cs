using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Laptop
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }

    public class Pendrive
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }

    public class Mouse
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }

    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLaptopJSON()
        {
            Laptop[] laps = new Laptop[] {
            new Laptop()
            {
                Id="11",
                Brand="Dell",
                Model="Inspiron3481",
                Price=27990
            },
            new Laptop()
            {
                Id="22",
                Brand="Asus",
                Model= "ROG Strix G",
                Price= 74990
            },
            new Laptop()
            {
                Id="33",
                Brand="Acer",
                Model= "Nitro 5",
                Price= 57990
            },
            new Laptop()
            {
                Id="44",
                Brand="Lenovo",
                Model= "Ideapad",
                Price= 27990
            }
        };
        return  new JavaScriptSerializer().Serialize(laps); 
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetpendriveJSON()
        {
            Pendrive[] pendrive = new Pendrive[] {
            new Pendrive()
            {
                Id="111",
                Brand="Sandisk",
                Model="Ultra Dual -64 GB",
                Price= 899
            },
            new Pendrive()
            {
                Id="122",
                Brand="HP",
                Model= "V215 B -32 GB",
                Price= 360
            },
            new Pendrive()
            {
                Id="133",
                Brand="Toshiba",
                Model= "TransMemory -32 GB",
                Price= 415
            },
            new Pendrive()
            {
                Id="144",
                Brand="Sony",
                Model= "Ultra 3.1 -32 GB",
                Price= 785
            }
        };
            return new JavaScriptSerializer().Serialize(pendrive);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetmouseJSON()
        {
            Mouse[] mouse = new Mouse[] {
            new Mouse()
            {
                Id="211",
                Brand="Lenovo",
                Model="M110 Optical Wired",
                Price= 299
            },
            new Mouse()
            {
                Id="222",
                Brand="HP",
                Model= "HP S500",
                Price= 360
            },
            new Mouse()
            {
                Id="233",
                Brand="Zebronics",
                Model= "Optical Wired",
                Price= 285
            },
            new Mouse()
            {
                Id="244",
                Brand="Dell",
                Model= "WM 126",
                Price= 719
            }
        };
            return new JavaScriptSerializer().Serialize(mouse);
        }
    }
}
