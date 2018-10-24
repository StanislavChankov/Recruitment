﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Synergy.Recruitment.Data.Data;
using System;

namespace Synergy.Recruitment.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181024052652_base_schema")]
    partial class base_schema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Candidate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CandidateInfoId");

                    b.Property<bool>("IsCurrent");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CandidateInfoId");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.CandidateCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CandidateId");

                    b.Property<long>("CompanyId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CandidateCompany");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.CandidateInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<long>("CityId");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CandidateInfo");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.CandidateJobAdvertisment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CandidateId");

                    b.Property<long>("JobAdvertismentId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobAdvertismentId");

                    b.ToTable("CandidateJobAdvertisment");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("WebsiteUrl");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Interview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CandidateId");

                    b.Property<long>("InterviewTypeId");

                    b.Property<DateTime>("StartUtcDate");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("InterviewTypeId");

                    b.ToTable("Interview");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.InterviewType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("InterviewType");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.JobAdvertisement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<long>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("JobAdvertisement");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.OrganizationProcess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("OrganizationId");

                    b.Property<long>("ProcessId");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("OrganizationProcess");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DepartmentId");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Process", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Technology", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Technology");
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Candidate", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.CandidateInfo", "CandidateInfo")
                        .WithMany("Candidates")
                        .HasForeignKey("CandidateInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.CandidateCompany", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.Candidate", "Candidate")
                        .WithMany("CandidateCompanies")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Synergy.Recruitment.Data.Models.Company", "Company")
                        .WithMany("CandidateCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.CandidateInfo", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.City", "City")
                        .WithMany("CandidateInfos")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.CandidateJobAdvertisment", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.Candidate", "Candidate")
                        .WithMany("CandidateJobAdvertisments")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Synergy.Recruitment.Data.Models.JobAdvertisement", "JobAdvertisment")
                        .WithMany("CandidateJobAdvertisments")
                        .HasForeignKey("JobAdvertismentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.City", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Interview", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.Candidate", "Candidate")
                        .WithMany("Interviews")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Synergy.Recruitment.Data.Models.InterviewType", "InterviewType")
                        .WithMany("Interviews")
                        .HasForeignKey("InterviewTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.JobAdvertisement", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.Position", "Position")
                        .WithMany("JobAdvertisments")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.OrganizationProcess", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.Process", "Process")
                        .WithMany("OrganizationProcesses")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Synergy.Recruitment.Data.Models.Position", b =>
                {
                    b.HasOne("Synergy.Recruitment.Data.Models.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
