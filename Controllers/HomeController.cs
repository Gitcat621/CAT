using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proyecto24BM.Context;
using proyecto24BM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto24BM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDdContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _context.usuarios.Include(z => z.Roles).ToListAsync();

            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(usuario request)
        {
            try
            {
                if (request != null)
                {
                    usuario usuario = new usuario();
                    usuario.Nombre = request.Nombre;
                    usuario.User = request.User;
                    usuario.Password = request.Password;
                    usuario.Fkrol = 1;

                    _context.usuarios.Add(usuario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View();
            } catch (Exception ex)
            {
                throw new Exception("Errors papu " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                var usuario = _context.usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                else
                    return View(usuario);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
