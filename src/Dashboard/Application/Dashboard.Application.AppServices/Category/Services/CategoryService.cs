using Dashboard.Application.AppServices.Contexts.Category.Repositories;
using Dashboard.Contracts.Category;
using Dashboard.Domain.Categorys;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Category.Services;

/// <inheritdoc />
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _CategoryRepository;
    //private Task<Domain.Categorys.Category> _CategoryTask;
    //private Domain.Categorys.Category _Category;

    /// <summary>
    /// Инициализирует экзепляр <see cref="CategoryService"/>
    /// </summary>
    /// <param name="CategoryRepository">Репозиторий для работы с категориями.</param>
    public CategoryService(ICategoryRepository CategoryRepository)
    {
        _CategoryRepository = CategoryRepository;
    }

    /// <inheritdoc />
    public Task<CategoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Categorys.Category> _CategoryTask = _CategoryRepository.GetByIdAsync(id, cancellationToken);
        Domain.Categorys.Category _Category = _CategoryTask.Result;

        //Task<CategoryDto> task = new Task<CategoryDto>();
        //Task<CategoryDto> _CategoryDto = task;

        return Task.Run(() => {
            return new CategoryDto()
            {
                Id = _Category.Id,
                CategoryName = _Category.CategoryName,
                ParrentId = _Category.ParrentId,
            };
        });
    }

    /// <inheritdoc />
    public Task<CategoryDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Categorys.Category, bool>> predicat = Category => Category;
        // predicat.Parameters(predicat => { });
        //return _CategoryRepository.GetAll();
        IQueryable<Domain.Categorys.Category> _CategoryQueryable = _CategoryRepository.GetAllAsync(cancellationToken);
        Domain.Categorys.Category[] _Categorys = _CategoryQueryable.ToArray();

        return Task<CategoryDto[]>.Factory.StartNew(() =>
        {
            CategoryDto[] result = (from _Category in _Categorys
                          select new CategoryDto()
                          {
                              Id = _Category.Id,
                              CategoryName = _Category.CategoryName,
                              ParrentId = _Category.ParrentId,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<CategoryDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Categorys.Category, bool>> predicat = Category => Category;
        // predicat.Parameters(predicat => { });
        //return _CategoryRepository.GetAll();
        IQueryable<Domain.Categorys.Category> _CategoryQueryable = _CategoryRepository.GetAllAsync(cancellationToken);
        Domain.Categorys.Category[] _Categorys = _CategoryQueryable.ToArray();

        return Task<CategoryDto[]>.Factory.StartNew(() =>
        {
            CategoryDto[] result = (from _Category in _Categorys
            //where Category.Id == _Categorys[0].
                                orderby _Category.CategoryName
                                //where Category. == pageIndex

                                select new CategoryDto()
                                {
                                    Id = _Category.Id,
                                    CategoryName = _Category.CategoryName,
                                    ParrentId = _Category.ParrentId,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateCategoryDto model, CancellationToken cancellationToken)
    {
        var Category = new Domain.Categorys.Category()
        {
            Id = Guid.NewGuid(),
            CategoryName = model.CategoryName,
            ParrentId = model.ParrentId,
        };

        return _CategoryRepository.CreateAsync(Category, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Categorys.Category> UpdateAsync(UpdateCategoryDto model, CancellationToken cancellationToken)
    {
        var Category = new Domain.Categorys.Category()
        {
            Id = model.Id,
            CategoryName = model.CategoryName,
            ParrentId = model.ParrentId,
        };

        return _CategoryRepository.UpdateAsync(Category, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Category = new Domain.Categorys.Category()
        {
            Id = id,
        };

        return _CategoryRepository.DeleteAsync(Category, cancellationToken);
    }

    Task<Domain.Categorys.Category> ICategoryService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _CategoryRepository.GetByIdAsync(id, cancellationToken);
    }
}