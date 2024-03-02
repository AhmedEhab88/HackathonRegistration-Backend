﻿// <auto-generated />
using System;
using HackathonRegistration.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HackathonRegistration.Infrastructure.Migrations
{
    [DbContext(typeof(HackathonRegistrationDbContext))]
    partial class HackathonRegistrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Challenge", b =>
                {
                    b.Property<int>("ChallengeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChallengeID"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChallengeID");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Hackathon", b =>
                {
                    b.Property<int>("HackathonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HackathonID"));

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaximumNumberOfTeams")
                        .HasColumnType("int");

                    b.Property<int>("MaximumTeamSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegistrationStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HackathonID");

                    b.ToTable("Hackathons");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.HackathonChallenge", b =>
                {
                    b.Property<int>("HackathonID")
                        .HasColumnType("int");

                    b.Property<int>("ChallengeID")
                        .HasColumnType("int");

                    b.HasKey("HackathonID", "ChallengeID");

                    b.HasIndex("ChallengeID");

                    b.ToTable("HackathonChallenges");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<int>("HackathonID")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.HasIndex("HackathonID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.TeamChallenge", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<int>("ChallengeID")
                        .HasColumnType("int");

                    b.HasKey("TeamID", "ChallengeID");

                    b.HasIndex("ChallengeID");

                    b.ToTable("TeamChallenges");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Admin", b =>
                {
                    b.HasBaseType("HackathonRegistration.Domain.Models.User");

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Competitor", b =>
                {
                    b.HasBaseType("HackathonRegistration.Domain.Models.User");

                    b.Property<int>("CompetitorID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasIndex("TeamID");

                    b.HasDiscriminator().HasValue("Competitor");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.HackathonChallenge", b =>
                {
                    b.HasOne("HackathonRegistration.Domain.Models.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackathonRegistration.Domain.Models.Hackathon", "Hackathon")
                        .WithMany()
                        .HasForeignKey("HackathonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Hackathon");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Team", b =>
                {
                    b.HasOne("HackathonRegistration.Domain.Models.Hackathon", "Hackathon")
                        .WithMany("Teams")
                        .HasForeignKey("HackathonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hackathon");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.TeamChallenge", b =>
                {
                    b.HasOne("HackathonRegistration.Domain.Models.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackathonRegistration.Domain.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Competitor", b =>
                {
                    b.HasOne("HackathonRegistration.Domain.Models.Team", "Team")
                        .WithMany("Competitors")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Hackathon", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("HackathonRegistration.Domain.Models.Team", b =>
                {
                    b.Navigation("Competitors");
                });
#pragma warning restore 612, 618
        }
    }
}
