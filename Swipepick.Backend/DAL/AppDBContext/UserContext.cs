using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.AppDBContext
{
    public class UserContext : DbContext
    {
        private readonly DalSetting _setting;

        public DbSet<User> Users { get; set; }

        public DbSet<TestDal> Tests { get; set; }

        public DbSet<AnswerDal> Answers { get; set; }

        public DbSet<StudentAnswerDal> StudentAnswers { get; set; }

        public DbSet<StudentDal> Students { get; set; }

        public DbSet<QuestionDal> Questions { get; set; }

        public UserContext(DalSetting setting)
        {
            _setting = setting;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestDal>()
                .HasOne(owner => owner.User)
                .WithMany(user => user.Tests)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnswerDal>()
                .HasOne(b => b.Question)
                .WithOne(c => c.Answers);

            modelBuilder.Entity<QuestionDal>()
                .HasOne(b => b.Test)
                .WithMany(c => c.Questions)
                .HasForeignKey(fk => fk.TestId);

            modelBuilder.Entity<StudentAnswerDal>()
                .HasOne(b => b.Student)
                .WithMany(c => c.StudentAnswers)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<StudentDal>()
                .HasOne(owner => owner.User)
                .WithMany(user => user.Students)
                .HasForeignKey(fk => fk.UserId);

            modelBuilder.Entity<StudentDal>()
                .HasOne(owner => owner.Test)
                .WithMany(test => test.Students)
                .HasForeignKey(fk => fk.TestId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_setting.ConnectionString, b => b.MigrationsAssembly("SwipepickServer"));
        }
    }
}
