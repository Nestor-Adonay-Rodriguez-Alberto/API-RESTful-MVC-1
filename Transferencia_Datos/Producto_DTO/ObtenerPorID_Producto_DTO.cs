using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia_Datos.Producto_DTO
{
    public class ObtenerPorID_Producto_DTO
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public decimal Precio { get; set; }
    }
}
