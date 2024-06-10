using Microsoft.AspNetCore.Mvc;
using miniporjectmvc.Data;

namespace miniporjectmvc.Controllers
{
    public class HomeController : Controller
    {
  

      public IActionResult index() 
      {
            return View(); 
      }
         

       
    }
}