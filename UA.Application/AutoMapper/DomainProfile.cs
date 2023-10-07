using AutoMapper;
using UA.Application.AutoMapper.Converters;
using UA.Application.ViewModels;
using UA.Application.ViewModels.Pagination;
using UA.Data.Core.Pagination;
using UA.Data.Models;
using UA.Domain.Filtering;
using UA.Domain.Models;

namespace UA.Application.AutoMapper;

public sealed class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<User, UserViewModel>();
        CreateMap<Role, RoleViewModel>();
        
        CreateMap<UpdateUserViewModel, UpdateUserModel>();
        CreateMap<PatchUserViewModel, PatchUserModel>();

        CreateMap<UserListFilterViewModel, UserListFilterModel>();
        CreateMap<string, RoleFilterModel>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x));

        CreateMap(typeof(PageModel<>), typeof(PageViewModel<>));
        CreateMap(typeof(PageFilterViewModel), typeof(PageFilterModel<>))
            .ConvertUsing(typeof(PageFilterModelConverter<>));
    }
}