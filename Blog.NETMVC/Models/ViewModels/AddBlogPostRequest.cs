using System;
using Blog.NETMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.NETMVC.Models.ViewModels
{
	public class AddBlogPostRequest
	{
        public string Heading { get; set; }

        public string PageTitle { get; set; }

        public string Content { get; set; }

        public string ShortDescription { get; set; }

        public string FeaturedImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public bool Visible { get; set; }

        //DisplayTags
        public IEnumerable<SelectListItem> Tags { get; set; }

        public string[] SelectedTags { get; set; } = Array.Empty<string>();

    }
}

