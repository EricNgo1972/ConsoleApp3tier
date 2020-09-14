using SPC.UI;
using System;
using System.Security.Claims;

namespace SPC.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceConfig.Init();

            Console.WriteLine("Console 3 tier test.");
            Console.WriteLine("");

            try
            {
                var login = new ClaimsPrincipal(new ClaimsIdentity("User"));

                Csla.ApplicationContext.User = login;

                Console.WriteLine("----------Async------------");
                var plist = SPC.PersonInfoList.GetInfoListAsync(null).Result;


                foreach (var item in plist)
                {
                    Console.WriteLine($"  - {item.EmplCode}. {item.Name}. ");
                }

                Console.WriteLine("----------Sync------------");

                var plist2 = SPC.PersonInfoList.GetInfoList(null);
                foreach (var item in plist2)
                {
                    Console.WriteLine($"  - {item.EmplCode}. {item.Name}. ");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();


        }
    }
}
