namespace BagheerasDream.Data.Models.Cats
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BagheerasDream.Data.Models.Enums;

    public class Cat
    {
        public Cat()
        {
            this.CatId = Guid.NewGuid().ToString();
        }

        public string CatId { get; set; }

        public string Name { get; set; }

        public string? Title { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        public virtual int ColourId { get; set; }

        [EnumDataType(typeof(Colour))]
        public Colour Colour
        {
            get
            {
                return (Colour)this.ColourId;
            }

            set
            {
                this.ColourId = (int)value;
            }
        }

        [Required]
        public virtual int BreedId { get; set; }

        [EnumDataType(typeof(Breed))]
        public Breed Breed
        {
            get
            {
                return (Breed)this.BreedId;
            }

            set
            {
                this.BreedId = (int)value;
            }
        }

        [Required]
        public virtual int GenderId { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender
        {
            get
            {
                return (Gender)this.GenderId;
            }

            set
            {
                this.GenderId = (int)value;
            }
        }

        public string ProfileImage { get; set; }
    }
}
