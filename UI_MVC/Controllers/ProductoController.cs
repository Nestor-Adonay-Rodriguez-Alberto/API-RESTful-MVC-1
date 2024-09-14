using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Transferencia_Datos.Producto_DTO;

namespace UI_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // Para Hacer Solicitudes Al Servidor:
        private readonly HttpClient _HttpClient;


        // Constructor:
        public ProductoController(IHttpClientFactory httpClientFactory)
        {
            _HttpClient = httpClientFactory.CreateClient("API_RESTful");
        }



        // **************** ENDPOINTS QUE MANDARAN OBJETOS *****************
        // *****************************************************************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        public async Task<IActionResult> Index()
        {
            // Solicitud GET al Endpoint de la API:
            HttpResponseMessage JSON_Obtenidos = await _HttpClient.GetAsync("/api/Producto");

            // OBJETO:
            Registrados_Producto_DTO Lista_Productos = new Registrados_Producto_DTO();

            // True=200-299
            if (JSON_Obtenidos.IsSuccessStatusCode)
            {
                // Deserializamos el Json:
                Lista_Productos = await JSON_Obtenidos.Content.ReadFromJsonAsync<Registrados_Producto_DTO>();
            }


            return View(Lista_Productos);
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        public async Task<IActionResult> Details(int id)
        {
            // Solicitud GET al Endpoint de la API:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("/api/Producto/"+id);

            // OBJETO:
            ObtenerPorID_Producto_DTO Objeto_Obtenido = new ObtenerPorID_Producto_DTO();

            // True=200-299
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                // Deserializamos el Json:
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<ObtenerPorID_Producto_DTO>();
            }

            return View(Objeto_Obtenido);
        }





        // *******  ENPOINTS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  *******
        // ********************************************************************

        // NOS MANDA A LA VISTA:
        public ActionResult Create()
        {
            return View();
        }

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Crear_Producto_DTO crear_Producto_DTO)
        {
            // Solicitud POST al Endpoint de la API:
            HttpResponseMessage Respuesta = await _HttpClient.PostAsJsonAsync("/api/Producto",crear_Producto_DTO);

            // True=200-299
            if (Respuesta.IsSuccessStatusCode)
            {
                // Volemos a Vista Principal:
                return RedirectToAction(nameof(Index));
            }


            ViewBag.Error = "Error al intentar guardar el registro";
            return View();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MANDA A VISTA
        public async Task<IActionResult> Edit(int id)
        {
            // Solicitud GET al Endpoint de la API:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("/api/Producto/" + id);

            // OBJETO:
            ObtenerPorID_Producto_DTO Objeto_Obtenido = new ObtenerPorID_Producto_DTO();

            // True=200-299
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                // Deserializamos el Json:
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<ObtenerPorID_Producto_DTO>();
            }

            Editar_Producto_DTO Objeto_Editar = new Editar_Producto_DTO 
            {
                IdProducto=Objeto_Obtenido.IdProducto,
                Nombre=Objeto_Obtenido.Nombre,
                Categoria=Objeto_Obtenido.Categoria,
                Precio=Objeto_Obtenido.Precio
            };

            return View(Objeto_Editar);
        }


        // RECIBE EL OBJETO MODIFICADO Y LO MODIFICA EN DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Editar_Producto_DTO editar_Producto_DTO)
        {
            // Solicitud PUT al Endpoint de la API:
            HttpResponseMessage Respuesta = await _HttpClient.PutAsJsonAsync("/api/Producto",editar_Producto_DTO);

            // True=200-299
            if (Respuesta.IsSuccessStatusCode)
            {
                // Volemos a Vista Principal:
                return RedirectToAction(nameof(Index));
            }


            ViewBag.Error = "Error al intentar Modificar el registro";
            return View();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MANDA A VISTA:
        public async Task<IActionResult> Delete_Vista(int id)
        {
            // Solicitud GET al Endpoint de la API:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("/api/Producto/" + id);

            // OBJETO:
            ObtenerPorID_Producto_DTO Objeto_Obtenido = new ObtenerPorID_Producto_DTO();

            // True=200-299
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                // Deserializamos el Json:
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<ObtenerPorID_Producto_DTO>();
            }

            return View(Objeto_Obtenido);
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ObtenerPorID_Producto_DTO obtenerPorID_Producto_DTO)
        {
            // Solicitud GET al Endpoint de la API:
            HttpResponseMessage Respuesta = await _HttpClient.DeleteAsync("/api/Producto/" + obtenerPorID_Producto_DTO.IdProducto);

            // True=200-299
            if (Respuesta.IsSuccessStatusCode)
            {
                // Volemos a Vista Principal:
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "Error al intentar Eliminar el registro";
            return View();
        }
    
    }
}
