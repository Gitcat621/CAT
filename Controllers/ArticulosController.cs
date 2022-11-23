using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using proyecto24BM.Context;
using proyecto24BM.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace proyecto24BM.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDdContext _context;

        public ArticulosController(ApplicationDdContext context)
        {
            _context = context;
        }

        SqlConnection connection = new SqlConnection("Data Source = LAPTOP-1TJ137V4; initial catalog = proyecto24BM; Integrated Security = true;");
        //LAPTOP-1TJ137V4  DESKTOP-GBA3LGV
        public async Task<IActionResult> Index()
        {
            /*try
            {
                var response = await connection.QueryAsync<Articulos>();
            }catch (Exception ex)
            {

            }*/

            var response = await _context.articulos.ToListAsync();

            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearArticulo(Articulos response)
        {
            try
            {
                if (response != null)
                {
                    await connection.QueryAsync<Articulos>("spInsertArticulo", new { response.Nombre, response.Descripcion, response.Urlimg }, commandType: CommandType.StoredProcedure);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Errors papu " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var articulo = _context.articulos.Find(id);
                if (articulo == null)
                {
                    return NotFound();
                }
                else
                    return View(articulo);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var articulos = _context.articulos.Find(id);

            _context.Remove(articulos);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
