using Dashboard.Application.AppServices.Contexts.Product.Services;
using Dashboard.Contracts.Product;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с товарами.
    /// </summary>
    [Route("Product")]
    //[ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly ILogger<ProductController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="ProductController"/>
        /// </summary>
        /// <param name="ProductService">Сервис работы с товарами.</param>
        public ProductController(IProductService ProductService, ILogger<ProductController> logger)
        {
            _ProductService = ProductService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает товар по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Product/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор товара.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель товара <see cref="ProductDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _ProductService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все товары.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция товаров <see cref="ProductDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _ProductService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные товары.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция товаров <see cref="ProductDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _ProductService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает товар.
        /// </summary>
        /// <param name="dto">Модель для создания товара</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _ProductService.CreateAsync(dto, cancellationToken);
            /*if (string.IsNullOrEmpty(dto.Title))
            {
                ModelState.AddModelError(nameof(dto.Title, "Поле Title должно содержать значение");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            return Created(nameof(CreateAsync), modelId);
            //return Ok();
        }

        /// <summary>
        /// Редактирует товар.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto dto, CancellationToken cancellationToken)
        {
            var model = await _ProductService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем товар по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор товара.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _ProductService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
