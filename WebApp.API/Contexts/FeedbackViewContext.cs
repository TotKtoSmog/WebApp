using Microsoft.EntityFrameworkCore;
using WebApp.API.Models;

namespace WebApp.API.Contexts
{
    public class FeedbackViewContext : DbContext
    {
        public FeedbackViewContext(DbContextOptions<FeedbackViewContext> options)
            : base(options)
        {
        }
        private FeedbackViewContext() => Database.EnsureCreated();

        public DbSet<FeedbackView> Feedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedbackView>(entity =>
            {
                entity.ToView("feedback_view");
                entity.Property("Id").HasColumnName("id");
                entity.Property("IdLocation").HasColumnName("id_location");
                entity.Property("SenderName").HasColumnName("namesender");
                entity.Property("Text").HasColumnName("textfeedback");
                entity.Property("Ball").HasColumnName("ball");
                entity.Property("Accepted").HasColumnName("accepted");
                entity.Property("DateOfPublication").HasColumnName("datetime");
            });
        }
    }
}
