// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Tag.Configuration
{
    /// <summary>
    /// Конфигурация таблицы Tags.
    /// </summary>
    internal class TagConfiguration : IEntityTypeConfiguration<Domain.Tags.Tag>
    {
        public void Configure(EntityTypeBuilder<Domain.Tags.Tag> builder)
        {
            builder.ToTable(nameof(Domain.Tags.Tag));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}


