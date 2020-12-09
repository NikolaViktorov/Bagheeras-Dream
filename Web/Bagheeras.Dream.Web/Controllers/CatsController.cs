namespace Bagheeras.Dream.Web.Controllers
{
    using System.Threading.Tasks;

    using Bagheeras.Dream.Services.Data.Contracts;
    using Bagheeras.Dream.Web.ViewModels.Cats;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : BaseController
    {
        private readonly ICatsService catsService;

        public CatsController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        public async Task<IActionResult> Cat(string catId)
        {
            var viewModel = await this.catsService.GetCat(catId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Home()
        {
            var viewModel = await this.catsService.GetAll();
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddCat()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCat(CatInputModel input)
        {
            await this.catsService.AddCat(input);
            return this.Redirect("/");
        }
    }
}
