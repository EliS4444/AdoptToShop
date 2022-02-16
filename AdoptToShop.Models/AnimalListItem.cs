using System;

namespace AdoptToShop.Models
{
    public class AnimalListItem
    {
        public Guid PetId { get; set; }
        public char Name { get; set; }
        public string Species { get; set; }
        public string Sex { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public bool IsSpayed { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
