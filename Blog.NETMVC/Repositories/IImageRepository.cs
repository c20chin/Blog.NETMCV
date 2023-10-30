using System;
namespace Blog.NETMVC.Repositories
{
	public interface IImageRepository
	{
		Task<string> UploadAsync(IFormFile file);

	}
}

