using Dashboard.Application.AppServices.Contexts.Voting.Repositories;
using Dashboard.Contracts.Voting;
using Dashboard.Domain.Votings;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Voting.Services;

/// <inheritdoc />
public class VotingService : IVotingService
{
    private readonly IVotingRepository _VotingRepository;
    //private Task<Domain.Votings.Voting> _VotingTask;
    //private Domain.Votings.Voting _Voting;

    /// <summary>
    /// Инициализирует экзепляр <see cref="VotingService"/>
    /// </summary>
    /// <param name="VotingRepository">Репозиторий для работы с голосованиями.</param>
    public VotingService(IVotingRepository VotingRepository)
    {
        _VotingRepository = VotingRepository;
    }

    /// <inheritdoc />
    public Task<VotingDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Votings.Voting> _VotingTask = _VotingRepository.GetByIdAsync(id, cancellationToken);
        Domain.Votings.Voting _Voting = _VotingTask.Result;

        //Task<VotingDto> task = new Task<VotingDto>();
        //Task<VotingDto> _VotingDto = task;

        return Task.Run(() => {
            return new VotingDto()
            {
                Id = _Voting.Id,
                AuthorId = _Voting.AuthorId,
                PostId = _Voting.PostId,
                Rating = _Voting.Rating,
                DateCreated = _Voting.DateCreated,
            };
        });
    }

    /// <inheritdoc />
    public Task<VotingDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Votings.Voting, bool>> predicat = Voting => Voting;
        // predicat.Parameters(predicat => { });
        //return _VotingRepository.GetAll();
        IQueryable<Domain.Votings.Voting> _VotingQueryable = _VotingRepository.GetAllAsync(cancellationToken);
        Domain.Votings.Voting[] _Votings = _VotingQueryable.ToArray();

        return Task<VotingDto[]>.Factory.StartNew(() =>
        {
            VotingDto[] result = (from _Voting in _Votings
                          select new VotingDto()
                          {
                              Id = _Voting.Id,
                              AuthorId = _Voting.AuthorId,
                              PostId = _Voting.PostId,
                              Rating = _Voting.Rating,
                              DateCreated = _Voting.DateCreated,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<VotingDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Votings.Voting, bool>> predicat = Voting => Voting;
        // predicat.Parameters(predicat => { });
        //return _VotingRepository.GetAll();
        IQueryable<Domain.Votings.Voting> _VotingQueryable = _VotingRepository.GetAllAsync(cancellationToken);
        Domain.Votings.Voting[] _Votings = _VotingQueryable.ToArray();

        return Task<VotingDto[]>.Factory.StartNew(() =>
        {
            VotingDto[] result = (from _Voting in _Votings
            //where Voting.Id == _Votings[0].
                                orderby _Voting.DateCreated
                                //where Voting. == pageIndex

                                select new VotingDto()
                                {
                                    Id = _Voting.Id,
                                    AuthorId = _Voting.AuthorId,
                                    PostId = _Voting.PostId,
                                    Rating = _Voting.Rating,
                                    DateCreated = _Voting.DateCreated,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateVotingDto model, CancellationToken cancellationToken)
    {
        var Voting = new Domain.Votings.Voting()
        {
            Id = Guid.NewGuid(),
            AuthorId = model.AuthorId,
            PostId = model.PostId,
            Rating = model.Rating,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
        };

        return _VotingRepository.CreateAsync(Voting, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Votings.Voting> UpdateAsync(UpdateVotingDto model, CancellationToken cancellationToken)
    {
        var Voting = new Domain.Votings.Voting()
        {
            Id = model.Id,
        };

        return _VotingRepository.UpdateAsync(Voting, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Voting = new Domain.Votings.Voting()
        {
            Id = id,
        };

        return _VotingRepository.DeleteAsync(Voting, cancellationToken);
    }

    Task<Domain.Votings.Voting> IVotingService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _VotingRepository.GetByIdAsync(id, cancellationToken);
    }
}