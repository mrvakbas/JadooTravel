using JadooTravel.Services.TripPlanServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents
{
    public class _DefaultBookingDetailComponentPartial : ViewComponent
    {
        private readonly ITripPlanService _tripPlanService;

        public _DefaultBookingDetailComponentPartial(ITripPlanService tripPlanService)
        {
            _tripPlanService = tripPlanService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _tripPlanService.GetAllTripPlanAsync();
            return View(values);
        }
    }
}
