using Dashboard.Application.AppServices.Contexts.Tag.Services;
using Dashboard.Contracts.Tag;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с тегами.
    /// </summary>
    [Route("Tag")]
    //[ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _TagService;
        private readonly ILogger<TagController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="TagController"/>
        /// </summary>
        /// <param name="TagService">Сервис работы с тегами.</param>
        public TagController(ITagService TagService, ILogger<TagController> logger)
        {
            _TagService = TagService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает тег по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Tag/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор тега.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель тега <see cref="TagDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(TagDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _TagService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все теги.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция тегов <see cref="TagDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _TagService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные теги.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция тегов <see cref="TagDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _TagService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает тег.
        /// </summary>
        /// <param name="dto">Модель для создания тега</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateTagDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _TagService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует тег.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateTagDto dto, CancellationToken cancellationToken)
        {
            var model = await _TagService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем тег по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор тега.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _TagService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
