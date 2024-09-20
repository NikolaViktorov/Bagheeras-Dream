namespace BagheerasDream.Web.ViewModels.Litter
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LitterInputModel
    {
        [Required(ErrorMessage = "Липсва името!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Липсва датата на раждане!")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Липсват цветовете на котета")]
        public string Colours { get; set; }

        [Required(ErrorMessage = "Липсва името на майката")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Липсва името на бащата")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Липсва кръвната група")]
        public string BloodGroup { get; set; }
    }
}
