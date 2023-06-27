using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DotnetBckofficeApi.Services
{
    public class HotelService
    {
        private readonly IMongoCollection<Hotel> _hotelCollection;

    public HotelService(
        IOptions<HotelDatabaseSettings> HotelDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            HotelDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            HotelDatabaseSettings.Value.DatabaseName);

        _hotelCollection = mongoDatabase.GetCollection<Hotel>(
            HotelDatabaseSettings.Value.HotelCollectionName);
    }

    public async Task<List<Hotel>> GetAsync() =>
        await _hotelCollection.Find(_ => true).ToListAsync();

    public async Task<Hotel?> GetAsync(string id) =>
        await _hotelCollection.Find(x => x._id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Hotel hotel) =>
        await _hotelCollection.InsertOneAsync(hotel);

    public async Task UpdateAsync(string id, Hotel updatedBook) =>
        await _hotelCollection.ReplaceOneAsync(x => x._id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _hotelCollection.DeleteOneAsync(x => x._id == id);
    }
}