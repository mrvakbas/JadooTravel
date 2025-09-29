using JadooTravel.Dtos.BookingDtos;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Services.BookingServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> BookingList()
        {
            var values = await _bookingService.GetAllBookingAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBookingAsync(createBookingDto);
            return RedirectToAction("BookingList");
        }

        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return RedirectToAction("BookingList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBooking(string id)
        {
            var value = await _bookingService.GetBookingByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            await _bookingService.UpdateBookingAsync(updateBookingDto);
            return RedirectToAction("BookingList");
        }

    }
}
