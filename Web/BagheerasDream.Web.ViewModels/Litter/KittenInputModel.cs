namespace BagheerasDream.Web.ViewModels.Litter
{
    using System.ComponentModel.DataAnnotations;

    using BagheerasDream.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class KittenInputModel
    {
        [Required]
        public string LitterId { get; set; }

        [Required(ErrorMessage = "Липсва името!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Липсва пола!")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Липсва снимка на котето!")]
        public IFormFile ProfileImage { get; set; }

        [Required(ErrorMessage = "Липсва снимка на родословието!")]
        public IFormFile PedigreeImage { get; set; }
    }
}
