using System.ComponentModel.DataAnnotations;

namespace FirstCoreWebApp.Models
{
    public class CarViewModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string ModelName { get; set; }

    }
}