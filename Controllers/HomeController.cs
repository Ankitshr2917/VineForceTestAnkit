using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VineForceTestAnkit.Data;
using VineForceTestAnkit.Models;

namespace VineForceTestAnkit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbcontext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbcontext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CountryList()
        {
            
            return View();
        }
        #region Countryregion

        [HttpGet]
        public IActionResult GetCountryList()
        {
            var countryList = _context.Country.ToList();
            return Json(new {data = countryList });
        }

        public IActionResult Upsert(int? id)
        {
            Country Country = new Country();
            if (id == null) return View(Country);

            Country = _context.Country.FirstOrDefault(x=>x.id==id);

            return View(Country);
        }
        [HttpPost]  
        public IActionResult Upsert(Country country)
        {
            if (country.id == 0)
            {
                _context.Country.Add(country);
                 
            }
            else
            {
                    var find = _context.Country.FirstOrDefault(x=>x.id == country.id);
                   if (find == null) return NotFound();
                   find.Name =country.Name;
                
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(CountryList));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == null) return Json(new { success = false, messages = "Something went wrong" });
            var find = _context.Country.Find(id);
            _context.Country.Remove(find);
            _context.SaveChanges();
            return Json(new { success = true, messages = "Data Delted Successfully" });
        }



        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}