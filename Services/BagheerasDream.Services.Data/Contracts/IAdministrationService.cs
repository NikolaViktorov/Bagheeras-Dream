namespace BagheerasDream.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using BagheerasDream.Web.ViewModels.Administration;
    using BagheerasDream.Web.ViewModels.Litter;

    public interface IAdministrationService
    {
        public Task AddCat(CatInputModel cat);

        public Task DeleteCat(string catId);

        public Task AddLitter(LitterInputModel input);

        public Task AddKittenToLitter(KittenInputModel input);

        public Task RemoveKittenFromLitter(RemoveKittenInputModel input);

        public Task RemoveLitter(string litterId);
    }
}
