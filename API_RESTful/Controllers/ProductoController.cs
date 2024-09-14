using API_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transferencia_Datos.Producto_DTO;


namespace API_RESTful.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // Representa La DB:
        private readonly MyDBcontext _MyDBcontext;

        // Constructor:
        public ProductoController(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }



        // **************** ENDPOINTS QUE MANDARAN OBJETOS *****************
        // *****************************************************************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Obtenemos Todos Los Registros:
            List<Producto> Registros_Productos = await _MyDBcontext.Productos.ToListAsync();

            // La Lista de este Objeto Retornaremos:
            Registrados_Producto_DTO Lista_Productos = new Registrados_Producto_DTO();

            // Agregamos cada registro obtenido a la lista que retornaremos:
            foreach (Producto producto in Registros_Productos)
            {
                Lista_Productos.Lista_Productos.Add(new Registrados_Producto_DTO.Producto
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Categoria = producto.Categoria,
                    Precio = producto.Precio
                });
            }


            return Ok(Lista_Productos);
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Obtenemos de la DB:
            Producto? Objeto_Obtenido = await _MyDBcontext.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);

            if(Objeto_Obtenido!=null)
            {
                // Agregamos los Datos del de la DB:
                ObtenerPorID_Producto_DTO Registro_Obtenido = new ObtenerPorID_Producto_DTO
                {
                    IdProducto = Objeto_Obtenido.IdProducto,
                    Nombre = Objeto_Obtenido.Nombre,
                    Categoria = Objeto_Obtenido.Categoria,
                    Precio = Objeto_Obtenido.Precio
                };

                return Ok(Registro_Obtenido);

            }
            else
            {
                return NotFound("Registro No Existente.");
            }

        }



        // *******  ENPOINTS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  *******
        // ********************************************************************

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Crear_Producto_DTO crear_Producto_DTO)
        {
            // Objeto a guardar en la DB:
            Producto producto = new Producto 
            {
                Nombre=crear_Producto_DTO.Nombre,
                Categoria=crear_Producto_DTO.Categoria,
                Precio=crear_Producto_DTO.Precio
            };

            _MyDBcontext.Add(producto);
            await _MyDBcontext.SaveChangesAsync();

            return Ok("Guardado Correctamente");
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Editar_Producto_DTO editar_Producto_DTO)
        {
            Producto? Objeto_Obtenido = await _MyDBcontext.Productos.FirstOrDefaultAsync(x => x.IdProducto == editar_Producto_DTO.IdProducto);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.Nombre = editar_Producto_DTO.Nombre;
                Objeto_Obtenido.Categoria = editar_Producto_DTO.Categoria;
                Objeto_Obtenido.Precio = editar_Producto_DTO.Precio;

                // Actualizamos:
                _MyDBcontext.Update(Objeto_Obtenido);
                await _MyDBcontext.SaveChangesAsync();

                return Ok("Modificado Exitosamente.");
            }
            else
            {
                return NotFound("No Se Encontro El Registro.");
            }

        }



        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Producto? Objeto_Obtenido = await _MyDBcontext.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);

            if (Objeto_Obtenido != null)
            {
                _MyDBcontext.Remove(Objeto_Obtenido);
                await _MyDBcontext.SaveChangesAsync();

                return Ok("Eliminado Correctamente.");
            }
            else
            {
                return NotFound("No Se Encontro El Registro.");
            }

        }

    }
}
