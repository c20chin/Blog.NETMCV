using System;
namespace Blog.NETMVC.Models.Domain
{
    public class Mission
    {
        public Guid Id { get; set; }

        public string mission_id { get; set; }

        public string mission_name { get; set; }

        public string website { get; set; }

        public string description { get; set; }

    }
}

//add note