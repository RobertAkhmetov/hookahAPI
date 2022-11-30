using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2;

using WebApplication2.Models;
using System.Text.RegularExpressions;




namespace WebApplication2.Controllers
{

    //НЕТ в документации: в HTML вывести таблицу с кальянными
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
            return View(db.hookas.ToList());
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


        // POST: Hookah  Добавление кальянной
        [HttpPost]
        public async Task<string>Post([FromBody] Hooka recievedHooka)
        {
            await hookIdContext.AddAsync(recievedHooka);
            await hookIdContext.SaveChangesAsync();
            return ($"hookaId:{recievedHooka.id}");
        }

        //// POST: Hookah  Добавление кальянной
        //[HttpPost]
        //public async Task Post([FromBody] Dictionary<string, object> HookaAddRxData)/*string workWeek, string title, int price /*Dictionary<string, int> prices,  int coordsLat, int coordsLon,
        //     string workTimeStart, string workTimeEnd, string adress,  double rating, int complimentsHookah, int complimentsAtmosphere, int complimentsKitchen,
        //     string menuUrl1, string menuUrl2, Dictionary<string, string> newNavi, int reviewsRating,
        //     string reviewsCount)*/
        //{


        //    //AddNowHooka.Social["vk"] = ((Dictionary<string, object>)HookaAddRxData["social"])["vk"];

        //    Hooka newHooka = new Hooka
        //    {

        //        title = HookaAddRxData["title"].ToString(),
        //        description = HookaAddRxData["description"].ToString(),
        //        price = Convert.ToInt32(HookaAddRxData["price"]),
        //        lat = Convert.ToDouble(HookaAddRxData["lat"]),
        //        lon = Convert.ToDouble(HookaAddRxData["lon"]),
        //        adress = HookaAddRxData["address"].ToString(),
        //        workWeek = HookaAddRxData["workWeek"].ToString(),
        //        workTimeStart = HookaAddRxData["workTimeStart"].ToString(),
        //        workTimeEnd = HookaAddRxData["workTimeEnd"].ToString(),
        //        /*compliments = JsonConvert.SerializeObject(new Dictionary<string, int> { { "1", JsonConvert.DeserializeObject<Dictionary<string,int>>((JsonConvert.SerializeObject(HookaAddRxData["compliments"])))["1"] },
        //                                                        {"2",JsonConvert.DeserializeObject<Dictionary<string,int>>((JsonConvert.SerializeObject(HookaAddRxData["compliments"])))["2"]  },
        //                                                        {"3",JsonConvert.DeserializeObject<Dictionary<string,int>>((JsonConvert.SerializeObject(HookaAddRxData["compliments"])))["3"]  },
        //                                                        {"4", JsonConvert.DeserializeObject<Dictionary<string,int>>((JsonConvert.SerializeObject(HookaAddRxData["compliments"])))["4"] }
        //                                                       }),*/
        //        /*compliments = JsonConvert.SerializeObject(new Dictionary<string, int> {{ "1", JsonConvert.DeserializeObject<Dictionary<string, int>>(HookaAddRxData["compliments"].ToString())["1"] },
        //            { "2", JsonConvert.DeserializeObject<Dictionary<string, int>>(HookaAddRxData["compliments"].ToString())["2"] },
        //            { "3", JsonConvert.DeserializeObject<Dictionary<string, int>>(HookaAddRxData["compliments"].ToString())["3"] },
        //            { "4", JsonConvert.DeserializeObject<Dictionary<string, int>>(HookaAddRxData["compliments"].ToString())["4"] } }),*/
        //        compliments = Regex.Replace(HookaAddRxData["compliments"].ToString(), @"[\|\n]", String.Empty),

        //        rating = Convert.ToInt32(HookaAddRxData["rating"]),
        //        ratingCount = Convert.ToInt32(HookaAddRxData["ratingCount"]),
        //        city = HookaAddRxData["city"].ToString(),
        //        isWork = bool.Parse(HookaAddRxData["isWork"].ToString()),
        //        active = bool.Parse(HookaAddRxData["active"].ToString()),
        //        phone = HookaAddRxData["phone"].ToString(),
        //        dateCreate = HookaAddRxData["dateCreate"].ToString(),
        //        dateUpdate = HookaAddRxData["dateUpdate"].ToString(),
        //        owner = Convert.ToInt32(HookaAddRxData["owner"]),
        //        banner = HookaAddRxData["banner"].ToString(),

        //        menu = new List<string>() { JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(HookaAddRxData["menu"]))[0],
        //            JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(HookaAddRxData["menu"]))[1] },

        //        social = Regex.Replace(HookaAddRxData["social"].ToString(),"[\n]",String.Empty)

        //    };

        //    //newHooka.social.Add("vk", JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(HookaAddRxData["social"]))["vk"]);

        //    await hookIdContext.hookas.AddRangeAsync(newHooka);
        //    await hookIdContext.SaveChangesAsync();

        //}

        //обновление кальянной
        /*
        [HttpPut]
        public async Task Put([FromBody] Hooka putHooka)
        {
            Hooka hooka = hookIdContext.hookas.Where(h => h.id == putHooka.id).FirstOrDefault();
            hooka = putHooka;

            await hookIdContext.SaveChangesAsync();
        }
        */
            
            
            [HttpPut]
        public async Task Put([FromBody] Dictionary<string, object> HookaAddRxData)
        {
            Hooka hooka = hookIdContext.hookas.Where(h => h.id == Convert.ToInt32(HookaAddRxData["id"])).FirstOrDefault();

            hooka.title = HookaAddRxData["title"].ToString();
            hooka.description = HookaAddRxData["description"].ToString();
            hooka.price = Convert.ToInt32(HookaAddRxData["price"]);
            hooka.lat = Convert.ToDouble(HookaAddRxData["lat"]);
            hooka.lon = Convert.ToDouble(HookaAddRxData["lon"]);
            hooka.adress = HookaAddRxData["address"].ToString();
            hooka.workWeek = HookaAddRxData["workWeek"].ToString();
            hooka.workTimeStart = HookaAddRxData["workTimeStart"].ToString();
            hooka.workTimeEnd = HookaAddRxData["workTimeEnd"].ToString();
            //hooka.compliments = Regex.Replace(HookaAddRxData["compliments"].ToString(), "[\n]", String.Empty);
            hooka.rating = Convert.ToInt32(HookaAddRxData["rating"]);
            hooka.ratingCount = Convert.ToInt32(HookaAddRxData["ratingCount"]);
            hooka.city = HookaAddRxData["city"].ToString();
            hooka.isWork = bool.Parse(HookaAddRxData["isWork"].ToString());
            hooka.active = bool.Parse(HookaAddRxData["active"].ToString());
            hooka.phone = HookaAddRxData["phone"].ToString();
            hooka.dateCreate = HookaAddRxData["dateCreate"].ToString();
            hooka.dateUpdate = HookaAddRxData["dateUpdate"].ToString();
            hooka.owner = Convert.ToInt32(HookaAddRxData["owner"]);
            hooka.banner = HookaAddRxData["banner"].ToString();
            hooka.menu[0] = JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(HookaAddRxData["menu"]))[0];
            hooka.menu[1] = JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(HookaAddRxData["menu"]))[1];
            //hooka.social = Regex.Replace(HookaAddRxData["social"].ToString(), "[\n]", String.Empty);

            await hookIdContext.SaveChangesAsync();
        }

            //Удаление кальянной
            // DELETE: hookah/5
            [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            Hooka hooka = hookIdContext.hookas.Where(h => h.id == id).FirstOrDefault();
            hookIdContext.Remove(hooka);
            await hookIdContext.SaveChangesAsync();
        }


        // получить полную информацию о кальянной
        // GET: Hookah/1
        [HttpGet("{id}", Name = "Get")]
        public async Task<string> Get(int id)
        {
            Hooka hid = hookIdContext.hookas.Find(id);
            var jsonhid = JsonConvert.SerializeObject(hid);
            return $"{jsonhid}";
        }

    }


    //список кальянных для карты
    [Route("hookah/list/map")]
    [ApiController]
    public class HookController : Controller
    {
        HookaContext db;

        public HookController(HookaContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<string> HookahMap(float lat, float lon)
        {
            var hm = db.hookas.Where(h => (h.lat - lat < 1 && h.lon - lon < 1) || (lat - h.lat < 1 && lon - h.lon < 1));

            List<HookaForMap> resultList = new List<HookaForMap>();
            foreach(Hooka fullFieldHooka in hm)
            {
                resultList.Add(new HookaForMap
                {
                    id = fullFieldHooka.id,
                    lat = fullFieldHooka.lat,
                    lon = fullFieldHooka.lon,
                    rating = fullFieldHooka.rating,
                    title = fullFieldHooka.title
                }
                ); 
            }

            var jsonResult = JsonConvert.SerializeObject(resultList);
            return $"{jsonResult}";
        }

    }


    //список популярных кальянных
    [Route("hookah/list/popular")]
    [ApiController]
    public class HookRaiting : Controller
    {
        HookaContext db;

        public HookRaiting(HookaContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<string> HookahRaitingShow()
        {
            //var hr = db.hookas.Where(p => p.Rating > 4);
            var hr = db.hookas.OrderByDescending(r => r.rating).Take(15); //отбираем 15 по рейтингу

            List<HookaForPopular> resultList = new List<HookaForPopular>();
            foreach (Hooka fullFieldHooka in hr)
            {
                resultList.Add(new HookaForPopular
                {
                    id = fullFieldHooka.id,
                    lat = fullFieldHooka.lat,
                    lon = fullFieldHooka.lon,
                    banner = fullFieldHooka.banner,
                    rating = fullFieldHooka.rating,
                    title = fullFieldHooka.title
                }
                );
            }

            var jsonhcoord = JsonConvert.SerializeObject(resultList);
            return $"{jsonhcoord}";
        }

        /*public string Index()
        {

            var hid = db.hookas.Where(p => p.ReviewsRating > 4);

            var jsonhid = JsonConvert.SerializeObject(hid);

            return $"{jsonhid}";

            //return View(jsonhid);
        }*/

    }

    //список кальянных рядом - максимум 3км до кальянной
    [Route("hookah/list/nearby")]
    [ApiController]
    public class HookaController : Controller
    {
        double maxDistance = 0.03;

        HookaContext db;

        public HookaController(HookaContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<string> HookahNearby(float lat, float lon)
        {
            var hm = db.hookas.Where(h => (h.lat - lat < maxDistance && h.lon - lon < maxDistance) || (lat - h.lat < maxDistance && lon - h.lon < maxDistance));

            //добавить обработку "если нет поблизости кальянных"


            List<HookaForNearby> resultList = new List<HookaForNearby>();
            foreach (Hooka fullFieldHooka in hm)
            {
                resultList.Add(new HookaForNearby
                {
                    id = fullFieldHooka.id,
                    lat = fullFieldHooka.lat,
                    lon = fullFieldHooka.lon,
                    banner = fullFieldHooka.banner,
                    rating = fullFieldHooka.rating,
                    title = fullFieldHooka.title,
                    adress = fullFieldHooka.adress,
                    price = fullFieldHooka.price
                }
                );
            }

            var jsonhcoord = JsonConvert.SerializeObject(resultList);
            return $"{jsonhcoord}";
        }

    }



    //получить упрощенную инфу по всем кальянным
    [Route("hookah/brieftable")]
    [ApiController]
    public class HookBrief : Controller
    {
        HookaContext db;

        public HookBrief(HookaContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<string> HookahBriefTableShow()
        {
            var hr = db.hookas;

            List<HookaForBriefTable> resultList = new List<HookaForBriefTable>();
            foreach (Hooka fullFieldHooka in hr)
            {
                resultList.Add(new HookaForBriefTable
                {
                    id = fullFieldHooka.id,
                    banner = fullFieldHooka.banner,
                    title = fullFieldHooka.title,
                    adress = fullFieldHooka.adress
                }
                );
            }

            var jsonhcoord = JsonConvert.SerializeObject(resultList);
            return $"{jsonhcoord}";
        }
    }
}
