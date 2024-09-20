namespace BagheerasDream.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BagheerasDream.Data.Models.Enums;
    using BagheerasDream.Web.ViewModels.Cats;
    using BagheerasDream.Web.ViewModels.Litter;

    public interface ICatsService
    {
        public Task<ICollection<CatViewModel>> GetAll(Gender gender);

        public Task<CatViewModel> GetCat(string id);

        public Task<ICollection<LitterViewModel>> GetLitters();
    }
}
