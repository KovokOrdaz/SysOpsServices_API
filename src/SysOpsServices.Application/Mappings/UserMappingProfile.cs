using AutoMapper;
using SysOpsServices.Application.DTOs;
using SysOpsServices.Domain.Entities;

namespace SysOpsServices.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}
