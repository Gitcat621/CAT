﻿using Microsoft.AspNetCore.Mvc;

namespace proyecto24BM.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
