using System;


namespace WebApiForHookahv1._0
{
        //Тут пока без использования БД будет фейковая информация по кальянным
        public class Shisha
        {
            public string Name { get; set; }
            public string Address { get; set; }

            public Shisha(string name, string address)
            {
                Name = name;
                Address = address;
            }

    }

 
    
}
