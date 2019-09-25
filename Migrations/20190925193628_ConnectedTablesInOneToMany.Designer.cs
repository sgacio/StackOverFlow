﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using stackoverflow;

namespace sdgreacttemplate.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190925193628_ConnectedTablesInOneToMany")]
    partial class ConnectedTablesInOneToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.ToTable("AnswerPosts");
                });

            modelBuilder.Entity("StackOverFlow.Models.QuestionPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswersPostId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateOfPost");

                    b.Property<int>("PraisesForMyQuestionRelevance");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.HasIndex("AnswersPostId");

                    b.ToTable("QuestionPosts");
                });

            modelBuilder.Entity("StackOverFlow.Models.QuestionPost", b =>
                {
                    b.HasOne("StackOverFlow.Models.AnswersPost", "AnswersPost")
                        .WithMany()
                        .HasForeignKey("AnswersPostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}