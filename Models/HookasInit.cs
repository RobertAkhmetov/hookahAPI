using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiForHookahv1._0.Models
{
    public class HookasInit
    {
        public static void Initialize(HookaContext context)
        {
            if (!context.Hookas.Any()) //если это поле не использовать,
            //в конец БД в любом случае добавятся кальянные ниже
             {
            // добавляем кальянную в бд
            context.Hookas.AddRange(
                 new Hooka
                 {
                     Title = "Panda",
                     PriceHookah = 2700,
                     Iamge = "ffff",
                     CoordsLat = 20,
                     CoordsLon = 40,
                 },

                 new Hooka
                  {
                      Title = "Дымный дым",
                      PriceHookah = 1500,
                  }
                );

                // сохраняем в базу данных
                context.SaveChanges();
            }
        }
    }
}