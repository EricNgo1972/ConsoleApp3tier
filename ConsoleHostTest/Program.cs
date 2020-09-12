using System;

namespace ConsoleHostTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var service = new WindowsSrvHost.DataPortalHost();

                service.Start();

                Console.WriteLine($"Service Started. Listen from {service.GetUrl()}");

                Console.WriteLine("Enter 'STOP' to stop the service");

                while (Console.ReadLine() == "STOP")
                {
                    service.Stop();
                    Console.WriteLine("Service Stopped.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.ReadKey();


        }
    }
}
