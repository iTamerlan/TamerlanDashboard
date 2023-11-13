// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Comment.Configuration
{
    /// <summary>
    /// Конфигурация таблицы Comments.
    /// </summary>
    internal class PostConfiguration : IEntityTypeConfiguration<Domain.Comments.Comment>
    {
        public void Configure(EntityTypeBuilder<Domain.Comments.Comment> builder)
        {
            builder.ToTable(nameof(Domain.Comments.Comment));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}

