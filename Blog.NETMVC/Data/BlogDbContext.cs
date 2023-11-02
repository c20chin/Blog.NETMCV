using System;
using Blog.NETMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.NETMVC.Data
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<BlogPost> BlogPosts { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public DbSet<Mission> Missions { get; set; }
	}
}

