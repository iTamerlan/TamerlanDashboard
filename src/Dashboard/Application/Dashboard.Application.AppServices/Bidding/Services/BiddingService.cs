using Dashboard.Application.AppServices.Contexts.Bidding.Repositories;
using Dashboard.Contracts.Bidding;
using Dashboard.Domain.Biddings;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Bidding.Services;

/// <inheritdoc />
public class BiddingService : IBiddingService
{
    private readonly IBiddingRepository _BiddingRepository;
    //private Task<Domain.Biddings.Bidding> _BiddingTask;
    //private Domain.Biddings.Bidding _Bidding;

    /// <summary>
    /// Инициализирует экзепляр <see cref="BiddingService"/>
    /// </summary>
    /// <param name="BiddingRepository">Репозиторий для работы с аукционом.</param>
    public BiddingService(IBiddingRepository BiddingRepository)
    {
        _BiddingRepository = BiddingRepository;
    }

    /// <inheritdoc />
    public Task<BiddingDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Biddings.Bidding> _BiddingTask = _BiddingRepository.GetByIdAsync(id, cancellationToken);
        Domain.Biddings.Bidding _Bidding = _BiddingTask.Result;

        //Task<BiddingDto> task = new Task<BiddingDto>();
        //Task<BiddingDto> _BiddingDto = task;

        return Task.Run(() => {
            return new BiddingDto()
            {
                Id = _Bidding.Id,
                AuthorId = _Bidding.AuthorId,
                PostId = _Bidding.PostId,
                Price = _Bidding.Price,
                DateCreated = _Bidding.DateCreated,
                TextComment = _Bidding.TextComment,
            };
        });
    }

    /// <inheritdoc />
    public Task<BiddingDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Biddings.Bidding, bool>> predicat = Bidding => Bidding;
        // predicat.Parameters(predicat => { });
        //return _BiddingRepository.GetAll();
        IQueryable<Domain.Biddings.Bidding> _BiddingQueryable = _BiddingRepository.GetAllAsync(cancellationToken);
        Domain.Biddings.Bidding[] _Biddings = _BiddingQueryable.ToArray();

        return Task<BiddingDto[]>.Factory.StartNew(() =>
        {
            BiddingDto[] result = (from _Bidding in _Biddings
                          select new BiddingDto()
                          {
                              Id = _Bidding.Id,
                              AuthorId = _Bidding.AuthorId,
                              PostId = _Bidding.PostId,
                              Price = _Bidding.Price,
                              DateCreated = _Bidding.DateCreated,
                              TextComment = _Bidding.TextComment,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<BiddingDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Biddings.Bidding, bool>> predicat = Bidding => Bidding;
        // predicat.Parameters(predicat => { });
        //return _BiddingRepository.GetAll();
        IQueryable<Domain.Biddings.Bidding> _BiddingQueryable = _BiddingRepository.GetAllAsync(cancellationToken);
        Domain.Biddings.Bidding[] _Biddings = _BiddingQueryable.ToArray();

        return Task<BiddingDto[]>.Factory.StartNew(() =>
        {
            BiddingDto[] result = (from _Bidding in _Biddings
            //where Bidding.Id == _Biddings[0].
                                orderby _Bidding.DateCreated
                                //where Bidding. == pageIndex

                                select new BiddingDto()
                                {
                                    Id = _Bidding.Id,
                                    AuthorId = _Bidding.AuthorId,
                                    PostId = _Bidding.PostId,
                                    Price = _Bidding.Price,
                                    DateCreated = _Bidding.DateCreated,
                                    TextComment = _Bidding.TextComment,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateBiddingDto model, CancellationToken cancellationToken)
    {
        var Bidding = new Domain.Biddings.Bidding()
        {
            Id = Guid.NewGuid(),
            AuthorId = model.AuthorId,
            PostId = model.PostId,
            Price = model.Price,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
            TextComment = model.TextComment,
        };

        return _BiddingRepository.CreateAsync(Bidding, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Biddings.Bidding> UpdateAsync(UpdateBiddingDto model, CancellationToken cancellationToken)
    {
        var Bidding = new Domain.Biddings.Bidding()
        {
            Id = model.Id,
            TextComment = model.TextComment,
        };

        return _BiddingRepository.UpdateAsync(Bidding, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Bidding = new Domain.Biddings.Bidding()
        {
            Id = id,
        };

        return _BiddingRepository.DeleteAsync(Bidding, cancellationToken);
    }

    Task<Domain.Biddings.Bidding> IBiddingService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _BiddingRepository.GetByIdAsync(id, cancellationToken);
    }
}