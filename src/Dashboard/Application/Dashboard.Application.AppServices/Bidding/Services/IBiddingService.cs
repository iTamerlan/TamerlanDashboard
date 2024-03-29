// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Contracts.Bidding;

namespace Dashboard.Application.AppServices.Contexts.Bidding.Services

{
/// <summary>
/// Сервис работы с аукционами.
/// </summary>
public interface IBiddingService
{
    /// <summary>
    /// Возвращает Аукцион по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор Аукционы.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Аукционы <see cref="Domain.Biddings.Bidding"/></returns>
    Task<Domain.Biddings.Bidding> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Аукционы.
    /// </summary>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Список моделей Аукционы <see cref="BiddingDto"/></returns>
    Task<BiddingDto[]> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Аукционы, постранично в зависимости от размера страницы и индекса страницы.
    /// </summary>
    /// <param name="id">Идентификатор Аукционы.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Список моделей -- Аукционы <see cref="BiddingDto"/></returns>
    Task<BiddingDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken);

    /// <summary>
    /// Создает Аукцион по модели.
    /// </summary>
    /// <param name="model">Модель Аукционы.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор созданной сущности</returns>
    Task<Guid> CreateAsync(CreateBiddingDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет(изменяет) Аукцион по модели.
    /// </summary>
    /// <param name="model">Модель Аукционы.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Аукционы <see cref="Domain.Biddings.Bidding"/></returns>
    Task<Domain.Biddings.Bidding> UpdateAsync(UpdateBiddingDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет Аукцион по модели.
    /// </summary>
    /// <param name="id">Идентификатор Аукционы.</param>
    /// <param name="model">Модель Аукционы.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор удаленного Аукционы</returns>
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
}

