using Dashboard.Application.AppServices.Contexts.Feedback.Repositories;
using Dashboard.Contracts.Feedback;
using Dashboard.Domain.Feedbacks;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Feedback.Services;

/// <inheritdoc />
public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _FeedbackRepository;
    //private Task<Domain.Feedbacks.Feedback> _FeedbackTask;
    //private Domain.Feedbacks.Feedback _Feedback;

    /// <summary>
    /// Инициализирует экзепляр <see cref="FeedbackService"/>
    /// </summary>
    /// <param name="FeedbackRepository">Репозиторий для работы с отзывами.</param>
    public FeedbackService(IFeedbackRepository FeedbackRepository)
    {
        _FeedbackRepository = FeedbackRepository;
    }

    /// <inheritdoc />
    public Task<FeedbackDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Feedbacks.Feedback> _FeedbackTask = _FeedbackRepository.GetByIdAsync(id, cancellationToken);
        Domain.Feedbacks.Feedback _Feedback = _FeedbackTask.Result;

        //Task<FeedbackDto> task = new Task<FeedbackDto>();
        //Task<FeedbackDto> _FeedbackDto = task;

        return Task.Run(() => {
            return new FeedbackDto()
            {
                Id = _Feedback.Id,
                AuthorId = _Feedback.AuthorId,
                PostId = _Feedback.PostId,
                Description = _Feedback.Description,
                Rating = _Feedback.Rating,
                DateCreated = _Feedback.DateCreated,
            };
        });
    }

    /// <inheritdoc />
    public Task<FeedbackDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Feedbacks.Feedback, bool>> predicat = Feedback => Feedback;
        // predicat.Parameters(predicat => { });
        //return _FeedbackRepository.GetAll();
        IQueryable<Domain.Feedbacks.Feedback> _FeedbackQueryable = _FeedbackRepository.GetAllAsync(cancellationToken);
        Domain.Feedbacks.Feedback[] _Feedbacks = _FeedbackQueryable.ToArray();

        return Task<FeedbackDto[]>.Factory.StartNew(() =>
        {
            FeedbackDto[] result = (from _Feedback in _Feedbacks
                          select new FeedbackDto()
                          {
                              Id = _Feedback.Id,
                              AuthorId = _Feedback.AuthorId,
                              PostId = _Feedback.PostId,
                              Description = _Feedback.Description,
                              Rating = _Feedback.Rating,
                              DateCreated = _Feedback.DateCreated,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<FeedbackDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Feedbacks.Feedback, bool>> predicat = Feedback => Feedback;
        // predicat.Parameters(predicat => { });
        //return _FeedbackRepository.GetAll();
        IQueryable<Domain.Feedbacks.Feedback> _FeedbackQueryable = _FeedbackRepository.GetAllAsync(cancellationToken);
        Domain.Feedbacks.Feedback[] _Feedbacks = _FeedbackQueryable.ToArray();

        return Task<FeedbackDto[]>.Factory.StartNew(() =>
        {
            FeedbackDto[] result = (from _Feedback in _Feedbacks
            //where Feedback.Id == _Feedbacks[0].
                                orderby _Feedback.DateCreated
                                //where Feedback. == pageIndex

                                select new FeedbackDto()
                                {
                                    Id = _Feedback.Id,
                                    AuthorId = _Feedback.AuthorId,
                                    PostId = _Feedback.PostId,
                                    Description = _Feedback.Description,
                                    Rating = _Feedback.Rating,
                                    DateCreated = _Feedback.DateCreated,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateFeedbackDto model, CancellationToken cancellationToken)
    {
        var Feedback = new Domain.Feedbacks.Feedback()
        {
            Id = Guid.NewGuid(),
            AuthorId = model.AuthorId,
            PostId = model.PostId,
            Description = model.Description,
            Rating = model.Rating,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
        };

        return _FeedbackRepository.CreateAsync(Feedback, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Feedbacks.Feedback> UpdateAsync(UpdateFeedbackDto model, CancellationToken cancellationToken)
    {
        var Feedback = new Domain.Feedbacks.Feedback()
        {
            Id = model.Id,
            Description = model.Description,
            Rating = model.Rating,
        };

        return _FeedbackRepository.UpdateAsync(Feedback, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Feedback = new Domain.Feedbacks.Feedback()
        {
            Id = id,
        };

        return _FeedbackRepository.DeleteAsync(Feedback, cancellationToken);
    }

    Task<Domain.Feedbacks.Feedback> IFeedbackService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _FeedbackRepository.GetByIdAsync(id, cancellationToken);
    }
}