using FluentValidation;

namespace ArticleAggregator.Data.CQS.Sources.Commands.CreateSource;

public class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
{
    public CreateSourceCommandValidator()
    {
        RuleFor(item => item.SourceDto).NotNull();
        RuleFor(item => item.SourceDto.RssUrl).NotNull();
        RuleFor(item => item.SourceDto.Url).NotNull();
        RuleFor(item => item.SourceDto.ArticlesId).NotNull();
        RuleFor(item => item.SourceDto.Name).NotNull();
        RuleFor(item => item.SourceDto.Id).NotEmpty();
    }
}
