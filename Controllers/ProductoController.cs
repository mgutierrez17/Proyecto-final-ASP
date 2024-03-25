using Proyecto_final_ASP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_final_ASP.Controllers
{
    public class ProductoController : Controller
    {
        private SuperMercadoContext context;
        private IWebHostEnvironment webHostEnvironment;

        public ProductoController(SuperMercadoContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ProductoModelo productoModelo = new ProductoModelo(context);
            ViewBag.productos = productoModelo.getTodos();
            return View();
        }
        [Route("paraeditar/{id}")]
        public IActionResult paraeditar(int id)
        {
            Producto prod = context.Productos.FirstOrDefault(p => p.Id == id);

            return View("editar", prod);
        }
        [HttpPost]
        public IActionResult Editar(Producto prod, IFormFile foto)
        {
            prod.Foto = "queso.jpg";
            context.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("eliminar/{id}")]
        public IActionResult eliminar_p(int id)
        {
            //ViewBag.producto = context.Productos.FirstOrDefault(p=>p.Id==id);
            Producto producto = context.Productos.FirstOrDefault(o => o.Id == id);
            return View("Eliminar", producto);//Pasar como modelo
        }
        [HttpPost]
        public IActionResult eliminar_p(Producto prod)
        {
            context.Productos.Remove(context.Productos.Find(prod.Id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
