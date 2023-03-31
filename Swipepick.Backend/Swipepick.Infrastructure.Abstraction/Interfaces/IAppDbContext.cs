using Microsoft.EntityFrameworkCore;
using Swipepick.Domain;

namespace Swipepick.Infrastructure.Abstraction.Interfaces;

public interface IAppDbContext : IDbContextWithSets, IDisposable
{
    DbSet<User> Users { get; }

    DbSet<Test> Tests { get; }

    DbSet<Answer> Answers { get; }

    DbSet<StudentAnswer> StudentAnswers { get; }

    DbSet<Student> Students { get; }

    DbSet<Question> Questions { get; }
}
