using Microsoft.EntityFrameworkCore;

namespace Proyecto_final_ASP.Models
{
    public class SuperMercadoContext : DbContext
    {
        public virtual DbSet<Producto> Productos { get; set; }
        public SuperMercadoContext()
        {

        }
        public SuperMercadoContext(DbContextOptions<SuperMercadoContext> opciones) : base(opciones)
        {

        }
    }

}
