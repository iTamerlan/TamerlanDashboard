using Dashboard.Application.AppServices.Contexts.History.Services;
using Dashboard.Contracts.History;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с историями.
    /// </summary>
    [Route("History")]
    //[ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _HistoryService;
        private readonly ILogger<HistoryController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="HistoryController"/>
        /// </summary>
        /// <param name="HistoryService">Сервис работы с историями.</param>
        public HistoryController(IHistoryService HistoryService, ILogger<HistoryController> logger)
        {
            _HistoryService = HistoryService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает историю по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/History/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор истории.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель истории <see cref="HistoryDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(HistoryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _HistoryService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все истории.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция историй <see cref="HistoryDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _HistoryService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные истории.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция историй <see cref="HistoryDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _HistoryService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает историю.
        /// </summary>
        /// <param name="dto">Модель для создания истории</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateHistoryDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _HistoryService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует историю.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateHistoryDto dto, CancellationToken cancellationToken)
        {
            var model = await _HistoryService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем историю по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор истории.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _HistoryService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
