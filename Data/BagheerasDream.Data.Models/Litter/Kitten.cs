using BagheerasDream.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagheerasDream.Data.Models.Litter
{
    public class Kitten
    {
        public Kitten()
        {
            this.KittenId = Guid.NewGuid().ToString();
        }

        public string KittenId { get; set; }

        public string Name { get; set; }

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

        public string PedigreeImage { get; set; }

        public string? LitterId { get; set; }

        public virtual Litter Litter { get; set; }
    }
}
