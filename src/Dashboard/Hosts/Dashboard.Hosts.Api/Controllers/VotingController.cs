using Dashboard.Application.AppServices.Contexts.Voting.Services;
using Dashboard.Contracts.Voting;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с госованиями.
    /// </summary>
    [Route("Voting")]
    //[ApiController]
    public class VotingController : ControllerBase
    {
        private readonly IVotingService _VotingService;
        private readonly ILogger<VotingController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="VotingController"/>
        /// </summary>
        /// <param name="VotingService">Сервис работы с госованиями.</param>
        public VotingController(IVotingService VotingService, ILogger<VotingController> logger)
        {
            _VotingService = VotingService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает госование по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Voting/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор госования.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель госования <see cref="VotingDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(VotingDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _VotingService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все госования.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция госований <see cref="VotingDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _VotingService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные госования.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция госований <see cref="VotingDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _VotingService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает госование.
        /// </summary>
        /// <param name="dto">Модель для создания госования</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateVotingDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _VotingService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует госование.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateVotingDto dto, CancellationToken cancellationToken)
        {
            var model = await _VotingService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем госование по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор госования.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _VotingService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
