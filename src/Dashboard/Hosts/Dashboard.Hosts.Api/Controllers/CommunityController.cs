using Dashboard.Application.AppServices.Contexts.Community.Services;
using Dashboard.Contracts.Community;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с сообществами.
    /// </summary>
    [Route("Community")]
    //[ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityService _CommunityService;
        private readonly ILogger<CommunityController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="CommunityController"/>
        /// </summary>
        /// <param name="CommunityService">Сервис работы с Сообществами.</param>
        public CommunityController(ICommunityService CommunityService, ILogger<CommunityController> logger)
        {
            _CommunityService = CommunityService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает сообщество по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/Community/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор сообщества.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель сообщества <see cref="CommunityDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(CommunityDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _CommunityService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает все сообщества.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция сообществ <see cref="CommunityDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _CommunityService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничные сообщества.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция сообществ <see cref="CommunityDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _CommunityService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает сообщество.
        /// </summary>
        /// <param name="dto">Модель для создания сообщества</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCommunityDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _CommunityService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует сообщество.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCommunityDto dto, CancellationToken cancellationToken)
        {
            var model = await _CommunityService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем сообщество по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщества.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _CommunityService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
