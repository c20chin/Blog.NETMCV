using System;
using Blog.NETMVC.Models.Domain;

namespace Blog.NETMVC.Repositories
{
	public interface ITagRepository
	{

		Task<IEnumerable<Tag>> GetAllAsync();

		Task<Tag?> GetAsync(Guid id);

		Task<Tag> AddAsync(Tag tag);

        Task<Tag?> UpdateAsync(Tag tag);

        Task<Tag?> DeleteAsync(Guid id);

    }
}

