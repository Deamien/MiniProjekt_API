﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProjekt_API.Data;

#nullable disable

namespace MiniProjekt_API.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240417195023_Changed_InterestLinks_to_InterestUrls")]
    partial class Changed_InterestLinks_to_InterestUrls
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InterestsPeople", b =>
                {
                    b.Property<int>("InterestssId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleeId")
                        .HasColumnType("int");

                    b.HasKey("InterestssId", "PeopleeId");

                    b.HasIndex("PeopleeId");

                    b.ToTable("InterestsPeople");
                });

            modelBuilder.Entity("MiniProjekt_API.Models.InterestUrls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InterestssId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleeId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestssId");

                    b.HasIndex("PeopleeId");

                    b.ToTable("InterestUrls");
                });

            modelBuilder.Entity("MiniProjekt_API.Models.Interests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("MiniProjekt_API.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("InterestsPeople", b =>
                {
                    b.HasOne("MiniProjekt_API.Models.Interests", null)
                        .WithMany()
                        .HasForeignKey("InterestssId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniProjekt_API.Models.People", null)
                        .WithMany()
                        .HasForeignKey("PeopleeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniProjekt_API.Models.InterestUrls", b =>
                {
                    b.HasOne("MiniProjekt_API.Models.Interests", "Interestss")
                        .WithMany("InterestUrlss")
                        .HasForeignKey("InterestssId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniProjekt_API.Models.People", "Peoplee")
                        .WithMany()
                        .HasForeignKey("PeopleeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interestss");

                    b.Navigation("Peoplee");
                });

            modelBuilder.Entity("MiniProjekt_API.Models.Interests", b =>
                {
                    b.Navigation("InterestUrlss");
                });
#pragma warning restore 612, 618
        }
    }
}
