using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnowboardShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace SnowboardShop.Controllers
{
    [Authorize(Roles = "User")]
    public class PanierController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Boards = SessionExtensions.GetObjectFromJson<ShoppingCart>(HttpContext.Session, "panier").mesBoards;
            return View();
        }
    }
}