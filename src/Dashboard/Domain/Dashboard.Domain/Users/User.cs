// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Engine.Domain.Base;

namespace Dashboard.Domain.Users
{
    /// <summary>
    /// Сущность пользователя.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Регистрационный Email.
        /// </summary>
        public string EmailReg { get; set; }
        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }
    }
}