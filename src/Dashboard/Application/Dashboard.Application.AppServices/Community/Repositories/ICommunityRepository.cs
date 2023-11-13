// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Domain.Communitys;

namespace Dashboard.Application.AppServices.Contexts.Community.Repositories

{
/// <summary>
/// Репозиторий для работы с сообществами.
/// </summary>
public interface ICommunityRepository
{
    /// <summary>
    /// Возвращает Сообщество по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор Сообщества.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Сообщества <see cref="Domain.Communitys.Community"/></returns>
    Task<Domain.Communitys.Community> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Сообщества.
    /// </summary>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Список моделей Сообщества <see cref="Domain.Communitys.Community"/></returns>
    IQueryable < Domain.Communitys.Community > GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Сообщества, постранично в зависимости от размера страницы и индекса страницы.
    /// </summary>
    /// <param name="id">Идентификатор Сообщества.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Список моделей -- Сообщества <see cref="Domain.Communitys.Community"/></returns>
    //IQueryable < Domain.Communitys.Community > GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken);

    /// <summary>
    /// Создает Сообщество по модели.
    /// </summary>
    /// <param name="model">Модель Сообщества.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор созданной сущности</returns>
    Task<Guid> CreateAsync(Domain.Communitys.Community model, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет(изменяет) Сообщество по модели.
    /// </summary>
    /// <param name="model">Модель Сообщества.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Сообщества <see cref="Domain.Communitys.Community"/></returns>
    Task<Domain.Communitys.Community> UpdateAsync(Domain.Communitys.Community model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет Сообщество по модели.
    /// </summary>
    /// <param name="id">Идентификатор Сообщества.</param>
    /// <param name="model">Модель Сообщества.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор удаленного Сообщества</returns>
    Task<Guid> DeleteAsync(Domain.Communitys.Community model, CancellationToken cancellationToken);
}
}
