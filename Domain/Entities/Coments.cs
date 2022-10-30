using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Domain.Entities
{
    public class Coments
    {
        public int id { get; set; }
        public string? Content { get; set; }
        public int postComentID { get; set; }
        public int userID { get; set; }

        public Users user { get; set; }
        public Post Post { get; set; }
    }
}
