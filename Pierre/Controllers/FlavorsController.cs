using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Pierre.Models;

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
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId== id);
      Viewbag.TreatId = new SelectList(_db.Treats, "TreatId", "Type");
      return View(thisFlavor);
    }
    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
      #nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
      if (joinEntity == null && treatId !=0)
      #nullable disable
      {
        _db.TreatFlavors.Add(new TreatFlavor() {TreatId = treatId, FlavorId = flavor.FlavorId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new{id = flavor.FlavorId});
    }
    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      return View(thisTag);
    }
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id )
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      return View(thisFlavor);

    } 

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors = flavors.FlavorId == id);
        _db.Flavors.Remove(thisFlavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      [HttpPost]
      public ActionResult DeleteJoin(int joinId)
      {
        TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId== joinId);
        _db.TreatFlavors.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    }



  }