namespace BagheerasDream.Web.Controllers
{
    using BagheerasDream.Data.Models.Enums;
    using BagheerasDream.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CatteryController : Controller
    {
        private readonly ICatsService catsService;

        public CatteryController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        public async Task<IActionResult> Male()
        {
            var viewModel = await this.catsService.GetAll(Gender.Male);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Female()
        {
            var viewModel = await this.catsService.GetAll(Gender.Female);

            return this.View(viewModel);
        }

        public IActionResult Exhibitions()
        {
            return this.View();
        }

        public async Task<IActionResult> Litters()
        {
            var viewModel = await this.catsService.GetLitters();

            return this.View(viewModel);
        }
    }
}
