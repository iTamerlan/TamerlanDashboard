using Dashboard.Application.AppServices.Contexts.Bidding.Services;
using Dashboard.Contracts.Bidding;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с торгами.
    /// </summary>
    [Route("Bidding")]
    //[ApiController]
    public class BiddingController : ControllerBase
    {
        private readonly IBiddingService _BiddingService;
        private readonly ILogger<BiddingController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="BiddingController"/>
        /// </summary>
        /// <param name="BiddingService">Сервис работы с торгами.</param>
        public BiddingController(IBiddingService BiddingService, ILogger<BiddingController> logger)
        {
            _BiddingService = BiddingService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает торги по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Bidding/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор торгов.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель торгов <see cref="BiddingDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(BiddingDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _BiddingService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все торги.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция торгов <see cref="BiddingDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _BiddingService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные торги.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция торгов <see cref="BiddingDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _BiddingService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает торги.
        /// </summary>
        /// <param name="dto">Модель для создания торгов</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBiddingDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _BiddingService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует торги.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBiddingDto dto, CancellationToken cancellationToken)
        {
            var model = await _BiddingService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем торги по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор торгов.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _BiddingService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
