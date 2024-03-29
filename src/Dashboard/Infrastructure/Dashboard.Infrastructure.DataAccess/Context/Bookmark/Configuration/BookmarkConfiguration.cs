// ------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой EngineApp Tamerlan I.V.
//     Изменения в этом файле могут привести к неправильной работе
//     и будут потеряны в случае повторного создания кода.
// </auto-generated>
// ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.DataAccess.Contexts.Bookmark.Configuration
{
    /// <summary>
    /// Конфигурация таблицы Bookmarks.
    /// </summary>
    internal class BookmarkConfiguration : IEntityTypeConfiguration<Domain.Bookmarks.Bookmark>
    {
        public void Configure(EntityTypeBuilder<Domain.Bookmarks.Bookmark> builder)
        {
            builder.ToTable(nameof(Domain.Bookmarks.Bookmark));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}


