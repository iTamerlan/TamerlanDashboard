using Dashboard.Application.AppServices.Contexts.User.Repositories;
using Dashboard.Contracts.User;
using Dashboard.Domain.Users;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.User.Services;

/// <inheritdoc />
public class UserService : IUserService
{
    private readonly IUserRepository _UserRepository;
    //private Task<Domain.Users.User> _UserTask;
    //private Domain.Users.User _User;

    /// <summary>
    /// Инициализирует экзепляр <see cref="UserService"/>
    /// </summary>
    /// <param name="UserRepository">Репозиторий для работы с пользователями.</param>
    public UserService(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;
    }

    /// <inheritdoc />
    public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Users.User> _UserTask = _UserRepository.GetByIdAsync(id, cancellationToken);
        Domain.Users.User _User = _UserTask.Result;

        //Task<UserDto> task = new Task<UserDto>();
        //Task<UserDto> _UserDto = task;

        return Task.Run(() => {
            return new UserDto()
            {
                Id = _User.Id,
                Login = _User.Login,
                Phone = _User.Phone,
            };
        });
    }

    /// <inheritdoc />
    public Task<UserDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Users.User, bool>> predicat = User => User;
        // predicat.Parameters(predicat => { });
        //return _UserRepository.GetAll();
        IQueryable<Domain.Users.User> _UserQueryable = _UserRepository.GetAllAsync(cancellationToken);
        Domain.Users.User[] _Users = _UserQueryable.ToArray();

        return Task<UserDto[]>.Factory.StartNew(() =>
        {
            UserDto[] result = (from User in _Users
                          select new UserDto()
                          {
                              Id = User.Id,
                              Login = User.Login,
                              Phone = User.Phone,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<UserDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Users.User, bool>> predicat = User => User;
        // predicat.Parameters(predicat => { });
        //return _UserRepository.GetAll();
        IQueryable<Domain.Users.User> _UserQueryable = _UserRepository.GetAllAsync(cancellationToken);
        Domain.Users.User[] _Users = _UserQueryable.ToArray();

        return Task<UserDto[]>.Factory.StartNew(() =>
        {
            UserDto[] result = (from User in _Users
            //where User.Id == _Users[0].
                                orderby User.Login
                                //where User. == pageIndex

                                select new UserDto()
                                {
                                    Id = User.Id, //Guid.NewGuid(),
                                    Login = User.Login,
                                    Phone = User.Phone,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateUserDto model, CancellationToken cancellationToken)
    {
        var User = new Domain.Users.User()
        {
            Id = Guid.NewGuid(),
            Login = model.Login,
            Password = model.Password,
            EmailReg = model.EmailReg,
            Phone = model.Phone,
        };

        return _UserRepository.CreateAsync(User, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Users.User> UpdateAsync(UpdateUserDto model, CancellationToken cancellationToken)
    {
        var User = new Domain.Users.User()
        {
            Id = model.Id,
            Login = model.Login,
            EmailReg = model.EmailReg,
            Phone = model.Phone,
        };

        return _UserRepository.UpdateAsync(User, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var User = new Domain.Users.User()
        {
            Id = id,
        };

        return _UserRepository.DeleteAsync(User, cancellationToken);
    }

    Task<Domain.Users.User> IUserService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _UserRepository.GetByIdAsync(id, cancellationToken);
    }
}