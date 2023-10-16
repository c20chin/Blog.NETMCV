using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.NETMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.NETMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        [HttpGet]
        public IActionResult Add()  // http://localhost:xxxx/AdminTags/Add: To view the Add page
        {
            return View();
        }


        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitTag(AddTagRequest addTagRequest)
        {
            var name = addTagRequest.Name;
            var displayName = addTagRequest.DisplayName;

            return View("Add");
        }
    }
}