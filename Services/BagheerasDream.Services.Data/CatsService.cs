namespace BagheerasDream.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BagheerasDream.Data;
    using BagheerasDream.Data.Models.Enums;
    using BagheerasDream.Services.Data.Contracts;
    using BagheerasDream.Web.ViewModels.Cats;
	using BagheerasDream.Web.ViewModels.Litter;
	using Microsoft.EntityFrameworkCore;

    public class CatsService : ICatsService
    {
        private readonly ApplicationDbContext db;

        public CatsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<CatViewModel>> GetAll(Gender gender)
        {
            var genderId = (int)gender;

            List<CatViewModel> cats = new List<CatViewModel>();

            cats = await this.db.Cats.Where(c => c.GenderId == genderId)
                .Select(c => new CatViewModel()
            {
                CatId = c.CatId,
                Name = c.Name,
                Title = c.Title,
                Birthday = (DateTime)c.Birthday,
                Colour = c.Colour.ToString(),
                ProfileImage = c.ProfileImage,
            }).ToListAsync();

            return cats;
        }

        public async Task<CatViewModel> GetCat(string id)
        {
            var cat = await this.db.Cats.FirstOrDefaultAsync(c => c.CatId == id);
            if (cat == null)
            {
                throw new ArgumentException("There is no cat with given id!");
            }

            var model = new CatViewModel()
            {
                CatId = cat.CatId,
                Name = cat.Name,
                Title = cat.Title,
                Birthday = (DateTime)cat.Birthday,
                Colour = cat.Colour.ToString(),
                ProfileImage = cat.ProfileImage,
            };

            return model;
        }

        public async Task<ICollection<LitterViewModel>> GetLitters()
        {
            var litters = await this.db.Litters.Include(l => l.Kittens)
                .Select(l => new LitterViewModel()
                {
                    LitterId = l.LitterId,
                    Name = l.Name,
                    Birthday = l.Birthday,
                    Colours = l.Colours,
                    FatherName = l.FatherName,
                    MotherName = l.MotherName,
                    BloodGroup = l.BloodGroup,
                    Kittens = l.Kittens.Select(k => new KittenViewModel()
                    {
                        KittenId = k.KittenId,
                        Name = k.Name,
                        Gender = k.Gender.ToString(),
                        PedigreeImage = k.PedigreeImage,
                        ProfileImage = k.ProfileImage,
                    }).ToList(),
                })
                .OrderBy(l => l.Name)
                .ToListAsync();

            return litters;
        }
    }
}
