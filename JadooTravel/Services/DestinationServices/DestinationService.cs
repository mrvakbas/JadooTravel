﻿using AutoMapper;
using JadooTravel.Dtos.BookingDtos;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.DestinationServices
{
    public class DestinationService : IDestinationService
    {
        private readonly IMongoCollection<Destination> _destinationCollection;
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public DestinationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _destinationCollection = database.GetCollection<Destination>(_databaseSettings.DestinationCollectionName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
            _bookingCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDestinationAsync(CreateDestinationDto createDestinationDto)
        {
            var value = _mapper.Map<Destination>(createDestinationDto);
            await _destinationCollection.InsertOneAsync(value);
        }

        public async Task DeleteDestinationAsync(string id)
        {
            await _destinationCollection.DeleteOneAsync(x => x.DestinationId == id);
        }

        public async Task<List<ResultDestinationDto>> GetAllDestinationAsync()
        {
            var values = await _destinationCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDestinationDto>>(values);
        }

        public async Task<GetDestinationByIdDto> GetDestinationByIdAsync(string id)
        {
            var value = await _destinationCollection.Find(x => x.DestinationId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetDestinationByIdDto>(value);
        }

        public async Task<List<ResultDestinationDto>> GetLast4DestinationAsync()
        {
            var values = await _destinationCollection.Find(x => true).SortByDescending(x => x.DestinationId).Limit(4).ToListAsync();
            return _mapper.Map<List<ResultDestinationDto>>(values);
        }

        public async Task UpdateDestinationAsync(UpdateDestinationDto updateDestinationDto)
        {
            var value = _mapper.Map<Destination>(updateDestinationDto);
            await _destinationCollection.FindOneAndReplaceAsync(x => x.DestinationId == updateDestinationDto.DestinationId, value);
        }


        public async Task<GraficDestinationDto> GetGraficDestinationAsync()
        {
            var value = await _destinationCollection.Find(x => true).ToListAsync();
            var value2 = await _testimonialCollection.Find(x => true).ToListAsync();
            var value3 = await _categoryCollection.Find(x => true).ToListAsync();
            var value4 = await _bookingCollection.Find(x => true).ToListAsync();

            var dto = new GraficDestinationDto
            {
                CityCountry = value.Select(d => d.CityCountry).ToList(),
                Capacity = value.Select(d => d.Capacity).ToList(),
                Price = value.Select(d => d.Price).ToList(),
                TesResSerList = new List<int> { value2.Count(), value4.Count(), value3.Count() }
            };


            return dto;
        }



    }
}
