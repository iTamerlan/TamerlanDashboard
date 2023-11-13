using Dashboard.Application.AppServices.Contexts.User.Services;
using Dashboard.Contracts.User;
using Dashboard.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Hosts.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями.
    /// </summary>
    [Route("user")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Инициализирует экзепляр <see cref="UserController"/>
        /// </summary>
        /// <param name="UserService">Сервис работы с пользователями.</param>
        public UserController(IUserService UserService, ILogger<UserController> logger)
        {
            _userService = UserService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает пользователя по идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример:
        /// curl -XGET http://host:port/user/get-by-id
        /// </remarks>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Модель мользователя <see cref="UserDto"/></returns>
        [HttpGet("get-by-id")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _userService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает всех пользователей.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Коллекция пользователей <see cref="UserDto"/></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _userService.GetAllAsync(cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Возвращает постраничный список пользователей.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageIndex">Номер страницы.</param>
        /// <returns>Коллекция пользователей <see cref="UserDto"/></returns>
        [HttpGet("get-all-paged")]
        public async Task<IActionResult> GetPageAsync(CancellationToken cancellationToken, int pageSize = 10, int pageIndex = 0)
        {
            var result = await _userService.GetPageAsync(pageSize, pageIndex, cancellationToken);
            return Ok(result);
            //return Ok();
        }

        /// <summary>
        /// Создает пользователя.
        /// </summary>
        /// <param name="dto">Модель для создания пользователя</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        /// <returns>Идентификатор созданной сущности</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken)
        {
            var modelId = await _userService.CreateAsync(dto, cancellationToken);
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
        /// Редактирует пользователя.
        /// </summary>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateUserDto dto, CancellationToken cancellationToken)
        {
            var model = await _userService.UpdateAsync(dto, cancellationToken);
            return Ok();
            //if (await TryUpdateModelAsync(model))
            //{return Ok();}
            //else{return BadRequest();}
        }

        /// <summary>
        /// Удаляем пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancellationToken">Отмена операции.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var modelId = await _userService.DeleteAsync(id, cancellationToken);
            return Accepted();
        }
    }
}
