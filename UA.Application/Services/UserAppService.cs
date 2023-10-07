﻿using AutoMapper;
using UA.Application.Services.Interfaces;
using UA.Application.Validators.Interfaces;
using UA.Application.ViewModels;
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
    
    public async Task<UserViewModel> Create(CreateUserViewModel viewModel)
    {
        await _validator.Validate(viewModel);
        
        var model = _mapper.Map<CreateUserModel>(viewModel);

        var user = await _userService.Create(model);
        
        var userViewModel = _mapper.Map<UserViewModel>(user);

        return userViewModel;
    }
}