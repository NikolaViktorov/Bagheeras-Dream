namespace BagheerasDream.Web.ViewModels.Litter
{
    using System;
    using System.Collections.Generic;

    public class LitterViewModel
    {
        public string LitterId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Colours { get; set; }

        public string MotherName { get; set; }

        public string FatherName { get; set; }

        public string BloodGroup { get; set; }

        public virtual ICollection<KittenViewModel> Kittens { get; set; }
    }
}
