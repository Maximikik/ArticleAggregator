using Azure.AI.OpenAI;

namespace TextValuer;

public class Program
{
    static async Task Main(string[] args)
    {
        var article = Console.ReadLine();

        OpenAIClient client = new OpenAIClient("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");

        var options = new ChatCompletionsOptions
        {
            Messages =
            {
                //new ChatRequestUserMessage("Rate the text on positivity on a scale of 0 to 9: \"Nowadays the most popular song is Rape me by nirvana.\"" +
                //"\nAnswer please like this: \"{number}\"")
                new ChatRequestUserMessage($"Rate the text on positivity on a scale of 0 to 9: \"{article}\"" +
                "\nAnswer please like this: \"{number}\"")
            },
            DeploymentName = "gpt-3.5-turbo"
        };

        var openAiResponse = client.GetChatCompletions(options);

        await Console.Out.WriteLineAsync(openAiResponse.Value.Choices[0].Message.Content);
    }
}

// openai api key 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