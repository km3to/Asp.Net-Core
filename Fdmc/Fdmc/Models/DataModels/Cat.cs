using System.ComponentModel.DataAnnotations;

namespace Fdmc.Models.DataModels
{
    public class Cat
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string ImageUrl { get; set; }
    }
}
