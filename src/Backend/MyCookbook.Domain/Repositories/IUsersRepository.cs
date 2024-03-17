using MyCookbook.Domain.Entities;

namespace MyCookbook.Domain.Repositories;

public interface IUsersRepository
{
    Task Create(UserEntity user);

    Task<bool> CheckEmailExists(string user);

}
