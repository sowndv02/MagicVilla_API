using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.Dto
{
    public class VillaCreateDTO
    {
        [Required]
        public string VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
