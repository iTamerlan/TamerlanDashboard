using Dashboard.Application.AppServices.Contexts.Comment.Repositories;
using Dashboard.Contracts.Comment;
using Dashboard.Domain.Comments;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Comment.Services;

/// <inheritdoc />
public class CommentService : ICommentService
{
    private readonly ICommentRepository _CommentRepository;
    //private Task<Domain.Comments.Comment> _CommentTask;
    //private Domain.Comments.Comment _Comment;

    /// <summary>
    /// Инициализирует экзепляр <see cref="CommentService"/>
    /// </summary>
    /// <param name="CommentRepository">Репозиторий для работы с комментариями.</param>
    public CommentService(ICommentRepository CommentRepository)
    {
        _CommentRepository = CommentRepository;
    }

    /// <inheritdoc />
    public Task<CommentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Comments.Comment> _CommentTask = _CommentRepository.GetByIdAsync(id, cancellationToken);
        Domain.Comments.Comment _Comment = _CommentTask.Result;

        //Task<CommentDto> task = new Task<CommentDto>();
        //Task<CommentDto> _CommentDto = task;

        return Task.Run(() => {
            return new CommentDto()
            {
                Id = _Comment.Id,
                TextComment = _Comment.TextComment,
                AuthorId = _Comment.AuthorId,
                DateCreate = _Comment.DateCreate,
                PostId = _Comment.PostId,
            };
        });
    }

    /// <inheritdoc />
    public Task<CommentDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Comments.Comment, bool>> predicat = Comment => Comment;
        // predicat.Parameters(predicat => { });
        //return _CommentRepository.GetAll();
        IQueryable<Domain.Comments.Comment> _CommentQueryable = _CommentRepository.GetAllAsync(cancellationToken);
        Domain.Comments.Comment[] _Comments = _CommentQueryable.ToArray();

        return Task<CommentDto[]>.Factory.StartNew(() =>
        {
            CommentDto[] result = (from Comment in _Comments
                          select new CommentDto()
                          {
                              Id = Comment.Id, //Guid.NewGuid(),
                              TextComment = Comment.TextComment,
                              AuthorId = Comment.AuthorId,
                              DateCreate = Comment.DateCreate,
                              PostId = Comment.PostId,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<CommentDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Comments.Comment, bool>> predicat = Comment => Comment;
        // predicat.Parameters(predicat => { });
        //return _CommentRepository.GetAll();
        IQueryable<Domain.Comments.Comment> _CommentQueryable = _CommentRepository.GetAllAsync(cancellationToken);
        Domain.Comments.Comment[] _Comments = _CommentQueryable.ToArray();

        return Task<CommentDto[]>.Factory.StartNew(() =>
        {
            CommentDto[] result = (from Comment in _Comments
            //where Comment.Id == _Comments[0].
                                orderby Comment.DateCreate
                                //where Comment. == pageIndex

                                select new CommentDto()
                                {
                                    Id = Comment.Id, //Guid.NewGuid(),
                                    TextComment = Comment.TextComment,
                                    AuthorId = Comment.AuthorId,
                                    DateCreate = Comment.DateCreate,
                                    PostId = Comment.PostId,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateCommentDto model, CancellationToken cancellationToken)
    {
        var Comment = new Domain.Comments.Comment()
        {
            Id = Guid.NewGuid(),
            TextComment = model.TextComment,
            AuthorId = model.AuthorId,
            DateCreate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
            PostId = model.PostId,
        };

        return _CommentRepository.CreateAsync(Comment, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Comments.Comment> UpdateAsync(UpdateCommentDto model, CancellationToken cancellationToken)
    {
        var Comment = new Domain.Comments.Comment()
        {
            Id = model.Id,
            TextComment = model.TextComment,
        };

        return _CommentRepository.UpdateAsync(Comment, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Comment = new Domain.Comments.Comment()
        {
            Id = id,
        };

        return _CommentRepository.DeleteAsync(Comment, cancellationToken);
    }

    Task<Domain.Comments.Comment> ICommentService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _CommentRepository.GetByIdAsync(id, cancellationToken);
    }
}