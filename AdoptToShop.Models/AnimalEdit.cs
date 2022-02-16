using System;

namespace AdoptToShop.Models
{
    public class AnimalEdit
    {
        public Guid PetId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Sex { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public bool IsSpayed { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; }
    }
}
