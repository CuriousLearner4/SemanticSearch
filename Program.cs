using StackExchange.Redis;

namespace SemanticSearchApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ClearRedisDatabase();
            //IndexCreator.CreateIndex();
            //string document = "In a quiet town by the sea, there was a hidden forest. The trees were ancient, their trunks thick and gnarled. Few ventured inside, for stories spoke of mysterious things lurking in the shadows. Yet, there was one curious soul who dared to explore. His name was Jack, a young man with an adventurous heart. He had always wondered what secrets the forest held.\nOne evening, he packed a bag with supplies. He knew the journey would be long, but his excitement kept him going. As the sun began to set, he walked into the forest. The air grew cooler with each step, and the trees seemed to close in around him. Jack felt both nervous and thrilled at the same time.\nThe deeper he went, the quieter it became. Birds, once chirping, were now silent. It was as if the forest was holding its breath. Jack walked carefully, listening to the sound of his own footsteps. Soon, he came upon a clearing, and in the center was an ancient stone well.\nCuriosity took over, and he approached the well. The stones were covered in moss, and a faint glow emanated from within. Jack leaned closer, peering into the darkness. Suddenly, a voice echoed from deep within. \"What do you seek?\" it asked.\nStartled, Jack stepped back, his heart racing. He hadn’t expected this. “I… I seek the truth,” he said, unsure of what else to say. The voice seemed to chuckle softly. “Truth comes with a price,” it warned. Jack hesitated but nodded. He was ready.\nThe glow from the well grew brighter, and before he knew it, a figure emerged. It was a woman, draped in robes of silver. Her eyes glowed like stars, and her presence was both comforting and intimidating. \"I am the keeper of the forest,\" she said.\nJack, still in awe, asked, \"What lies within the forest?\" The keeper smiled gently. “The forest holds the memories of the earth. It remembers everything.” Jack’s mind raced. What did this mean? \"Can you show me?\" he asked eagerly.\nThe keeper nodded. She raised her hand, and the forest began to change. The trees shifted, and visions of ancient times appeared. Jack saw great battles, long-lost civilizations, and the rise and fall of kings. He felt as though he was witnessing history itself.\nAs the visions faded, Jack turned to the keeper. \"Why show me this?\" he asked. The keeper’s eyes softened. \"Because you are ready to understand,\" she replied. \"The forest chooses who it reveals its secrets to.\"\nJack felt a sense of calm wash over him. He had always felt different from others. Now, he understood why. He was part of something bigger, something eternal. \"What happens now?\" he asked.\nThe keeper smiled and gestured for him to follow. She led him deeper into the forest, where a large tree stood, its roots tangled in the earth. “This tree is the heart of the forest,” she explained. \"It connects everything.\"\nJack stood in awe, feeling the pulse of the tree beneath his feet. It was as if the forest itself was alive, breathing with him. The keeper spoke again. \"You must decide now. Will you protect the forest, or will you leave it to its fate?\"\nJack thought for a moment. He had always felt a deep connection to nature. This was his calling. \"I will protect it,\" he said firmly. The keeper smiled. \"Then you are the forest's guardian now.\"\nAnd with that, Jack’s life changed forever. He became one with the forest, his soul intertwined with its ancient power. The town by the sea never knew what had happened to the curious adventurer. But the forest knew, and it whispered his name with reverence.";
            //List<string> inputs = document.Split('\n').ToList();
            //int i = 1;
            //foreach (var input in inputs)
            //{
            //    await DocumentStorage.StoreDocument(Convert.ToString(i), input);
            //    i++;
            //}
            while (true)
            {
                var prompt = Console.ReadLine();
                var results = Retriever.SemanticSearch(prompt).Result;
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }

        }

        public static void ClearRedisDatabase()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase db = redis.GetDatabase();
            db.Execute("FLUSHDB");
        }
    }
}
