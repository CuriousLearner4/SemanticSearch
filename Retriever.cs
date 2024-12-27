using NRedisStack.RedisStackCommands;
using NRedisStack.Search;
using StackExchange.Redis;

namespace SemanticSearchApp
{
    internal class Retriever
    {
        public static async Task<List<string>> SemanticSearch(string queryText)
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            var db = redis.GetDatabase();
            var queryEmbedding = await EmbeddingGenerator.GetEmbeddingAsync(queryText);
            var searchQuery = new Query($"*=>[KNN 3 @embedding $vector AS score]").ReturnFields("content","score").SetSortBy("score",true).Dialect(2);
            //var searchQuery = new Query($"*=>[KNN 3 @embedding $vector AS score]").ReturnFields("content","score").SetSortBy("score",true).Dialect(2);
            searchQuery.AddParam("vector",queryEmbedding);
            var results = db.FT().Search("doc_idx",searchQuery);
            return results.Documents.Select(d => d["content"].ToString()).ToList();
        }

    }
}
