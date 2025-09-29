using AutoMapper;
using JadooTravel.Dtos.BookingDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.BookingServices
{
    public class BookingService : IBookingService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMapper _mapper;

        public BookingService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _bookingCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var value = _mapper.Map<Booking>(createBookingDto);
            await _bookingCollection.InsertOneAsync(value);
        }

        public async Task DeleteBookingAsync(string id)
        {
            await _bookingCollection.DeleteOneAsync(x => x.BookingId == id);
        }

        public async Task<List<ResultBookingDto>> GetAllBookingAsync()
        {
            var values = await _bookingCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(values);
        }

        public async Task<GetBookingByIdDto> GetBookingByIdAsync(string id)
        {
            var value = await _bookingCollection.Find(x => x.BookingId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBookingByIdDto>(value);
        }

        public async Task<List<ResultBookingDto>> GetLast4BookingAsync()
        {
            var values = await _bookingCollection.Find(x => true).SortByDescending(x => x.BookingId).Limit(4).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(values);
        }

        public async Task UpdateBookingAsync(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            await _bookingCollection.FindOneAndReplaceAsync(x => x.BookingId == updateBookingDto.BookingId, value);
        }
    }
}
