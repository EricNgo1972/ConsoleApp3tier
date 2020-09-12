using SPC.UI;
using System;

namespace SPC.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceConfig.Init();

            Console.WriteLine("Console 3 tier test.");
            Console.WriteLine("----------------------");

            try
            {
                var login = new Csla.Security.CslaClaimsPrincipal(  Csla.Security.UnauthenticatedIdentity.UnauthenticatedIdentity()) ;

                Csla.ApplicationContext.User = login;


                var list =  SPC.ContactInfoList.GetInfoListAsync(null).Result;
                //var list = SPC.ContactInfoList.GetInfoList(null);

                foreach (var item in list)
                {
                    Console.WriteLine($"  - {item.ContactCode}. {item.Name}. {item.ContactType}");
                }

                Console.WriteLine("-----------------End of Contacts-------------------");

                var plist = SPC.PersonInfoList.GetInfoListAsync(null).Result;
                

                foreach (var item in plist)
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
