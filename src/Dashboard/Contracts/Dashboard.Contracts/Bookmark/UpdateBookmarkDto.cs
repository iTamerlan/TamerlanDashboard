// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Contracts.Base;

namespace Dashboard.Contracts.Bookmark
{
    /// <summary>
    /// Сущность закладок.
    /// </summary>
    public class UpdateBookmarkDto : BaseDto
    {        
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Наименование категории.
        /// </summary>
        public string CategoryName { get; set; }

    }
}
