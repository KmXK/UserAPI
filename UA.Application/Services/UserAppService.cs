using System.Text.Json;
using AutoMapper;
using UA.Application.Services.Interfaces;
using UA.Application.Validators.Interfaces;
using UA.Application.ViewModels;
using UA.Application.ViewModels.Pagination;
using UA.Data.Core.Pagination;
using UA.Data.Models;
using UA.Domain.Filtering;
using UA.Domain.Models;
using UA.Domain.Services.Interfaces;

namespace UA.Application.Services;

internal sealed class UserAppService : IUserAppService
{
    private readonly IUserService _userService;
    private readonly IValidator _validator;
    private readonly IMapper _mapper;

    public UserAppService(
        IUserService userService,
        IValidator validator,
        IMapper mapper)
    {
        _userService = userService;
        _validator = validator;
        _mapper = mapper;
    }
    
    public async Task<UserViewModel> Create(UpdateUserViewModel viewModel)
    {
        await _validator.Validate(viewModel);
        
        var model = _mapper.Map<UpdateUserModel>(viewModel);

        var user = await _userService.Create(model);

        return _mapper.Map<UserViewModel>(user);;
    }

    public async Task<PageViewModel<UserViewModel>> GetListAsync(
        PageFilterViewModel pageFilterViewModel,
        UserListFilterViewModel filterViewModel)
    {
        var filterModel = _mapper.Map<UserListFilterModel>(filterViewModel);
        
        await _validator.Validate(pageFilterViewModel);
        
        var pageFilterModel = _mapper.Map<PageFilterModel<User>>(pageFilterViewModel);

        var pageModel = await _userService.GetListAsync(pageFilterModel, filterModel);
        
        return _mapper.Map<PageViewModel<UserViewModel>>(pageModel);
    }

    public async Task<UserViewModel> GetUserByIdAsync(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<UserViewModel> UpdateAsync(Guid id, UpdateUserViewModel viewModel)
    {
        viewModel.Id = id;
        
        await _validator.Validate(viewModel);
        
        var model = _mapper.Map<UpdateUserModel>(viewModel);
        
        var user = await _userService.UpdateAsync(id, model);
        
        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<UserViewModel> UpdateAsync(Guid id, PatchUserViewModel viewModel)
    {
        viewModel.Id = id;
        
        await _validator.Validate(viewModel);
        
        var model = _mapper.Map<PatchUserModel>(viewModel);

        var user = await _userService.UpdateAsync(id, model);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _userService.DeleteAsync(id);
    }
}