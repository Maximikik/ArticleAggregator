using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class Mapper : IMapper
{
    public partial TTarget Map<TSource, TTarget>(TSource source);

    private partial ArticleDto EntityToDto(Article article);
    private partial Article DtoToEntity(ArticleDto article);
    private partial ArticleModel DtoToModel(ArticleDto article);
    private partial ArticleDto ModelToDto(ArticleModel article);
    private partial ArticleModel EntityToModel(Article article);

    private partial CategoryDto EntityToDto(Category category);
    private partial Category DtoToEntity(CategoryDto categoryDto);
    private partial CategoryModel DtoToModel(CategoryDto categoryDto);
    private partial CategoryDto ModelToDto(CategoryModel categoryModel);

    private partial ClientDto EntityToDto(Client client);
    private partial Client DtoToEntity(ClientDto clientDto);
    private partial ClientModel ClientDtoToClientModel(ClientDto clientDto);
    private partial ClientDto ClientModelToClientDto(CategoryModel clientModel);

    private partial ClientDto RegisterModelToClientDto(RegisterModel model);
    private partial ClientDto LoginModelToUserDto(LoginModel model);

    private partial CommentDto CommentToCommentDto(Comment comment);
    private partial Comment CommentDtoToComment(CommentDto commentDto);
    private partial CommentModel CommentDtoToCommentModel(CommentDto commentDto);
    private partial CommentDto CommentModelToCommentDto(CommentModel commentModel);

    private partial FeedDto EntityToDto(Feed source);
    private partial Feed DtoToEntity(FeedDto source);

    private partial RoleDto RoleToRoleDto(Role role);
    private partial Role RoleDtoToRole(RoleDto roleDto);
    private partial RoleModel RoleDtoToRoleModel(RoleDto roleDto);
    private partial RoleDto RoleModelToRoleDto(RoleModel roleModel);

    private partial SourceDto EntityToDto(Source source);
    private partial Source DtoToEntity(SourceDto sourceDto);
    private partial SourceModel DtoToModel(SourceDto sourceDto);
    private partial SourceDto ModelToDto(SourceModel sourceModel);
}