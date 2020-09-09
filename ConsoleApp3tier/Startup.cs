using Csla;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.UI
{
    static class Startup
    {
        const string AppHostUrl = "http://localhost:8001/";

        public static void Init()
        {


            Console.WriteLine($"Set Dataportal Proxy : {AppHostUrl}");

            Csla.ApplicationContext.DataPortalProxy = typeof(Csla.DataPortalClient.HttpProxy).AssemblyQualifiedName;

            Csla.ApplicationContext.DataPortalUrlString = AppHostUrl;
             

        }


    }
}
