using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Domain.Entities
{
    public class Friend
    {
        public int id { get; set; }
        public int SenderId { get; set; }
        public int receiverId { get; set; }
        public string? message { get; set; }
        public Boolean isFriend { get; set; }
    }
}
