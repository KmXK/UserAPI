using AutoMapper;
using UA.Application.ViewModels;
using UA.Data.Models;

namespace UA.Application.AutoMapper;

public sealed class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<User, UserViewModel>();
    }
}