using Proyecto_final_ASP.Auxiliarles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_final_ASP.Models;

namespace Proyecto_final_ASP.Controllers
{
    public class CarritoController : Controller
    {
        private SuperMercadoContext context;
        // GET: CarritoController

        public CarritoController(SuperMercadoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Elemento> carrito = ConversorSesion.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            ViewBag.total = carrito.Sum(item => item.producto.Precio * item.cantidad);
            return View();
        }
        [Route("agregar/{id}")]
        public IActionResult agregar(int id)
        {
            ProductoModelo productoModelo = new ProductoModelo(context);
            if (ConversorSesion.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito") == null)
            {
                List<Elemento> carrito = new List<Elemento>();
                carrito.Add(new Elemento
                {
                    producto = productoModelo.getById(id),
                    cantidad = 1
                });
                ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "carrito", carrito);
            }
            else
            {
                List<Elemento> carrito = ConversorSesion.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
                int indice = existe(id);
                if (indice != -1)
                    carrito[indice].cantidad++;
                else
                    carrito.Add(new Elemento { producto = productoModelo.getById(id), cantidad = 1 });
                ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "carrito", carrito);
            }
            return RedirectToAction("Index");
        }
        private int existe(int id)
        {
            List<Elemento> carrito = ConversorSesion.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            for (int i = 0; i < carrito.Count; i++)
                if (carrito[i].producto.Id == id)
                    return i;
            return -1;
        }
        [Route("eliminar/{id}")]
        public IActionResult eliminar(int id)
        {
            List<Elemento> carrito = ConversorSesion.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
            int indice = existe(id);
            carrito.RemoveAt(indice);
            ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
    }
}
