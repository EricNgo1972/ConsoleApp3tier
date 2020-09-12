using System;
using System.Threading.Tasks;
using Csla;
using Microsoft.AspNetCore.Mvc;

namespace SPC.API.Controllers
{
  //[ApiController]
  [Route("[controller]")]
  public class DataPortalController : Csla.Server.Hosts.HttpPortalController
  {
    //// This override exists for demo purposes only, normally you
    //// wouldn't implement this code.
    //[HttpPost]
    //public override Task PostAsync([FromQuery] string operation)
    //{
    //  return base.PostAsync(operation);
    //}

    //// Implementing a GET is totally optional, but is nice
    //// for quick diagnosis as to whether a service is running.
    //// GET api/values
    //[HttpGet]
    //public async Task<ActionResult<string>> GetAsync()
    //{
    //  try
    //  {
    //    var obj = await DataPortal.FetchAsync<SPC.ContactInfoList>();
    //    return $"{obj.Count} contact exist;";
    //  }
    //  catch (Exception ex)
    //  {
    //    return ex.ToString();
    //  }
    //}


  }
}