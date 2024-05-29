using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Netflix_Imdb.Application.Helpers;

namespace Netflix_Imdb.Application.Entity
{
    public class MovieTitle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("netflix_data")]
        public NetflixData NetflixData { get; set; }

        [BsonElement("imdb_data")]
        public ImdbData ImdbData { get; set; }
    }

    public class NetflixData
    {
        [BsonElement("show_id")]
        public string ShowId { get; set; }

        [BsonElement("director")]
        [BsonSerializer(typeof(StringOrDoubleSerializer))]
        public string Director { get; set; }

        [BsonElement("cast")]
        [BsonSerializer(typeof(StringOrDoubleSerializer))]
        public string Cast { get; set; }

        [BsonElement("country")]
        [BsonSerializer(typeof(StringOrDoubleSerializer))]
        public string Country { get; set; }

        [BsonElement("date_added")]
        public string DateAdded { get; set; }

        [BsonElement("release_year")]
        public int ReleaseYear { get; set; }

        [BsonElement("rating")]
        public string Rating { get; set; }

        [BsonElement("duration")]
        public string Duration { get; set; }

        [BsonElement("listed_in")]
        public string ListedIn { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }

    public class ImdbData
    {
        [BsonElement("date_x")]
        public string DateX { get; set; }

        [BsonElement("score")]
        public double Score { get; set; }

        [BsonElement("genre")]
        [BsonSerializer(typeof(StringOrDoubleSerializer))]
        public string Genre { get; set; }

        [BsonElement("overview")]
        public string Overview { get; set; }

        [BsonElement("crew")]
        [BsonSerializer(typeof(StringOrDoubleSerializer))]
        public string Crew { get; set; }

        [BsonElement("orig_title")]
        public string OrigTitle { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("orig_lang")]
        public string OrigLang { get; set; }

        [BsonElement("budget_x")]
        public double BudgetX { get; set; }

        [BsonElement("revenue")]
        public double Revenue { get; set; }

        [BsonElement("country")]
        [BsonSerializer(typeof(StringOrDoubleSerializer))]
        public string Country { get; set; }
    }
}
