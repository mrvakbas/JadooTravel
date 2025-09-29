using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents
{
    public class _AdminDestinationListComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _AdminDestinationListComponentPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _destinationService.GetLast4DestinationAsync();
            return View(values);
        }
    }
}
