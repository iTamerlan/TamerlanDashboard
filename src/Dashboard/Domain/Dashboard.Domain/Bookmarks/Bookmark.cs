// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Domain.Base;

namespace Dashboard.Domain.Bookmarks
{
    /// <summary>
    /// Сущность закладок.
    /// </summary>
    public class Bookmark : BaseEntity
    {
        /// <summary>
        /// Идентификатор поста.
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// Автор объявления.
        /// </summary>
        public Guid AuthorId { get; set; }
        
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Наименование категории.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime DateCreated { get; set; }

    }
}
