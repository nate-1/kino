using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Kino.Models;
using Kino.Services;
using Kino.Services.ViewModel;

namespace Kino.Controllers
{
    public class AuthController : Controller
    {
        public AuthController()
        {
        }

        [HttpGet]
        public IActionResult Connect()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Connect(int model)
        {
            return View();
        }
        public IActionResult Disconnect()
        {
            return View();
        }
    }
}