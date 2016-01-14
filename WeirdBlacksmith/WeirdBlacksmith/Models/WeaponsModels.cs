using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeirdBlacksmith.Models
{
    public class WeaponsModels
    {
        public long Id { get; set; }
        [Required]
        public string Rarity { get; set; }
        [Required]
        [StringLength(22, MinimumLength = 6)]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 1)]
        public string Description { get; set; }
        [Required]
        [Range(0, 999, ErrorMessage = "Number must be between 0 and 999")]
        public int MinDamage { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Number msut be between 1 and 1000")]
        public int MaxDamage { get; set; }
        [Required]
        [RegularExpression(".*(.png|.jpg).*", ErrorMessage = "Wrong Url - example: http://www.images.com/sword.png")]
        public string ImageUrl { get; set; }
        public DateTime Added { get; set; }
        public int TitleModelsId { get; set; }
        public virtual ICollection<TitleModels> TitleModels { get; set; }

    }
}