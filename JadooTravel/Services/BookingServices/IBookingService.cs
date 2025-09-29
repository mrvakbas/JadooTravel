﻿using JadooTravel.Dtos.BookingDtos;
using JadooTravel.Dtos.DestinationDtos;

namespace JadooTravel.Services.BookingServices
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllBookingAsync();
        Task CreateBookingAsync(CreateBookingDto createBookingDto);
        Task UpdateBookingAsync(UpdateBookingDto updateBookingDto);
        Task DeleteBookingAsync(string id);
        Task<GetBookingByIdDto> GetBookingByIdAsync(string id);
        Task<List<ResultBookingDto>> GetLast4BookingAsync();

    }
}
