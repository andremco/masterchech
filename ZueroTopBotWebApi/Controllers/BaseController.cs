using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ZueroTopBotWebApi.Controllers
{
    public abstract class BaseController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        protected new IActionResult Response(object obj = null)
        {
            if (ModelState.IsValid)
            {
                return Ok(new { success = true, data = obj });
            }
            else
            {
                return Ok(new { success = false, data = ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage)});
            }
        }
    }
}
