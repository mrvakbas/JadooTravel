using JadooTravel.Dtos.BookingDtos;
using JadooTravel.Services.BookingServices;
using JadooTravel.Services.GeminiService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly GeminiService _geminiService;

        public DefaultController(IBookingService bookingService, GeminiService geminiService)
        {
            _bookingService = bookingService;
            _geminiService = geminiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBookingAsync(createBookingDto);
            return RedirectToAction("Index", "Default");
        }

        [HttpPost]
        public async Task<IActionResult> GetItinerary([FromBody] string city)
        {
            var output = await _geminiService.GenerateItineraryAsync(city, 5);
            return Content(output, "application/json");
        }

    }

}

