using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SemanticSearchApp
{
    public record Payload(string model,string prompt);
    public class Response
    {
        public float[] embedding { get; set; }
    }
    internal class EmbeddingGenerator
    {
        public async static Task<byte[]?> GetEmbeddingAsync(string text)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:11434/");
            var payload = JsonSerializer.Serialize(new Payload("mxbai-embed-large", text));
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync("api/embeddings", content);
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response>();
                    if(result!=null)
                    return new ArraySegment<float>(result.embedding).ToArray()
                            .SelectMany(BitConverter.GetBytes)
                            .ToArray();
                }
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
