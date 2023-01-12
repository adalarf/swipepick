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
    [Migration("20230112200501_AddColumn")]
    partial class AddColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Dal.QuestionDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "qustion_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "question");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Test_question");
                });

            modelBuilder.Entity("DAL.Entities.Dal.StudentAnswerDal", b =>
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

                    b.HasIndex("StudentId");

                    b.ToTable("Student_Answer");
                });

            modelBuilder.Entity("DAL.Entities.Dal.StudentDal", b =>
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

            modelBuilder.Entity("DAL.Entities.Dal.TestDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "test_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url")
                        .HasAnnotation("Relational:JsonPropertyName", "test_url");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .HasAnnotation("Relational:JsonPropertyName", "user_id");

                    b.HasKey("Id");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("DAL.Entities.Dal.User", b =>
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

            modelBuilder.Entity("DAL.Entities.Dal.QuestionDal", b =>
                {
                    b.HasOne("DAL.Entities.Dal.TestDal", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("DAL.Entities.Dal.AnswerDal", "Answers", b1 =>
                        {
                            b1.Property<int>("QuestionId")
                                .HasColumnType("integer")
                                .HasAnnotation("Relational:JsonPropertyName", "question_id");

                            b1.Property<int>("CorrectAnswer")
                                .HasColumnType("integer")
                                .HasColumnName("correct_ans")
                                .HasAnnotation("Relational:JsonPropertyName", "correct");

                            b1.Property<string>("FirstAnswer")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("answer_1")
                                .HasAnnotation("Relational:JsonPropertyName", "answer_1");

                            b1.Property<string>("FourhAnswer")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("answer_4")
                                .HasAnnotation("Relational:JsonPropertyName", "answer_4");

                            b1.Property<int>("Id")
                                .HasColumnType("integer")
                                .HasAnnotation("Relational:JsonPropertyName", "answer_id");

                            b1.Property<string>("SecondAnswer")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("answer_2")
                                .HasAnnotation("Relational:JsonPropertyName", "answer_2");

                            b1.Property<int>("TestId")
                                .HasColumnType("integer")
                                .HasAnnotation("Relational:JsonPropertyName", "test_id");

                            b1.Property<string>("ThirdAnswer")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("answer_3")
                                .HasAnnotation("Relational:JsonPropertyName", "answer_3");

                            b1.HasKey("QuestionId");

                            b1.ToTable("Answer");

                            b1.WithOwner("Question")
                                .HasForeignKey("QuestionId");

                            b1.Navigation("Question");
                        });

                    b.Navigation("Answers")
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("DAL.Entities.Dal.StudentAnswerDal", b =>
                {
                    b.HasOne("DAL.Entities.Dal.StudentDal", "Student")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DAL.Entities.Dal.StudentDal", b =>
                {
                    b.HasOne("DAL.Entities.Dal.TestDal", "Test")
                        .WithMany("Students")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Dal.User", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Dal.TestDal", b =>
                {
                    b.HasOne("DAL.Entities.Dal.User", "User")
                        .WithMany("Tests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Dal.StudentDal", b =>
                {
                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("DAL.Entities.Dal.TestDal", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("DAL.Entities.Dal.User", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
