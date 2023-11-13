using Dashboard.Infrastructure.DataAccess.Contexts.Bidding.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Bookmark.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Category.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Comment.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Community.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Feedback.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.History.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Post.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Product.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Tag.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.User.Configuration;
using Dashboard.Infrastructure.DataAccess.Contexts.Voting.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.DataAccess
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BiddingConfiguration());
            modelBuilder.ApplyConfiguration(new BookmarkConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CommunityConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VotingConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
