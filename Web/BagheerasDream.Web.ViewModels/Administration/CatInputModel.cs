namespace BagheerasDream.Web.ViewModels.Administration
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BagheerasDream.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class CatInputModel
    {
        [Required(ErrorMessage = "Липсва снимка!")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Липсва името!")]
        public string Name { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "Липсва пола!")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Липсва породата!")]
        public Breed Breed { get; set; }

        [Required(ErrorMessage = "Липсва цвета!")]
        public Colour Colour { get; set; }

        [Required(ErrorMessage = "Липсва датата на раждане!")]
        public DateTime? Birthday { get; set; }
    }
}
