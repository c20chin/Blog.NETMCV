using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.NETMVC.Controllers
{
    public class BlogsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



    }
}