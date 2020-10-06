using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BAAC.Memberships.Web.Models;
using BAAC.Memberships.Services.Data;
using BAAC.Memberships.Models;

namespace BAAC.Memberships.Web.Controllers {
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly AppDb db;

    public HomeController(ILogger<HomeController> logger, AppDb db) {
      _logger = logger;
      this.db = db;
    }

    public IActionResult Index() {
      return View();
    }

    public IActionResult CreatePackages() {
      var p = new Package();
      p.Code = "Free";
      p.Name = "Free";
      p.Days = 9999;
      p.Price = 0m;

      db.Packages.Add(p);
      db.SaveChanges();

      return Ok("Done.");

    }

    public IActionResult Privacy() {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
