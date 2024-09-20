namespace BagheerasDream.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BagheerasDream.Common;
    using BagheerasDream.Services.Data.Contracts;
    using BagheerasDream.Web.Controllers;
    using BagheerasDream.Web.ViewModels.Administration;
    using BagheerasDream.Web.ViewModels.Litter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        private readonly IAdministrationService administrationService;

        public AdministrationController(IAdministrationService administrationService)
        {
            this.administrationService = administrationService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        public async Task<IActionResult> AddCat()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCat(CatInputModel input)
        {
            try
            {
                await this.administrationService.AddCat(input);
            }
            catch (System.Exception e)
            {
                this.ModelState.AddModelError("cat", e.Message);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View("AddCat", input);
            }

            return this.Redirect("/Cattery/" + input.Gender.ToString());
        }

        public async Task<IActionResult> RemoveCat(string catId)
        {
            await this.administrationService.DeleteCat(catId);

            return this.Redirect("/Home/Cattery");
        }

        public async Task<IActionResult> AddLitter()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLitter(LitterInputModel input)
        {
            try
            {
                await this.administrationService.AddLitter(input);
            }
            catch (System.Exception e)
            {
                this.ModelState.AddModelError("litter", e.Message);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View("AddLitter", input);
            }

            return this.Redirect("/Cattery/Litters");
        }

        public async Task<IActionResult> RemoveLitter(string litterId)
        {
            await this.administrationService.RemoveLitter(litterId);

            return this.Redirect("/Cattery/Litters");
        }

        public async Task<IActionResult> AddKittenToLitter(string litterId)
        {
            this.ViewBag.litterId = litterId;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddKittenToLitter(KittenInputModel input)
        {
            try
            {
                await this.administrationService.AddKittenToLitter(input);
            }
            catch (System.Exception e)
            {
                this.ModelState.AddModelError("kitten", e.Message);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View("AddKittenToLitter", input);
            }

            return this.Redirect("/Cattery/Litters");
        }

        public async Task<IActionResult> RemoveKitten(string kittenId, string litterId)
        {
            await this.administrationService.RemoveKittenFromLitter(new RemoveKittenInputModel()
            {
                KittenId = kittenId,
                LitterId = litterId,
            });

            return this.Redirect("/Cattery/Litters");
        }
    }
}
