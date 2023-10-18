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
            

            return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            // Use DBContext to read the tags
            var tags = blogDbContext.Tags.ToList();

            return View(tags);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            // first method
            //var tag = blogDbContext.Tags.Find(id);

            // second method
            var tag = blogDbContext.Tags.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
                
            }
                

            return View(null);
        }

        [HttpPost]
        public IActionResult Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var existingTag = blogDbContext.Tags.Find(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                blogDbContext.SaveChanges();
                return RedirectToAction("List");

            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }


        [HttpPost]
        public IActionResult Delete(EditTagRequest editTagRequest)
        {
            var tag = blogDbContext.Tags.Find(editTagRequest.Id);

            if (tag != null)
            {
                blogDbContext.Tags.Remove(tag);
                blogDbContext.SaveChanges();

                // Show success notification
                return RedirectToAction("List");
            }

            // Show error message
            return RedirectToAction("Edit", new { id = editTagRequest.Id });

        }
    }
}