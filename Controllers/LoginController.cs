using Microsoft.AspNetCore.Mvc;
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

        public JsonResult LoginUser(string user, string Password)
        {
            try
            {
                var response = _context.usuarios.Where(x => x.User == user && x.Password == Password);
                if(response.Count() > 0)
                {
                    //se va a logear
                    return Json(new { Succes = true});
                }
                else
                {
                    //Errors
                    return Json(new { Succes = false });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un eror" + ex.Message);
            }
        }
    }
}
