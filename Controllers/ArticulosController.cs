using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto24BM.Context;
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
        public async Task<IActionResult> Articulos()
        {
            var response = await _context.articulos.ToListAsync();

            return View(response);
        }
        
    }
}
