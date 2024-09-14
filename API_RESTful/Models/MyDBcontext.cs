using Microsoft.EntityFrameworkCore;

namespace API_RESTful.Models
{
    public class MyDBcontext : DbContext
    {
        // CONSTRUCTOR:
        public MyDBcontext(DbContextOptions<MyDBcontext> options)
            : base(options)
        {

        }


        // TABLAS A MAPEAR EN LA DB:
        public DbSet<Producto> Productos { get; set; }
    }
}
