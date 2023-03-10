using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers;

public class StylistsController : Controller
{
  private readonly HairSalonContext _db;

  public StylistsController(HairSalonContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Stylist> model = _db.Stylists.ToList();
    return View(model);
  }

  public ActionResult Create() {return View();}

  [HttpPost]
  public ActionResult Create(Stylist newStylist)
  {
    _db.Stylists.Add(newStylist);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int stylistId)
  {
    Stylist targetStylist = _db.Stylists.Include(item => item.Clients).FirstOrDefault(item => item.StylistId == stylistId);
    return View(targetStylist);
  }
}
