// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Domain.Base;

namespace Dashboard.Domain.Categorys
{
    /// <summary>
    /// Сущность категорий.
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Наименование категории.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Родительский объект.
        /// </summary>
        public Guid ParrentId { get; set; }

    }
}
