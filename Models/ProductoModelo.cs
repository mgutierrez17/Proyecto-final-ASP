namespace Proyecto_final_ASP.Models
{
    public class ProductoModelo
    {
        List<Producto> productos;
        public ProductoModelo(SuperMercadoContext context)
        {
            productos = context.Productos.ToList();
        }
        public List<Producto> getTodos()
        {
            return productos;
        }
        public Producto getById(int id)
        {
            return productos.Single(prod => prod.Id == id);//SELECT * FROM Producto WHERE Id = id;
        }
    }
}