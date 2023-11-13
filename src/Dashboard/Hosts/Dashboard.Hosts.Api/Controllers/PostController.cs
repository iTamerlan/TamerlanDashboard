using Dashboard.Application.AppServices.Contexts.Post.Services;
using Dashboard.Contracts.Post;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с объявлениями.
    /// </summary>
    [Route("Post")]
    //[ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _PostService;
        private readonly ILogger<PostController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="PostController"/>
        /// </summary>
        /// <param name="PostService">Сервис работы с объявлениями.</param>
        public PostController(IPostService PostService, ILogger<PostController> logger)
        {
            _PostService = PostService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает объявление по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Post/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор объявления.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель объявления <see cref="PostDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(PostDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = /*await*/ _PostService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все объявления.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция объявлений <see cref="PostDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = /*await*/ _PostService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные объявления.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция объявлений <see cref="PostDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = /*await*/ _PostService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает объявление.
        /// </summary>
        /// <param name="dto">Модель для создания объявления</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePostDto dto, CancellationToken cancellationToken)
        {
            var modelId = /*await*/ _PostService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует объявление.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdatePostDto dto, CancellationToken cancellationToken)
        {
            var model = /*await*/ _PostService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (/*await*/ TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем объявление по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор объявления.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = /*await*/ _PostService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
