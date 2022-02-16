using System;
using System.ComponentModel.DataAnnotations;

namespace AdoptToShop.Data_
{
    public class Adopter
    {

        [Key]
        [Required]
        public Guid AdopterId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public bool Approved { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
