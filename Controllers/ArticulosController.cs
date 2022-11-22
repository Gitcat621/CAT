using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using proyecto24BM.Context;
using proyecto24BM.Models;
using System;
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

        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GBA3LGV; initial catalog = proyecto24BM; Integrated Security = true;");
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

        [HttpPost]
        public async Task<IActionResult> Crear(Articulos response)
        {
            try
            {
                if (response != null)
                {
                    await connection.QueryAsync<Articulos>("spInsertArticulo", new { response.Nombre, response.Descripcion, response.Urlimg });
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Errors papu " + ex.Message);
            }
        }
    }
}
