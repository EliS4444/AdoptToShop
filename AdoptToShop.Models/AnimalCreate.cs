namespace AdoptToShop.Models
{
    public class AnimalCreate
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Sex { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public bool Spayed { get; set; }
        public string Description { get; set; }
    }
}
