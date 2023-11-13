using Dashboard.Application.AppServices.Contexts.History.Repositories;
using Dashboard.Contracts.History;
using Dashboard.Domain.Historys;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.History.Services;

/// <inheritdoc />
public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _HistoryRepository;
    //private Task<Domain.Historys.History> _HistoryTask;
    //private Domain.Historys.History _History;

    /// <summary>
    /// Инициализирует экзепляр <see cref="HistoryService"/>
    /// </summary>
    /// <param name="HistoryRepository">Репозиторий для работы с историей просмотра.</param>
    public HistoryService(IHistoryRepository HistoryRepository)
    {
        _HistoryRepository = HistoryRepository;
    }

    /// <inheritdoc />
    public Task<HistoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Historys.History> _HistoryTask = _HistoryRepository.GetByIdAsync(id, cancellationToken);
        Domain.Historys.History _History = _HistoryTask.Result;

        //Task<HistoryDto> task = new Task<HistoryDto>();
        //Task<HistoryDto> _HistoryDto = task;

        return Task.Run(() => {
            return new HistoryDto()
            {
                Id = _History.Id,
                AuthorId = _History.AuthorId,
                ParrentId = _History.ParrentId,
                DateCreated = _History.DateCreated,
            };
        });
    }

    /// <inheritdoc />
    public Task<HistoryDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Historys.History, bool>> predicat = History => History;
        // predicat.Parameters(predicat => { });
        //return _HistoryRepository.GetAll();
        IQueryable<Domain.Historys.History> _HistoryQueryable = _HistoryRepository.GetAllAsync(cancellationToken);
        Domain.Historys.History[] _Historys = _HistoryQueryable.ToArray();

        return Task<HistoryDto[]>.Factory.StartNew(() =>
        {
            HistoryDto[] result = (from _History in _Historys
                          select new HistoryDto()
                          {
                              Id = _History.Id,
                              AuthorId = _History.AuthorId,
                              ParrentId = _History.ParrentId,
                              DateCreated = _History.DateCreated,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<HistoryDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Historys.History, bool>> predicat = History => History;
        // predicat.Parameters(predicat => { });
        //return _HistoryRepository.GetAll();
        IQueryable<Domain.Historys.History> _HistoryQueryable = _HistoryRepository.GetAllAsync(cancellationToken);
        Domain.Historys.History[] _Historys = _HistoryQueryable.ToArray();

        return Task<HistoryDto[]>.Factory.StartNew(() =>
        {
            HistoryDto[] result = (from _History in _Historys
            //where History.Id == _Historys[0].
                                orderby _History.DateCreated
                                //where History. == pageIndex

                                select new HistoryDto()
                                {
                                    Id = _History.Id,
                                    AuthorId = _History.AuthorId,
                                    ParrentId = _History.ParrentId,
                                    DateCreated = _History.DateCreated,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateHistoryDto model, CancellationToken cancellationToken)
    {
        var History = new Domain.Historys.History()
        {
            Id = Guid.NewGuid(),
            AuthorId = model.AuthorId,
            ParrentId = model.ParrentId,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
        };

        return _HistoryRepository.CreateAsync(History, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Historys.History> UpdateAsync(UpdateHistoryDto model, CancellationToken cancellationToken)
    {
        var History = new Domain.Historys.History()
        {
            Id = model.Id,
        };

        return _HistoryRepository.UpdateAsync(History, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var History = new Domain.Historys.History()
        {
            Id = id,
        };

        return _HistoryRepository.DeleteAsync(History, cancellationToken);
    }

    Task<Domain.Historys.History> IHistoryService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _HistoryRepository.GetByIdAsync(id, cancellationToken);
    }
}