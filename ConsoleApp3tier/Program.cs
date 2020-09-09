using SPC.UI;
using System;

namespace ConsoleApp3tier
{
    class Program
    {
        static void Main(string[] args)
        {

            Startup.Init();

            Console.WriteLine("Console 3 tier test.");
            Console.WriteLine("----------------------");

            try
            {
                var list = SPC.ContactInfoList.GetInfoList(null);

                foreach (var item in list)
                {
                    Console.WriteLine($"  - {item.ContactCode}. {item.Name}. {item.ContactType}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }


        }
    }
}
