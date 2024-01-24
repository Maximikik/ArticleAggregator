namespace ArticleAggregator.Models;

public class RegisterModel
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordConfirmation { get; set; } = null!;
}