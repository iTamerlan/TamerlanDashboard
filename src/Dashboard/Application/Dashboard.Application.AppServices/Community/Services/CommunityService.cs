using Dashboard.Application.AppServices.Contexts.Community.Repositories;
using Dashboard.Contracts.Community;
using Dashboard.Domain.Communitys;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Community.Services;

/// <inheritdoc />
public class CommunityService : ICommunityService
{
    private readonly ICommunityRepository _CommunityRepository;
    //private Task<Domain.Communitys.Community> _CommunityTask;
    //private Domain.Communitys.Community _Community;

    /// <summary>
    /// Инициализирует экзепляр <see cref="CommunityService"/>
    /// </summary>
    /// <param name="CommunityRepository">Репозиторий для работы с сообществами.</param>
    public CommunityService(ICommunityRepository CommunityRepository)
    {
        _CommunityRepository = CommunityRepository;
    }

    /// <inheritdoc />
    public Task<CommunityDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Communitys.Community> _CommunityTask = _CommunityRepository.GetByIdAsync(id, cancellationToken);
        Domain.Communitys.Community _Community = _CommunityTask.Result;

        //Task<CommunityDto> task = new Task<CommunityDto>();
        //Task<CommunityDto> _CommunityDto = task;

        return Task.Run(() => {
            return new CommunityDto()
            {
                Id = _Community.Id,
                Title = _Community.Title,
                Description = _Community.Description,
                DateCreated = _Community.DateCreated,
            };
        });
    }

    /// <inheritdoc />
    public Task<CommunityDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Communitys.Community, bool>> predicat = Community => Community;
        // predicat.Parameters(predicat => { });
        //return _CommunityRepository.GetAll();
        IQueryable<Domain.Communitys.Community> _CommunityQueryable = _CommunityRepository.GetAllAsync(cancellationToken);
        Domain.Communitys.Community[] _Communitys = _CommunityQueryable.ToArray();

        return Task<CommunityDto[]>.Factory.StartNew(() =>
        {
            CommunityDto[] result = (from _Community in _Communitys
                          select new CommunityDto()
                          {
                              Id = _Community.Id,
                              Title = _Community.Title,
                              Description = _Community.Description,
                              DateCreated = _Community.DateCreated,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<CommunityDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Communitys.Community, bool>> predicat = Community => Community;
        // predicat.Parameters(predicat => { });
        //return _CommunityRepository.GetAll();
        IQueryable<Domain.Communitys.Community> _CommunityQueryable = _CommunityRepository.GetAllAsync(cancellationToken);
        Domain.Communitys.Community[] _Communitys = _CommunityQueryable.ToArray();

        return Task<CommunityDto[]>.Factory.StartNew(() =>
        {
            CommunityDto[] result = (from _Community in _Communitys
            //where Community.Id == _Communitys[0].
                                orderby _Community.Title
                                //where Community. == pageIndex

                                select new CommunityDto()
                                {
                                    Id = _Community.Id,
                                    Title = _Community.Title,
                                    Description = _Community.Description,
                                    DateCreated = _Community.DateCreated,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateCommunityDto model, CancellationToken cancellationToken)
    {
        var Community = new Domain.Communitys.Community()
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
            Description = model.Description,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
        };

        return _CommunityRepository.CreateAsync(Community, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Communitys.Community> UpdateAsync(UpdateCommunityDto model, CancellationToken cancellationToken)
    {
        var Community = new Domain.Communitys.Community()
        {
            Id = model.Id,
            Description = model.Description,
            Title = model.Title,
        };

        return _CommunityRepository.UpdateAsync(Community, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Community = new Domain.Communitys.Community()
        {
            Id = id,
        };

        return _CommunityRepository.DeleteAsync(Community, cancellationToken);
    }

    Task<Domain.Communitys.Community> ICommunityService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _CommunityRepository.GetByIdAsync(id, cancellationToken);
    }
}