using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotnetBckofficeApi.Models
{
  [BsonIgnoreExtraElements]//for ignoring extra fields generated from MongoDB like __v
  public class Hotel
  {
    //[BsonId]
    [BsonRepresentation(BsonType.ObjectId, AllowTruncation=true)]
    public string? _id { get; set; }
    public string? name { get; set; }
    public string? type { get; set; }
    public string? city { get; set; }
    public string? address { get; set; }
    public string? distance { get; set; }
    public List<string>? photos { get; set; }
    public string? title { get; set; }
    public string? desc { get; set; }

    [BsonRepresentation(BsonType.Int32, AllowTruncation=true)]
    public int rating { get; set; }
    public List<string>? rooms { get; set; }
    //[BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public decimal? cheapestPrice { get; set; }
    public bool popularHotel { get; set; }
    public int? comments { get; set; }
    public string? comment { get; set; }
  }
}