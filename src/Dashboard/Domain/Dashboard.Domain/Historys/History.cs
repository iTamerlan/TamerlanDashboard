// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Domain.Base;

namespace Dashboard.Domain.Historys
{
    /// <summary>
    /// Сущность истории просмотра продукта.
    /// </summary>
    public class History : BaseEntity
    {
        /// <summary>
        /// Автор объявления.
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Родительский объект.
        /// </summary>
        public Guid ParrentId { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime DateCreated { get; set; }

    }
}
