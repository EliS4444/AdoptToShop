using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptToShop.Models
{
    public class AdopterDetail
    {
        public Guid AdopterId { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public bool Approved { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
