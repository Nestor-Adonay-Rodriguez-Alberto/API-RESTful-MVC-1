using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_RESTful.Models
{
    public class Producto
    {
        // ATRIBUTOS:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }


        [Required]
        public string Nombre { get; set; }


        [Required]
        public string Categoria { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

    }
}
