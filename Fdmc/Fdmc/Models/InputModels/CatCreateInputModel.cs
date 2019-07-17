using System.ComponentModel.DataAnnotations;

namespace Fdmc.Models.InputModels
{
    public class CatCreateInputModel
    {
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string ImageUrl { get; set; }
    }
}
