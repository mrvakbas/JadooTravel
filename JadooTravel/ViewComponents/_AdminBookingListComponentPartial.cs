using JadooTravel.Services.BookingServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents
{
    public class _AdminBookingListComponentPartial : ViewComponent
    {
        private readonly IBookingService _bookingService;

        public _AdminBookingListComponentPartial(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bookingService.GetLast4BookingAsync();
            return View(values);
        }
    }
}
