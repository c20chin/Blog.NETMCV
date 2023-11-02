using System;
namespace Blog.NETMVC.Models.Domain
{
    public class Mission
    {
        public Guid Id { get; set; }

        public string MissionName { get; set; }

        public DateTime LaunchDate { get; set; }

        public string Description { get; set; }

    }
}

//add note