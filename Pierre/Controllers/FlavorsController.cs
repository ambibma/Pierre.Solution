using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Pierre.Controllers
{
  public class FlavorsControllers : Controllers
  {
    private readonly PierreContext _db;
    public FlavorsControllers(PierreContext db)
    {
      _db = db;
    }
    public ActionResult Index() => View(_db.Flavors.ToList());
    
    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors
                              .Include(flavor => flavor.JoinEntities)
                              .ThenInclude(join =>join.Treat)
                              .FirstOrDefault(flavor => flavor.FlavorId ==id);
      return View(thisFlavor);
    }
    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddTreat(int id )
    {
      
    }
  }
}