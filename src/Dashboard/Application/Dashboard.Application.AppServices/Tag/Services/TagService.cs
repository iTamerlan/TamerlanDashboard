using Dashboard.Application.AppServices.Contexts.Tag.Repositories;
using Dashboard.Contracts.Tag;
using Dashboard.Domain.Tags;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Tag.Services;

/// <inheritdoc />
public class TagService : ITagService
{
    private readonly ITagRepository _TagRepository;
    //private Task<Domain.Tags.Tag> _TagTask;
    //private Domain.Tags.Tag _Tag;

    /// <summary>
    /// Инициализирует экзепляр <see cref="TagService"/>
    /// </summary>
    /// <param name="TagRepository">Репозиторий для работы с тегами.</param>
    public TagService(ITagRepository TagRepository)
    {
        _TagRepository = TagRepository;
    }

    /// <inheritdoc />
    public Task<TagDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Tags.Tag> _TagTask = _TagRepository.GetByIdAsync(id, cancellationToken);
        Domain.Tags.Tag _Tag = _TagTask.Result;

        //Task<TagDto> task = new Task<TagDto>();
        //Task<TagDto> _TagDto = task;

        return Task.Run(() => {
            return new TagDto()
            {
                Id = _Tag.Id,
                Title = _Tag.Title,
            };
        });
    }

    /// <inheritdoc />
    public Task<TagDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Tags.Tag, bool>> predicat = Tag => Tag;
        // predicat.Parameters(predicat => { });
        //return _TagRepository.GetAll();
        IQueryable<Domain.Tags.Tag> _TagQueryable = _TagRepository.GetAllAsync(cancellationToken);
        Domain.Tags.Tag[] _Tags = _TagQueryable.ToArray();

        return Task<TagDto[]>.Factory.StartNew(() =>
        {
            TagDto[] result = (from _Tag in _Tags
                          select new TagDto()
                          {
                              Id = _Tag.Id,
                              Title = _Tag.Title,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<TagDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Tags.Tag, bool>> predicat = Tag => Tag;
        // predicat.Parameters(predicat => { });
        //return _TagRepository.GetAll();
        IQueryable<Domain.Tags.Tag> _TagQueryable = _TagRepository.GetAllAsync(cancellationToken);
        Domain.Tags.Tag[] _Tags = _TagQueryable.ToArray();

        return Task<TagDto[]>.Factory.StartNew(() =>
        {
            TagDto[] result = (from _Tag in _Tags
            //where Tag.Id == _Tags[0].
                                orderby _Tag.Title
                                //where Tag. == pageIndex

                                select new TagDto()
                                {
                                    Id = _Tag.Id,
                                    Title = _Tag.Title,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateTagDto model, CancellationToken cancellationToken)
    {
        var Tag = new Domain.Tags.Tag()
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
        };

        return _TagRepository.CreateAsync(Tag, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Tags.Tag> UpdateAsync(UpdateTagDto model, CancellationToken cancellationToken)
    {
        var Tag = new Domain.Tags.Tag()
        {
            Id = model.Id,
            Title = model.Title,
        };

        return _TagRepository.UpdateAsync(Tag, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Tag = new Domain.Tags.Tag()
        {
            Id = id,
        };

        return _TagRepository.DeleteAsync(Tag, cancellationToken);
    }

    Task<Domain.Tags.Tag> ITagService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _TagRepository.GetByIdAsync(id, cancellationToken);
    }
}