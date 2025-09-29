using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookingId { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MessageBody { get; set; }
    }
}
