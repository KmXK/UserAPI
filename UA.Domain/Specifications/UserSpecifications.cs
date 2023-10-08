using LinqSpecs;
using UA.Data.Models;
using UA.Domain.Filtering;

namespace UA.Domain.Specifications;

public static class UserSpecifications
{
    public static Specification<User> ForId(Guid id)
    {
        return new AdHocSpecification<User>(u => u.Id == id);
    }

    public static Specification<User> ForEmail(string email)
    {
        return new AdHocSpecification<User>(u => u.Email == email);
    }

    public static Specification<User> ForFilter(UserListFilterModel filterModel)
    {
        Specification<User> spec = new TrueSpecification<User>();

        if (filterModel.Email != null)
        {
            spec &= new AdHocSpecification<User>(u => u.Email.Contains(filterModel.Email));
        }

        if (filterModel.Age.HasValue)
        {
            spec &= new AdHocSpecification<User>(u => u.Age == filterModel.Age);
        }

        if (filterModel.Name != null)
        {
            spec &= new AdHocSpecification<User>(u => u.Name.Contains(filterModel.Name));
        }

        if (filterModel.Roles?.Any() == true)
        {
            spec &= new AdHocSpecification<User>(u => u.Roles.Any(r => filterModel.Roles.Contains(r.Name)));
        }

        return spec;
    }

    public static Specification<User> ForUserIdentity(string email, string passwordHash)
    {
        return new AdHocSpecification<User>(u =>
            u.Email == email
            && u.PasswordHash == passwordHash);
    }
}