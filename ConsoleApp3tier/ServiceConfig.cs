using Csla.Configuration;
using System;

namespace SPC.UI
{
    static class ServiceConfig
    {
        //const string AppHostUrl = "http://localhost:5000/api/DataPortal";

        const string AppHostUrl = "http://localhost:8000/DataPortal";
        
        const string AppHostUrlSsl = "https://localhost:8001/DataPortal";

        public static void Init()
        {

            


            Console.WriteLine($"Set Dataportal Proxy : {AppHostUrl}");

            new Csla.Configuration.CslaConfiguration().DataPortal().DefaultProxy(typeof(Csla.DataPortalClient.HttpProxy), AppHostUrl);
                        

            //Csla.ApplicationContext.DataPortalProxy = typeof(Csla.DataPortalClient.HttpProxy).AssemblyQualifiedName;

            //Csla.ApplicationContext.DataPortalUrlString = AppHostUrl;


        }


    }
}
