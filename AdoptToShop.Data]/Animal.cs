using System;
using System.ComponentModel.DataAnnotations;

namespace AdoptToShop.Data_
{
    public class Animal
    {
        [Key]
        public Guid PetId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Breed { get; set; }
        public int Age { get; set; }
        [Required]
        public bool IsSpayed { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Availability { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
