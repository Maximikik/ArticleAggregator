namespace ArticleAggregator.Data.CustomExceptions;

public class IncorrectResponseFromChatGpt : Exception
{
    public IncorrectResponseFromChatGpt(string response, string type)
    : base($"AI response \"{response}\" is not type of {type}.") { }

    public IncorrectResponseFromChatGpt(string response)
    : base($"AI response \"{response}\" is incorrect.") { }

    public IncorrectResponseFromChatGpt()
        : base() { }
}
