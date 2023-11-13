// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Contracts.Base;
using Engine.ModelProperties.Base;

namespace Dashboard.Contracts.Post
{
    /// <summary>
    /// Объявление.
    /// </summary>
    public class PostDto : BaseDto
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Наименование категории.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public StatusPublication StatusPost { get; set; }
    }
}
