using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Pierre.Controllers
{
    public class HomeController : Controller
    {
      private readonly PierreContext _db;
       
      public HomeController(PierreContext db)
      {
      
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        
        Flavor[] flavors = _db.Flavors.ToArray();
        Treat[] treats = _db.Treats.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string,object[]>();
        model.Add("treats", treats);        
        model.Add("flavors", flavors);

        return View(model);
      }
    }
}