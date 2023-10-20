using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.NETMVC.Data;
using Blog.NETMVC.Models.Domain;
using Blog.NETMVC.Models.ViewModels;
using Blog.NETMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.NETMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        //get all tags
        [HttpGet]
        public IActionResult Add()  // http://localhost:xxxx/AdminTags/Add: To view the Add page
        {
            return View();
        }

        //Add tags
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> SubmitTag(AddTagRequest addTagRequest)
        {
            //Mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }


        //List out all tags
        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            // Use DBContext to read the tags
            var tags = await tagRepository.GetAllAsync();

            return View(tags);
        }


        //get one tag detail
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var tag = await tagRepository.GetAsync(id);

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

        //update tag
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if (updatedTag != null)
            {
                //Show success
                return RedirectToAction("List");
            } 
            else
            {
                //Show fail
            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        //delete tag
        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                //show success
                return RedirectToAction("List");
            }

            // Show error message
            return RedirectToAction("Edit", new { id = editTagRequest.Id });

        }
    }
}