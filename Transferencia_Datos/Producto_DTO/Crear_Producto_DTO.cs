using System.ComponentModel.DataAnnotations;


namespace Transferencia_Datos.Producto_DTO
{
    public class Crear_Producto_DTO
    {
        // ATRIBUTOS:
        [Required(ErrorMessage = "Nombre Del Producto Obligatorio.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Categoria Del Producto Obligatoria.")]
        public string Categoria { get; set; }


        [Required(ErrorMessage = "Precio Del Producto Obligatorio.")]
        public decimal Precio { get; set; }

    }
}
