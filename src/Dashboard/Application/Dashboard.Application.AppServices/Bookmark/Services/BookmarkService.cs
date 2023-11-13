using Dashboard.Application.AppServices.Contexts.Bookmark.Repositories;
using Dashboard.Contracts.Bookmark;
using Dashboard.Domain.Bookmarks;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Bookmark.Services;

/// <inheritdoc />
public class BookmarkService : IBookmarkService
{
    private readonly IBookmarkRepository _BookmarkRepository;
    //private Task<Domain.Bookmarks.Bookmark> _BookmarkTask;
    //private Domain.Bookmarks.Bookmark _Bookmark;

    /// <summary>
    /// Инициализирует экзепляр <see cref="BookmarkService"/>
    /// </summary>
    /// <param name="BookmarkRepository">Репозиторий для работы с закладками.</param>
    public BookmarkService(IBookmarkRepository BookmarkRepository)
    {
        _BookmarkRepository = BookmarkRepository;
    }

    /// <inheritdoc />
    public Task<BookmarkDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Bookmarks.Bookmark> _BookmarkTask = _BookmarkRepository.GetByIdAsync(id, cancellationToken);
        Domain.Bookmarks.Bookmark _Bookmark = _BookmarkTask.Result;

        //Task<BookmarkDto> task = new Task<BookmarkDto>();
        //Task<BookmarkDto> _BookmarkDto = task;

        return Task.Run(() => {
            return new BookmarkDto()
            {
                Id = _Bookmark.Id,
                AuthorId = _Bookmark.Id,
                PostId = _Bookmark.PostId,
                Description = _Bookmark.Description,
                CategoryName = _Bookmark.CategoryName,
                DateCreated = _Bookmark.DateCreated,
            };
        });
    }

    /// <inheritdoc />
    public Task<BookmarkDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Bookmarks.Bookmark, bool>> predicat = Bookmark => Bookmark;
        // predicat.Parameters(predicat => { });
        //return _BookmarkRepository.GetAll();
        IQueryable<Domain.Bookmarks.Bookmark> _BookmarkQueryable = _BookmarkRepository.GetAllAsync(cancellationToken);
        Domain.Bookmarks.Bookmark[] _Bookmarks = _BookmarkQueryable.ToArray();

        return Task<BookmarkDto[]>.Factory.StartNew(() =>
        {
            BookmarkDto[] result = (from _Bookmark in _Bookmarks
                          select new BookmarkDto()
                          {
                              Id = _Bookmark.Id,
                              AuthorId = _Bookmark.Id,
                              PostId = _Bookmark.PostId,
                              Description = _Bookmark.Description,
                              CategoryName = _Bookmark.CategoryName,
                              DateCreated = _Bookmark.DateCreated,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<BookmarkDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Bookmarks.Bookmark, bool>> predicat = Bookmark => Bookmark;
        // predicat.Parameters(predicat => { });
        //return _BookmarkRepository.GetAll();
        IQueryable<Domain.Bookmarks.Bookmark> _BookmarkQueryable = _BookmarkRepository.GetAllAsync(cancellationToken);
        Domain.Bookmarks.Bookmark[] _Bookmarks = _BookmarkQueryable.ToArray();

        return Task<BookmarkDto[]>.Factory.StartNew(() =>
        {
            BookmarkDto[] result = (from _Bookmark in _Bookmarks
            //where Bookmark.Id == _Bookmarks[0].
                                orderby _Bookmark.DateCreated
                                //where Bookmark. == pageIndex

                                select new BookmarkDto()
                                {
                                    Id = _Bookmark.Id,
                                    AuthorId = _Bookmark.Id,
                                    PostId = _Bookmark.PostId,
                                    Description = _Bookmark.Description,
                                    CategoryName = _Bookmark.CategoryName,
                                    DateCreated = _Bookmark.DateCreated,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateBookmarkDto model, CancellationToken cancellationToken)
    {
        var Bookmark = new Domain.Bookmarks.Bookmark()
        {
            Id = Guid.NewGuid(),
            AuthorId = model.Id,
            PostId = model.PostId,
            Description = model.Description,
            CategoryName = model.CategoryName,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
        };

        return _BookmarkRepository.CreateAsync(Bookmark, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Bookmarks.Bookmark> UpdateAsync(UpdateBookmarkDto model, CancellationToken cancellationToken)
    {
        var Bookmark = new Domain.Bookmarks.Bookmark()
        {
            Id = model.Id,
            Description = model.Description,
            CategoryName = model.CategoryName,
        };

        return _BookmarkRepository.UpdateAsync(Bookmark, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Bookmark = new Domain.Bookmarks.Bookmark()
        {
            Id = id,
        };

        return _BookmarkRepository.DeleteAsync(Bookmark, cancellationToken);
    }

    Task<Domain.Bookmarks.Bookmark> IBookmarkService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _BookmarkRepository.GetByIdAsync(id, cancellationToken);
    }
}