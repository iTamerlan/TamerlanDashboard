// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Dashboard.Contracts.Comment;

namespace Dashboard.Application.AppServices.Contexts.Comment.Services

{
/// <summary>
/// Сервис работы с комментариями.
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Возвращает Комментарий по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор Комментария.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Комментария <see cref="Domain.Comments.Comment"/></returns>
    Task<Domain.Comments.Comment> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Комментария.
    /// </summary>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Список моделей Комментария <see cref="CommentDto"/></returns>
    Task<CommentDto[]> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает список -- Комментария, постранично в зависимости от размера страницы и индекса страницы.
    /// </summary>
    /// <param name="id">Идентификатор Комментария.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Список моделей -- Комментария <see cref="CommentDto"/></returns>
    Task<CommentDto[]> GetPageAsync(int pageSize, int pageIndex, CancellationToken cancellationToken);

    /// <summary>
    /// Создает Комментарий по модели.
    /// </summary>
    /// <param name="model">Модель Комментария.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор созданной сущности</returns>
    Task<Guid> CreateAsync(CreateCommentDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет(изменяет) Комментарий по модели.
    /// </summary>
    /// <param name="model">Модель Комментария.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Модель Комментария <see cref="Domain.Comments.Comment"/></returns>
    Task<Domain.Comments.Comment> UpdateAsync(UpdateCommentDto model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет Комментарий по модели.
    /// </summary>
    /// <param name="id">Идентификатор Комментария.</param>
    /// <param name="model">Модель Комментария.</param>
    /// <param name="cancellationToken">Отмена операции.</param>
    /// <returns>Идентификатор удаленного Комментария</returns>
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
}

