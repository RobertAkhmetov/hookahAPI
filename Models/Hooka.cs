using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore; // Entity Framework Core
using WebApiForHookahv1._0.Models;

namespace WebApiForHookahv1._0.Models
{
    public class HookaContext:DbContext
    {
        public DbSet<Hooka> Hookas { get; set; }

        public HookaContext(DbContextOptions<HookaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WebApiForHookahv1._0.Models.User> User { get; set; }
    }

    public class Hooka
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PriceHookah { get; set; }
        public string Iamge { get; set; }
        public int CoordsLat { get; set; }
        public int CoordsLon { get; set; }

        public int WorkTimeStart { get; set; }
        public int WorkTimeEnd { get; set; }
        public string FullAdress { get; set; }
        public string Vk { get; set; }
        public string Instagram { get; set; }
        public string Ok { get; set; }
        public int ComplimentsHookah { get; set; }
        public int ComplimentsAtmosphere { get; set; }
        public int ComplimentsKitchen { get; set; }
        public string MenuUrl1 { get; set; }
        public string MenuUrl2 { get; set; }

        public Dictionary<string, string> newNavi = new Dictionary<string, string>
        {
            {"coord1","value1" },
            {"coord2","value2" }
        };

        public int ReviewsRating { get; set; }
        public string ReviewsCount { get; set; }
        
      
    }

}
