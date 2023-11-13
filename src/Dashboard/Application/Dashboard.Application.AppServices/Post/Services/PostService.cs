using Dashboard.Application.AppServices.Contexts.Post.Repositories;
using Dashboard.Contracts.Post;
using Dashboard.Domain.Posts;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Post.Services;

/// <inheritdoc />
public class PostService : IPostService
{
    private readonly IPostRepository _PostRepository;
    //private Task<Domain.Posts.Post> _PostTask;
    //private Domain.Posts.Post _Post;

    /// <summary>
    /// Инициализирует экзепляр <see cref="PostService"/>
    /// </summary>
    /// <param name="PostRepository">Репозиторий для работы с объявлениями.</param>
    public PostService(IPostRepository PostRepository)
    {
        _PostRepository = PostRepository;
    }

    /// <inheritdoc />
    public Task<PostDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Posts.Post> _PostTask = _PostRepository.GetByIdAsync(id, cancellationToken);
        Domain.Posts.Post _Post = _PostTask.Result;

        //Task<PostDto> task = new Task<PostDto>();
        //Task<PostDto> _PostDto = task;

        return Task.Run(() => {
            return new PostDto()
            {
                Id = _Post.Id,
                Title = _Post.Title,
                Description = _Post.Description,
                //CategoryName = $"{_Post.CategoryId}",
                CategoryName = _Post.CategoryName,
                //Attachments = ,
                Price = _Post.Price,
            };
        });
    }

    /// <inheritdoc />
    public Task<PostDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Posts.Post, bool>> predicat = Post => Post;
        // predicat.Parameters(predicat => { });
        //return _PostRepository.GetAll();
        IQueryable<Domain.Posts.Post> _PostQueryable = _PostRepository.GetAllAsync(cancellationToken);
        Domain.Posts.Post[] _Posts = _PostQueryable.ToArray();

        return Task<PostDto[]>.Factory.StartNew(() =>
        {
            PostDto[] result = (from Post in _Posts
                          select new PostDto()
                          {
                              Id = Post.Id, //Guid.NewGuid(),
                              Title = Post.Title,
                              Description = Post.Description,
                              //CategoryName = $"{_Post.CategoryId}",
                              CategoryName = Post.CategoryName,
                              //Attachments = ,
                              Price = Post.Price,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<PostDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Posts.Post, bool>> predicat = Post => Post;
        // predicat.Parameters(predicat => { });
        //return _PostRepository.GetAll();
        IQueryable<Domain.Posts.Post> _PostQueryable = _PostRepository.GetAllAsync(cancellationToken);
        Domain.Posts.Post[] _Posts = _PostQueryable.ToArray();

        return Task<PostDto[]>.Factory.StartNew(() =>
        {
            PostDto[] result = (from Post in _Posts
            //where Post.Id == _Posts[0].
                                orderby Post.DateCreated
                                //where Post. == pageIndex

                                select new PostDto()
                                {
                                    Id = Post.Id, //Guid.NewGuid(),
                                    Title = Post.Title,
                                    Description = Post.Description,
                                    //CategoryName = $"{_Post.CategoryId}",
                                    CategoryName = Post.CategoryName,
                                    //Attachments = ,
                                    Price = Post.Price,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreatePostDto model, CancellationToken cancellationToken)
    {
        var Post = new Domain.Posts.Post()
        {
            Id = Guid.NewGuid(),
            Description = model.Description,
            Price = model.Price,
            Title = model.Title,
            //CategoryId = Guid.Parse(model.CategoryName),
            CategoryName = model.CategoryName,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
            StatusPost = StatusPublication.Draft,
        };

        return _PostRepository.CreateAsync(Post, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Posts.Post> UpdateAsync(UpdatePostDto model, CancellationToken cancellationToken)
    {
        var Post = new Domain.Posts.Post()
        {
            Id = model.Id,
            Description = model.Description,
            Price = model.Price,
            Title = model.Title,
            //CategoryId = Guid.Parse(model.CategoryName),
            CategoryName = model.CategoryName,
            StatusPost = model.StatusPost,
        };

        return _PostRepository.UpdateAsync(Post, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Post = new Domain.Posts.Post()
        {
            Id = id,
        };

        return _PostRepository.DeleteAsync(Post, cancellationToken);
    }

    Task<Domain.Posts.Post> IPostService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _PostRepository.GetByIdAsync(id, cancellationToken);
    }
}