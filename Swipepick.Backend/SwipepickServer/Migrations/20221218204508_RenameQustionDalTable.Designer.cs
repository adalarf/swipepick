﻿// <auto-generated />
using DAL.AppDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SwipepickServer.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20221218204508_RenameQustionDalTable")]
    partial class RenameQustionDalTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.AnswerDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_1");

                    b.Property<string>("FourhAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_4");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("SecondAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_2");

                    b.Property<string>("ThirdAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_3");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("DAL.Entities.QuestionDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TestId")
                        .IsUnique();

                    b.ToTable("test_question");
                });

            modelBuilder.Entity("DAL.Entities.StudentAnswerDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_1");

                    b.Property<string>("FourhAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_4");

                    b.Property<string>("SecondAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_2");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("ThirdAnswer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer_3");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Student_Answer");
                });

            modelBuilder.Entity("DAL.Entities.StudentDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("TestId")
                        .HasColumnType("integer")
                        .HasColumnName("test_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DAL.Entities.TestDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password_salt");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("DAL.Entities.AnswerDal", b =>
                {
                    b.HasOne("DAL.Entities.QuestionDal", "Question")
                        .WithOne("Answers")
                        .HasForeignKey("DAL.Entities.AnswerDal", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("DAL.Entities.QuestionDal", b =>
                {
                    b.HasOne("DAL.Entities.TestDal", "Test")
                        .WithOne("Question")
                        .HasForeignKey("DAL.Entities.QuestionDal", "TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("DAL.Entities.StudentAnswerDal", b =>
                {
                    b.HasOne("DAL.Entities.StudentDal", "Student")
                        .WithOne("StudentAnswers")
                        .HasForeignKey("DAL.Entities.StudentAnswerDal", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DAL.Entities.StudentDal", b =>
                {
                    b.HasOne("DAL.Entities.TestDal", "Test")
                        .WithMany("Students")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.TestDal", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Tests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.QuestionDal", b =>
                {
                    b.Navigation("Answers")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.StudentDal", b =>
                {
                    b.Navigation("StudentAnswers")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.TestDal", b =>
                {
                    b.Navigation("Question")
                        .IsRequired();

                    b.Navigation("Students");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
