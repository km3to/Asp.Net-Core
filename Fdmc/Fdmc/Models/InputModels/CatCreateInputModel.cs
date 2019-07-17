using System.ComponentModel.DataAnnotations;

namespace Fdmc.Models.InputModels
{
    public class CatCreateInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        [Url]
        public string ImageUrl { get; set; }
    }
}
