using NRedisStack;
using NRedisStack.RedisStackCommands;
using NRedisStack.Search;
using NRedisStack.Search.Literals.Enums;
using StackExchange.Redis;
using static NRedisStack.Search.Schema;

namespace SemanticSearchApp
{
    internal class IndexCreator
    {
        public static void CreateIndex()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase db = redis.GetDatabase();
            var schema = new Schema()
            .AddTextField("content")
            .AddVectorField("embedding", VectorField.VectorAlgo.HNSW, new Dictionary<string, object>() {
                { "TYPE", "FLOAT32" },
                { "DIM", "1024" },// Adjust dimension based on your embedding model
                { "DISTANCE_METRIC", "COSINE" }
            });
            SearchCommands ft = db.FT();
            ft.Create("doc_idx", new FTCreateParams().On(IndexDataType.HASH).Prefix("doc:"), schema);

        }
    }
}
