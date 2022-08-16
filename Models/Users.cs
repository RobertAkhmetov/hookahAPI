using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore; // Entity Framework Core
using WebApiForHookahv1._0.Models;

namespace WebApiForHookahv1._0.Models
{
    public class UserContext : DbContext
    {
        public DbSet<WebApiForHookahv1._0.Models.User> users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }

    public class User
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
    }

}
