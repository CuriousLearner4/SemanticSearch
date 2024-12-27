using StackExchange.Redis;

namespace SemanticSearchApp
{
    internal class DocumentStorage
    {
        public async static Task StoreDocument(string documentId, string content)
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            var db = redis.GetDatabase();
            byte[]? embedding = null;
            while (embedding == null)
                embedding = await EmbeddingGenerator.GetEmbeddingAsync(content);
            db.HashSet($"doc:{documentId}", new HashEntry[]
            {
                new HashEntry("content",content),
                new HashEntry("embedding",embedding)
            });
        }
    }
}
