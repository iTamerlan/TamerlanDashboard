// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Domain.Users;

namespace Dashboard.Application.AppServices.Contexts.User.Repositories

{
/// <summary>
/// Репозиторий для работы с пользователями.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Возвращает Пользователь по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор Пользователя.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Пользователя <see cref="Domain.Users.User"/></returns>
    Task<Domain.Users.User> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Пользователя.
    /// </summary>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Список моделей Пользователя <see cref="Domain.Users.User"/></returns>
    IQueryable < Domain.Users.User > GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Пользователя, постранично в зависимости от размера страницы и индекса страницы.
    /// </summary>
    /// <param name="id">Идентификатор Пользователя.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Список моделей -- Пользователя <see cref="Domain.Users.User"/></returns>
    //IQueryable < Domain.Users.User > GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken);

    /// <summary>
    /// Создает Пользователь по модели.
    /// </summary>
    /// <param name="model">Модель Пользователя.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор созданной сущности</returns>
    Task<Guid> CreateAsync(Domain.Users.User model, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет(изменяет) Пользователь по модели.
    /// </summary>
    /// <param name="model">Модель Пользователя.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Пользователя <see cref="Domain.Users.User"/></returns>
    Task<Domain.Users.User> UpdateAsync(Domain.Users.User model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет Пользователь по модели.
    /// </summary>
    /// <param name="id">Идентификатор Пользователя.</param>
    /// <param name="model">Модель Пользователя.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор удаленного Пользователя</returns>
    Task<Guid> DeleteAsync(Domain.Users.User model, CancellationToken cancellationToken);
}
}
