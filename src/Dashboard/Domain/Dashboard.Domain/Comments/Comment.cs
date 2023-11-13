// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Domain.Base;

namespace Dashboard.Domain.Comments
{
    /// <summary>
    /// Сущность комментария.
    /// </summary>
    public class Comment : BaseEntity
    {
        /// <summary>
        /// Текст комментария.
        /// </summary>
        public string TextComment { get; set; }
        /// <summary>
        /// Автор объявления.
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Дата создания комментария.
        /// </summary>
        public DateTime DateCreate { get; set; }
        /// <summary>
        /// Идентификатор поста.
        /// </summary>
        public Guid PostId { get; set; }
    }
}