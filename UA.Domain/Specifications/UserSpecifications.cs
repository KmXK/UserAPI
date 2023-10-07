using LinqSpecs;
using UA.Data.Models;

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

    public static Specification<User> ForAll()
    {
        return new TrueSpecification<User>();
    }
}