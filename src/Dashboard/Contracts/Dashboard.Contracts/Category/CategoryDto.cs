// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Contracts.Base;

namespace Dashboard.Contracts.Category
{
    /// <summary>
    /// Сущность категорий.
    /// </summary>
    public class CategoryDto : BaseDto
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
