using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiForHookahv1._0;

using WebApiForHookahv1._0.Models;



namespace WebApiForHookahv1._0.Controllers
{
    //в HTML вывести таблицу с кальянными
    [Route("hookah/table")]
    [ApiController]
    public class HomeController : Controller
    {
        HookaContext db;

        public HomeController(HookaContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Hookas.ToList());
        }

    }

    [Route("hookah/light")]
    [ApiController]
    public class HookaController : Controller
    {
        HookaContext db;

        public HookaController(HookaContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Hookas.ToArray());
        }

    }



    [Route("[controller]")]
    [ApiController]
    public class HookahController : ControllerBase
    {
        HookaContext hookIdContext;//создаем экземпляр бд, с которым будем работать в этом контроллере

        public HookahController(HookaContext context)
        {
            hookIdContext = context;
        }
        

        // GET: Hookah
        [HttpGet]
        public IEnumerable<string> Get()
        {

            //Shisha shisha1 = new Shisha("Panda", "ул. Советская, д.10");
            return new string[] { "Complete create", "hookah" };
        }


        // GET: Hookah/1
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            
            Hooka hid = hookIdContext.Hookas.Find(id);

            var jsonhid = JsonConvert.SerializeObject(hid);

            return $"{jsonhid}";
        }



        // POST: Hookah  Добавляем кальянную в базу
        [HttpPost]
        public void Post(string title, int priceHookah, string iamge)//[FromBody] string value)
        {


            hookIdContext.Hookas.AddRange(
                 new Hooka
                 {

                     Title = title,
                     PriceHookah = priceHookah,
                     Iamge = iamge,
                     CoordsLat = 20,
                     CoordsLon = 40,
                     WorkTimeStart = 123,
                     WorkTimeEnd = 111,
                     FullAdress = "ул.Седова, д.24, корп.3",
                     Vk = "vk.com",
                     Instagram = "vk.com",
                     Ok = "vk.com",
                     ComplimentsHookah = 233,
                     ComplimentsAtmosphere = 123,
                     ComplimentsKitchen = 222,
                     MenuUrl1 = "vk.com",
                     MenuUrl2 = "vk.com",

                     newNavi = new Dictionary<string, string>
                    {
                        {"coord1","value1" },
                        {"coord2","value2" }
                    },

                     ReviewsRating = 233,
                     ReviewsCount = "vk.com"
                     
                 });
           hookIdContext.SaveChanges();
           
        }

        // PUT: Hookah/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

