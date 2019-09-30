﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using stackoverflow;

namespace sdgreacttemplate.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StackOverFlow.Models.AnswersPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerContent");

                    b.Property<DateTime>("DateOfPost");

                    b.Property<int>("PraisesForMyAnswer");

                    b.Property<int?>("QuestionPostId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionPostId");

                    b.ToTable("AnswerPosts");
                });

            modelBuilder.Entity("StackOverFlow.Models.QuestionPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateOfPost");

                    b.Property<int>("PraisesForMyQuestionRelevance");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.ToTable("QuestionPosts");
                });

            modelBuilder.Entity("StackOverFlow.Models.AnswersPost", b =>
                {
                    b.HasOne("StackOverFlow.Models.QuestionPost")
                        .WithMany("AnswersPosts")
                        .HasForeignKey("QuestionPostId");
                });
#pragma warning restore 612, 618
        }
    }
}
