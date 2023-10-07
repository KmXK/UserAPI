using AutoMapper;
using UA.Application.AutoMapper.Converters;
using UA.Application.ViewModels;
using UA.Application.ViewModels.Pagination;
using UA.Data.Core.Pagination;
using UA.Data.Models;
using UA.Domain.Models;

namespace UA.Application.AutoMapper;

public sealed class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<User, UserViewModel>();
        
        CreateMap<CreateUserViewModel, CreateUserModel>();

        CreateMap(typeof(PageFilterViewModel), typeof(PageFilterModel<>))
            .ConvertUsing(typeof(PageFilterModelConverter<>));
    }
}