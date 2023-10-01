﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xphyrus.AssesmentAPI.Data;

#nullable disable

namespace Xphyrus.AssesmentAPI.Migrations
{
    [DbContext(typeof(ApplicatioDbContext))]
    [Migration("20230926064122_FinalSchema")]
    partial class FinalSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.Assesment", b =>
                {
                    b.Property<string>("AssesmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsStrict")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AssesmentId");

                    b.ToTable("Assesments");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.AssesmentAdmins", b =>
                {
                    b.Property<string>("AssesmentAdminsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssesmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasResultDeclared")
                        .HasColumnType("bit");

                    b.HasKey("AssesmentAdminsId");

                    b.ToTable("AssesmentAdmins");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.AssesmentParticipant", b =>
                {
                    b.Property<string>("AssesmentParticipantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssesmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("HasStarted")
                        .HasColumnType("bit");

                    b.HasKey("AssesmentParticipantId");

                    b.ToTable("AssesmentParticipants");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.Coding", b =>
                {
                    b.Property<string>("CodingId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssesmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Constrain1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Constrain2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Constrain3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InputFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutputFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prompt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodingId");

                    b.HasIndex("AssesmentId");

                    b.ToTable("Coding");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.EvliationCase", b =>
                {
                    b.Property<string>("EvliationCaseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodingId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InputCase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutputCase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvliationCaseId");

                    b.HasIndex("CodingId");

                    b.ToTable("EvliationCases");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.MCQ", b =>
                {
                    b.Property<string>("MCQId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssesmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MCQId");

                    b.HasIndex("AssesmentId");

                    b.ToTable("MCQ");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.Options", b =>
                {
                    b.Property<string>("OptionsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MCQId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OptionNumber")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OptionsId");

                    b.HasIndex("MCQId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.Coding", b =>
                {
                    b.HasOne("Xphyrus.AssesmentAPI.Models.Assesment", "Assesment")
                        .WithMany("Codings")
                        .HasForeignKey("AssesmentId");

                    b.Navigation("Assesment");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.EvliationCase", b =>
                {
                    b.HasOne("Xphyrus.AssesmentAPI.Models.Coding", "Coding")
                        .WithMany("EvliationCases")
                        .HasForeignKey("CodingId");

                    b.Navigation("Coding");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.MCQ", b =>
                {
                    b.HasOne("Xphyrus.AssesmentAPI.Models.Assesment", null)
                        .WithMany("MCQs")
                        .HasForeignKey("AssesmentId");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.Options", b =>
                {
                    b.HasOne("Xphyrus.AssesmentAPI.Models.MCQ", "MCQ")
                        .WithMany("Options")
                        .HasForeignKey("MCQId");

                    b.Navigation("MCQ");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.Assesment", b =>
                {
                    b.Navigation("Codings");

                    b.Navigation("MCQs");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.Coding", b =>
                {
                    b.Navigation("EvliationCases");
                });

            modelBuilder.Entity("Xphyrus.AssesmentAPI.Models.MCQ", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
