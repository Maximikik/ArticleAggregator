namespace ArticleAggregator.Models;

public class TokenResponseModel
{
    public string AccessToken { get; set; }
    public Guid RefreshToken { get; set; }
}