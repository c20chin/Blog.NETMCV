using System;
using Blog.NETMVC.Data;
using Blog.NETMVC.Models.Domain;
using Blog.NETMVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Blog.NETMVC.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext blogDbContext;

        public TagRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }


        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogDbContext.Tags.AddAsync(tag);
            await blogDbContext.SaveChangesAsync();
            return tag;
        }


        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogDbContext.Tags.FindAsync(id);
                
            if (existingTag != null)
            {
                blogDbContext.Tags.Remove(existingTag);
                await blogDbContext.SaveChangesAsync();

                // Show success notification
                return existingTag;
            }
            return null;
        }


        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogDbContext.Tags.ToListAsync();
        }


        public async Task<Tag?> GetAsync(Guid id)
        {
            return await blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);            
        }


        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await blogDbContext.SaveChangesAsync();
                return existingTag;

            }

            return null;
        }
    }
}

