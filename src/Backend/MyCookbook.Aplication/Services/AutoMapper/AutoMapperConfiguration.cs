using AutoMapper;
using MyCookbook.Communication.Request;
using MyCookbook.Domain.Entities;

namespace MyCookbook.Aplication.Services.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<RequestRegisterUser, UserEntity>()
            .ForMember(destiny=> destiny.Password, config => config.Ignore());
    }
}
