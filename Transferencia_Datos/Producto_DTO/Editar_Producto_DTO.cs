using System.ComponentModel.DataAnnotations;


namespace Transferencia_Datos.Producto_DTO
{
    public class Editar_Producto_DTO
    {
        // ATRIBUTOS:
        [Required]
        public int IdProducto { get; set; }


        [Required(ErrorMessage = "Nombre Del Producto Obligatorio.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Categoria Del Producto Obligatoria.")]
        public string Categoria { get; set; }


        [Required(ErrorMessage = "Precio Del Producto Obligatorio.")]
        public decimal Precio { get; set; }


    }
}
