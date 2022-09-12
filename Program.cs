using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication2;


using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            
            // добавление данных
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { user_email = "Tom", user_name = "name1", user_password_hash="sdfsf" };
                User user2 = new User { user_email = "Alice", user_name = "name2", user_password_hash = "sdfsf" };

                // добавляем их в бд
                db.users.AddRange(user1, user2);
                db.SaveChanges();
            }


            /*
            // получение данных
            using (UserContext db = new UserContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.users.ToList();
                Console.WriteLine("Users list:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.user_email} - {u.user_name}");
                    Console.ReadLine();
                }
            }
            */


            
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                
                try
                {
                    var context = services.GetRequiredService<HookaContext>();
                    //hookasInit.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error getrequiredservice program.cs");
                }
                
              }

              host.Run();
          }
            
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
              WebHost.CreateDefaultBuilder(args)
                  .UseStartup<Startup>();
      
        }
    }


