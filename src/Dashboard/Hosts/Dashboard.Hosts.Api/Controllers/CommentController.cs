using Dashboard.Application.AppServices.Contexts.Comment.Services;
using Dashboard.Contracts.Comment;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с коментариями.
    /// </summary>
    [Route("comment")]
    //[ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _сommentService;
        private readonly ILogger<CommentController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="CommentController"/>
        /// </summary>
        /// <param name="CommentService">Сервис работы с комментариями.</param>
        public CommentController(ICommentService CommentService, ILogger<CommentController> logger)
        {
            _сommentService = CommentService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает комментарий по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/сomment/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор объявления.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель объявления <see cref="CommentDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(CommentDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = /*await*/ _сommentService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все коментарии.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция объявлений <see cref="CommentDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = /*await*/ _сommentService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные комментарии.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция комментариев <see cref="CommentDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = /*await*/ _сommentService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает комментарий.
        /// </summary>
        /// <param name="dto">Модель для создания комментария</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCommentDto dto, CancellationToken cancellationToken)
        {
            var modelId = /*await*/ _сommentService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует комментарий.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCommentDto dto, CancellationToken cancellationToken)
        {
            var model = /*await*/ _сommentService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (/*await*/ TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем комментарий по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор комментария.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = /*await*/ _сommentService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
