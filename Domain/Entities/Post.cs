using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Domain.Entities
{
    public class Post
    {
        public int id { get; set; }
        public string? PostContent { get; set; }
        public string? PostImg { get; set; }
        public int ReactionLikes { get; set; }
        public int TotalComents { get; set; }
        
        public int postUsersId { get; set; }
        
        public Users? PostUsers { get; set; }
        public ICollection<Coments>? ComentsPost { get; set; }

    }
}
