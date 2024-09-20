namespace BagheerasDream.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
	using System.IO;
	using System.Threading.Tasks;

    using BagheerasDream.Data;
	using BagheerasDream.Data.Models.Cats;
    using BagheerasDream.Data.Models.Enums;
    using BagheerasDream.Data.Models.Litter;
    using BagheerasDream.Services.Data.Contracts;
    using BagheerasDream.Web.ViewModels.Administration;
    using BagheerasDream.Web.ViewModels.Litter;
    using Microsoft.EntityFrameworkCore;

    public class AdministrationService : IAdministrationService
    {
        private readonly ApplicationDbContext db;

        public AdministrationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddCat(CatInputModel input)
        {
            var fileName = ImageUploader.UploadFile(input.File, "cats");

            if (input.Name == null || input.File == null)
            {
                throw new ArgumentException("Има празни полета!");
            }

            var cat = new Cat()
            {
                Name = input.Name,
                Title = input.Title,
                Birthday = input.Birthday,
                Gender = (Gender)input.Gender,
                Breed = (Breed)input.Breed,
                Colour = (Colour)input.Colour,
                ProfileImage = fileName,
            };

            await this.db.Cats.AddAsync(cat);
            await this.db.SaveChangesAsync();
        }

        public async Task AddKittenToLitter(KittenInputModel input)
        {
            var litter = await this.db.Litters.FirstOrDefaultAsync(l => l.LitterId == input.LitterId);
            if (litter == null)
            {
                throw new ArgumentException("Не съществува такова котило!");
            }

            if (input.Name == null || input.ProfileImage == null || input.PedigreeImage == null)
            {
                throw new ArgumentException("Има празни полета!");
            }

            var kittenImage = ImageUploader.UploadFile(input.ProfileImage, "kittenImages");
            var pedigreeImage = ImageUploader.UploadFile(input.PedigreeImage, "pedigreeImages");

            var kitten = new Kitten()
            {
                LitterId = litter.LitterId,
                Litter = litter,
                Name = input.Name,
                Gender = (Gender)input.Gender,
                PedigreeImage = pedigreeImage,
                ProfileImage = kittenImage,
            };

            litter.Kittens.Add(kitten);

            await this.db.Kittens.AddAsync(kitten);
            await this.db.SaveChangesAsync();
        }

        public async Task AddLitter(LitterInputModel input)
        {
            if (input.Name == null || input.MotherName == null || input.FatherName == null || input.Colours == null || input.BloodGroup == null)
            {
                throw new ArgumentException("Има празни полета!");
            }

            var litter = new Litter()
            {
                Name = input.Name,
                Birthday = input.Birthday,
                Colours = input.Colours,
                BloodGroup = input.BloodGroup,
                FatherName = input.FatherName,
                MotherName = input.MotherName,
                Kittens = new List<Kitten>(),
            };

            await this.db.Litters.AddAsync(litter);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteCat(string catId)
        {
            var cat = await this.db.Cats.FirstOrDefaultAsync(c => c.CatId == catId);
            if (cat == null)
            {
                throw new ArgumentException("There is no cat with given id!");
            }

            string baseFolderPath = Path.GetFullPath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(), @"..\..\")
                    );
            string clientFolderPath = baseFolderPath + "Web\\BagheerasDream.Web\\wwwroot\\pictures";
            string deleteDir = Path.Combine(clientFolderPath, "cats");
            File.Delete(deleteDir + "\\" + cat.ProfileImage);

            this.db.Cats.Remove(cat);
            await this.db.SaveChangesAsync();
        }

        public async Task RemoveKittenFromLitter(RemoveKittenInputModel input)
        {
            var litter = await this.db.Litters.Include(l => l.Kittens)
                .FirstOrDefaultAsync(l => l.LitterId == input.LitterId);

            var kitten = await this.db.Kittens.FirstOrDefaultAsync(k => k.KittenId == input.KittenId);

            this.DeleteKittenImages(kitten);

            litter.Kittens.Remove(kitten);
            this.db.Kittens.Remove(kitten);
            await this.db.SaveChangesAsync();
        }

        public async Task RemoveLitter(string litterId)
        {
            var litter = await this.db.Litters.Include(l => l.Kittens)
               .FirstOrDefaultAsync(l => l.LitterId == litterId);

            foreach (var kitten in litter.Kittens)
            {
                this.DeleteKittenImages(kitten);
            }

            this.db.Kittens.RemoveRange(litter.Kittens);
            this.db.Litters.Remove(litter);
            await this.db.SaveChangesAsync();
        }

        private void DeleteKittenImages(Kitten kitten)
        {
            string baseFolderPath = Path.GetFullPath(
            Path.Combine(
                Directory.GetCurrentDirectory(), @"..\..\")
			);
            string clientFolderPath = baseFolderPath + "Web\\BagheerasDream.Web\\wwwroot\\pictures";
            string deletePedDir = Path.Combine(clientFolderPath, "pedigreeImages");
            string deleteImgDir = Path.Combine(clientFolderPath, "kittenImages");
            File.Delete(deletePedDir + "\\" + kitten.PedigreeImage);
            File.Delete(deleteImgDir + "\\" + kitten.ProfileImage);
        }
    }
}
