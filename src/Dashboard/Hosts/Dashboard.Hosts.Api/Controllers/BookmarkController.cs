using Dashboard.Application.AppServices.Contexts.Bookmark.Services;
using Dashboard.Contracts.Bookmark;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с закладками.
    /// </summary>
    [Route("Bookmark")]
    //[ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _BookmarkService;
        private readonly ILogger<BookmarkController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="BookmarkController"/>
        /// </summary>
        /// <param name="BookmarkService">Сервис работы с закладками.</param>
        public BookmarkController(IBookmarkService BookmarkService, ILogger<BookmarkController> logger)
        {
            _BookmarkService = BookmarkService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает закладку по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Bookmark/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор закладки.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель закладки <see cref="BookmarkDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(BookmarkDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _BookmarkService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все закладки.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция закладок <see cref="BookmarkDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _BookmarkService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные закладки.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция закладок <see cref="BookmarkDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _BookmarkService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает закладку.
        /// </summary>
        /// <param name="dto">Модель для создания закладки</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBookmarkDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _BookmarkService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует закладку.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBookmarkDto dto, CancellationToken cancellationToken)
        {
            var model = await _BookmarkService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем закладку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор закладки.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _BookmarkService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
