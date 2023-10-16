using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.NETMVC.Data;
using Blog.NETMVC.Models.Domain;
using Blog.NETMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.NETMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BlogDbContext blogDbContext;

        public AdminTagsController(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        [HttpGet]
        public IActionResult Add()  // http://localhost:xxxx/AdminTags/Add: To view the Add page
        {
            return View();
        }

        
        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitTag(AddTagRequest addTagRequest)
        {
            //Mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };



            blogDbContext.Tags.Add(tag);
            blogDbContext.SaveChanges();
            

            return View("Add");
        }
    }
}