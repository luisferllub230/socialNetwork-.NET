using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Domain.Entities
{
    public class Users
    {
        public int id { get; set; }
        public string? UserNickName { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserPhoto { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public string? UserPassword { get; set; }
        //public Boolean isActive { get; set; }

        public ICollection<Post> post { get; set; }
        public ICollection<Coments> Coments { get; set; }
    }
}
