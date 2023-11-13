using Dashboard.Application.AppServices.Contexts.Feedback.Services;
using Dashboard.Contracts.Feedback;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с отзывами.
    /// </summary>
    [Route("Feedback")]
    //[ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _FeedbackService;
        private readonly ILogger<FeedbackController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="FeedbackController"/>
        /// </summary>
        /// <param name="FeedbackService">Сервис работы с отзывами.</param>
        public FeedbackController(IFeedbackService FeedbackService, ILogger<FeedbackController> logger)
        {
            _FeedbackService = FeedbackService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает отзыв по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Feedback/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор отзыва.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель отзыва <see cref="FeedbackDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(FeedbackDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _FeedbackService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все отзывы.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция отзывов <see cref="FeedbackDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _FeedbackService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные отзыва.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция отзывов <see cref="FeedbackDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _FeedbackService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает отзыв.
        /// </summary>
        /// <param name="dto">Модель для создания отзыва</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateFeedbackDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _FeedbackService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует отзыв.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateFeedbackDto dto, CancellationToken cancellationToken)
        {
            var model = await _FeedbackService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем отзыв по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор отзыва.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _FeedbackService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
