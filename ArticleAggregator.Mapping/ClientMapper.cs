﻿using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class ClientMapper
{
    public partial ClientDto ClientToClientDto(Client client);
    public partial Client ClientDtoToClient(ClientDto clientDto);
    public partial ClientModel ClientDtoToClientModel(ClientDto clientDto);
    public partial ClientDto ClientModelToClientDto(CategoryModel clientModel);

    public partial ClientDto RegisterModelToClientDto(RegisterModel model);
    public partial ClientDto LoginModelToUserDto(LoginModel model);
}
