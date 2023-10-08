﻿using UA.Data.Core.Configuration;
using UA.Data.Core.Interfaces;
using UA.Data.Core.Pagination;
using UA.Data.Enums;
using UA.Data.Models;
using UA.Domain.Filtering;
using UA.Domain.Models;
using UA.Domain.Services.Base;
using UA.Domain.Services.Interfaces;
using UA.Domain.Specifications;
using UA.Infrastructure.Services.Interfaces;

namespace UA.Domain.Services;

public sealed class UserService : BaseService<Guid, User>, IUserService
{
    private readonly ICryptoService _cryptoService;
    private readonly IRoleService _roleService;

    public UserService(
        IUnitOfWork unitOfWork,
        ICryptoService cryptoService,
        IRoleService roleService) : base(unitOfWork)
    {
        _cryptoService = cryptoService;
        _roleService = roleService;
    }
    
    public async Task<User> Create(UpdateUserModel model)
    {
        var user = new User
        {
            Age = model.Age,
            Email = model.Email,
            Name = model.Name,
            PasswordHash = _cryptoService.HashText(model.Email)
        };

        await UpdateRoles(user, model.Roles.ToList());

        await WorkRepository.AddAsync(user);

        await UnitOfWork.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DoesUserWithEmailExist(string email, Guid? id = null)
    {
        var spec = UserSpecifications.ForEmail(email);

        if (id.HasValue)
        {
            spec &= !UserSpecifications.ForId(id.Value);
        }
        
        return await WorkRepository.Exists(spec);
    }

    public async Task<PageModel<User>> GetListAsync(
        PageFilterModel<User> pageFilterModel,
        UserListFilterModel filterModel)
    {
        var configuration = ConfigurationBuilder.Build<User>(x => x.Roles);
        
        return await WorkRepository.GetPagedListBySpecAsync(
            pageFilterModel,
            UserSpecifications.ForFilter(filterModel),
            configuration);
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        var configuration = ConfigurationBuilder.Build<User>(x => x.Roles); 
        return await WorkRepository.GetByIdAsync(id, configuration);
    }

    public async Task<User> UpdateAsync(Guid id, UpdateUserModel model)
    {
        var configuration = ConfigurationBuilder.Build<User>(x => x.Roles); 
        var user = await WorkRepository.GetByIdAsync(id, configuration);
        
        if (user == null)
        {
            return await Create(model);
        }
        
        user.Age = model.Age;
        user.Email = model.Email;
        user.Name = model.Name;
        await UpdateRoles(user, model.Roles.ToList());

        await UnitOfWork.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateAsync(Guid id, PatchUserModel model)
    {
        var configuration = ConfigurationBuilder.Build<User>(x => x.Roles); 
        var user = await WorkRepository.GetByIdAsync(id, configuration);

        if (user == null)
        {
            return null;
        }

        if (model.Age.HasValue)
        {
            user.Age = model.Age.Value;
        }
        
        if (model.Name != null)
        {
            user.Name = model.Name;
        }

        if (model.Email != null)
        {
            user.Email = model.Email;
        }

        if (model.Roles != null)
        {
            await UpdateRoles(user, model.Roles.ToList());
        }
        
        await UnitOfWork.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await WorkRepository.DeleteBySpecAsync(UserSpecifications.ForId(id)) > 0;
    }

    public async Task<User> ValidateUserAsync(string email, string password)
    {
        var configuration = ConfigurationBuilder.Build<User>(u => u.Roles);
        
        var passwordHash = _cryptoService.HashText(password);

        var user = await WorkRepository.GetBySpecAsync(
            UserSpecifications.ForUserIdentity(email, passwordHash),
            configuration);

        return user;
    }

    private async Task UpdateRoles(User user, ICollection<RoleEnum> newRoleIds)
    {
        if (newRoleIds.All(roleId => user.Roles.Any(x => x.Id == roleId)))
        {
            user.Roles = user.Roles.Where(role => newRoleIds.Contains(role.Id)).ToList();
        }
        else
        {
            var roles = (await _roleService.GetRolesAsync()).ToDictionary(x => x.Id, x => x);

            user.Roles = newRoleIds.Select(x => roles[x]).ToList();
        }
    }
}