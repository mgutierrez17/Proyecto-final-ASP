using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proyecto_final_ASP.Models
{
    public class CuentaViewModel
    {
        public Cuenta cuenta { get; set; }
        public List<Lenguaje> lengueajes { get; set; }
        public SelectList cargos { get; set; }
    }
}
