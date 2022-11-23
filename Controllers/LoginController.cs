using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto24BM.Context;
using System;
using System.Linq;

namespace proyecto24BM.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDdContext _context;

        public LoginController(ApplicationDdContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginUser(string user, string Password)
        {
            try
            {
                //var response = _context.usuarios.Where(x => x.User == user && x.Password == Password).ToList();

                var response = _context.usuarios.Include(z => z.Roles).FirstOrDefault
                    (x => x.User == user && x.Password == Password);

                if (response != null)
                {
                    if (response.Roles.Nombre == "Admin")
                    {
                        //se va a logear
                        return Json(new { success = true, admin = true });
                    }
                    return Json(new { success = true, admin = false });
                }
                else
                {
                    //Errors
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un eror" + ex.Message);
            }
        }
    }
}
