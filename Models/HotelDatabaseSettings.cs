namespace DotnetBckofficeApi.Models
{
    public class HotelDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string HotelCollectionName { get; set; } = null!;
    }
}