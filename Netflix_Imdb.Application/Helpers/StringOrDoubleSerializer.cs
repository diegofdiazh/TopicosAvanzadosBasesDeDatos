using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace Netflix_Imdb.Application.Helpers
{
    public class StringOrDoubleSerializer : SerializerBase<string>
    {
        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonType = context.Reader.GetCurrentBsonType();
            switch (bsonType)
            {
                case BsonType.String:
                    return context.Reader.ReadString();
                case BsonType.Double:
                    return context.Reader.ReadDouble().ToString();
                case BsonType.Null:
                    context.Reader.ReadNull();
                    return null;
                default:
                    throw new NotSupportedException($"Cannot convert a {bsonType} to a String.");
            }
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            context.Writer.WriteString(value);
        }
    }
}
