using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.Dto
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public string VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
