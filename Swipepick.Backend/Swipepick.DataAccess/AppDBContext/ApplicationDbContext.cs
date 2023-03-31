using Microsoft.EntityFrameworkCore;
using Swipepick.Domain;
using Swipepick.Infrastructure.Abstraction.Interfaces;

namespace Swipepick.DataAccess.AppDBContext;

public class ApplicationDbContext : DbContext, IAppDbContext
{
    private readonly DalSetting _setting;

    public DbSet<User> Users { get; set; }

    public DbSet<Test> Tests { get; set; }

    public DbSet<Answer> Answers { get; set; }

    public DbSet<StudentAnswer> StudentAnswers { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Question> Questions { get; set; }

    public ApplicationDbContext(DalSetting setting)
    {
        _setting = setting;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>()
            .HasMany(que => que.Answers)
            .WithOne(answ => answ.Question);

        modelBuilder.Entity<Test>()
            .HasOne(owner => owner.User)
            .WithMany(user => user.Tests)
            .HasForeignKey(fk => fk.UserId);
        modelBuilder.Entity<Test>().Property(test => test.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Test>().HasIndex(test => test.UniqueCode).IsUnique();

        modelBuilder.Entity<Question>()
            .HasOne(b => b.Test)
            .WithMany(c => c.Questions)
            .HasForeignKey(fk => fk.TestId);
        modelBuilder.Entity<Question>().Property(que => que.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<StudentAnswer>()
            .HasOne(b => b.Student)
            .WithMany(c => c.StudentAnswers)
            .HasForeignKey(g => g.StudentId);
        modelBuilder.Entity<StudentAnswer>().Property(sa => sa.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>()
            .HasOne(user => user.User)
            .WithMany(user => user.Students)
            .HasForeignKey(fk => fk.UserId);
        modelBuilder.Entity<Student>().Property(student => student.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>()
            .HasMany(student => student.Tests)
            .WithMany(test => test.Students);

        modelBuilder.Entity<User>()
            .HasIndex(user => user.Email).IsUnique();

        modelBuilder.Entity<Answer>()
            .HasMany(a => a.AnswerVariants)
            .WithOne(v => v.Answer);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_setting.ConnectionString, b => b.MigrationsAssembly("Swipepick.DataAccess"));
    }
}
