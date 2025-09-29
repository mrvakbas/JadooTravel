using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents
{
    public class _AdminDashboardComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _AdminDashboardComponentPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _destinationService.GetGraficDestinationAsync();
            return View(values);
        }
    }
}
