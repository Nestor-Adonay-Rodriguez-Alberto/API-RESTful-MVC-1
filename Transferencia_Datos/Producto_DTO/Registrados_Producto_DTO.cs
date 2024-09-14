using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia_Datos.Producto_DTO
{
    public class Registrados_Producto_DTO
    {

        // CLASE:
        public class Producto
        {
            public int IdProducto { get; set; }

            public string Nombre { get; set; }

            public string Categoria { get; set; }

            public decimal Precio { get; set; }

        }


        // Lista de todos los Registro en la DB
        public List<Producto> Lista_Productos { get; set; }


        // Constructor
        public Registrados_Producto_DTO()
        {
            Lista_Productos = new List<Producto>();
        }

    }
}
