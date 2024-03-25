using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_final_ASP.Controllers
{
    public class indexController : Controller
    {
        // GET: indexController1cs
        public ActionResult Index()
        {
            return View();
        }

        // GET: indexController1cs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: indexController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: indexController1cs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: indexController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: indexController1cs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: indexController1cs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: indexController1cs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
