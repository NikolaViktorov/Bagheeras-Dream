using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagheerasDream.Data.Models.Litter
{
    public class Litter
    {
        public Litter()
        {
            this.LitterId = Guid.NewGuid().ToString();
            this.Kittens = new HashSet<Kitten>();
        }

        public string LitterId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Colours { get; set; }

        public string MotherName { get; set; }

        public string FatherName { get; set; }

        public string BloodGroup { get; set; }

        public virtual ICollection<Kitten> Kittens { get; set; }
    }
}
