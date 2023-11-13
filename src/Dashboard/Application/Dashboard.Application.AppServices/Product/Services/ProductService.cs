using Dashboard.Application.AppServices.Contexts.Product.Repositories;
using Dashboard.Contracts.Product;
using Dashboard.Domain.Products;
using System.Reflection;
using Engine.ModelProperties.Base;
using System.Xml.Linq;

namespace Dashboard.Application.AppServices.Contexts.Product.Services;

/// <inheritdoc />
public class ProductService : IProductService
{
    private readonly IProductRepository _ProductRepository;
    //private Task<Domain.Products.Product> _ProductTask;
    //private Domain.Products.Product _Product;

    /// <summary>
    /// Инициализирует экзепляр <see cref="ProductService"/>
    /// </summary>
    /// <param name="ProductRepository">Репозиторий для работы с товарами.</param>
    public ProductService(IProductRepository ProductRepository)
    {
        _ProductRepository = ProductRepository;
    }

    /// <inheritdoc />
    public Task<ProductDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Task<Domain.Products.Product> _ProductTask = _ProductRepository.GetByIdAsync(id, cancellationToken);
        Domain.Products.Product _Product = _ProductTask.Result;

        //Task<ProductDto> task = new Task<ProductDto>();
        //Task<ProductDto> _ProductDto = task;

        return Task.Run(() => {
            return new ProductDto()
            {
                Id = _Product.Id,
                ParrentId = _Product.Id,
                Title = _Product.Title,
                Description = _Product.Description,
                AuthorId = _Product.AuthorId,
                CategoryName = _Product.CategoryName,
                Price = _Product.Price,
                DateCreated = _Product.DateCreated,
            };
        });
    }

    /// <inheritdoc />
    public Task<ProductDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Products.Product, bool>> predicat = Product => Product;
        // predicat.Parameters(predicat => { });
        //return _ProductRepository.GetAll();
        IQueryable<Domain.Products.Product> _ProductQueryable = _ProductRepository.GetAllAsync(cancellationToken);
        Domain.Products.Product[] _Products = _ProductQueryable.ToArray();

        return Task<ProductDto[]>.Factory.StartNew(() =>
        {
            ProductDto[] result = (from _Product in _Products
                          select new ProductDto()
                          {
                              Id = _Product.Id,
                              ParrentId = _Product.Id,
                              Title = _Product.Title,
                              Description = _Product.Description,
                              AuthorId = _Product.AuthorId,
                              CategoryName = _Product.CategoryName,
                              Price = _Product.Price,
                              DateCreated = _Product.DateCreated,
                          }
                          ).ToArray();
            return result;
        }
            );
    }



    /// <inheritdoc />
    public Task<ProductDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken)
    {
        // Expression<Func<Domain.Products.Product, bool>> predicat = Product => Product;
        // predicat.Parameters(predicat => { });
        //return _ProductRepository.GetAll();
        IQueryable<Domain.Products.Product> _ProductQueryable = _ProductRepository.GetAllAsync(cancellationToken);
        Domain.Products.Product[] _Products = _ProductQueryable.ToArray();

        return Task<ProductDto[]>.Factory.StartNew(() =>
        {
            ProductDto[] result = (from _Product in _Products
            //where Product.Id == _Products[0].
                                orderby _Product.Title
                                //where Product. == pageIndex

                                select new ProductDto()
                                {
                                    Id = _Product.Id,
                                    ParrentId = _Product.Id,
                                    Title = _Product.Title,
                                    Description = _Product.Description,
                                    AuthorId = _Product.AuthorId,
                                    CategoryName = _Product.CategoryName,
                                    Price = _Product.Price,
                                    DateCreated = _Product.DateCreated,
                                }
                          ).Skip(Math.Abs(pageIndex)* pageSize).Take(pageSize).ToArray();
            return result;
        }
            );
    }

    /// <inheritdoc />
    public Task<Guid> CreateAsync(CreateProductDto model, CancellationToken cancellationToken)
    {
        var Product = new Domain.Products.Product()
        {
            Id = Guid.NewGuid(),
            ParrentId = model.Id,
            Title = model.Title,
            Description = model.Description,
            AuthorId = model.AuthorId,
            CategoryName = model.CategoryName,
            Price = model.Price,
            DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc),
        };

        return _ProductRepository.CreateAsync(Product, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Domain.Products.Product> UpdateAsync(UpdateProductDto model, CancellationToken cancellationToken)
    {
        var Product = new Domain.Products.Product()
        {
            Id = model.Id,
            ParrentId = model.Id,
            Title = model.Title,
            Description = model.Description,
            CategoryName = model.CategoryName,
            Price = model.Price,
        };

        return _ProductRepository.UpdateAsync(Product, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Product = new Domain.Products.Product()
        {
            Id = id,
        };

        return _ProductRepository.DeleteAsync(Product, cancellationToken);
    }

    Task<Domain.Products.Product> IProductService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _ProductRepository.GetByIdAsync(id, cancellationToken);
    }
}