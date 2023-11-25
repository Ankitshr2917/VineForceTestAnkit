using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VineForceTestAnkit.Data;
using VineForceTestAnkit.Models;
using VineForceTestAnkit.Models.Vm;

namespace VineForceTestAnkit.Controllers
{
    public class StateController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public StateController(ApplicationDbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            StateVM stateVM  = new StateVM()
            {
                CountryList = _context.Country.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.id.ToString()
                }),
                 StatewithCounrtry = new StatewithCounrtry()
                 
            };
            if (id == null) return View(stateVM);
            else
            {
                stateVM.StatewithCounrtry = _context.State.Include(x => x.Country).FirstOrDefault(x => x.id == id);
            }
            return View(stateVM);
        }

        [HttpPost]
        public IActionResult Upsert(StateVM StateVM)
        {
            if (StateVM.StatewithCounrtry.id == 0)
            {
                _context.State.Add(StateVM.StatewithCounrtry);

            }
            else
            {
                var find = _context.State.FirstOrDefault(x => x.id == StateVM.StatewithCounrtry.id);
                if (find == null) return NotFound();
                find.Name = StateVM.StatewithCounrtry.Name;
                find.Countryid = StateVM.StatewithCounrtry.Countryid;


            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        #region StateRegion
        [HttpGet]
        public IActionResult GetStateList()
        {
            var list = _context.State.Include(x=>x.Country).ToList();
            return Json(new {data=list});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == null) return Json(new { success = false, messages = "Something went wrong" });
            var find = _context.State.Find(id);
            _context.State.Remove(find);
            _context.SaveChanges();
            return Json(new { success = true, messages = "Data Delted Successfully" });
        }

        #endregion
    }
}
