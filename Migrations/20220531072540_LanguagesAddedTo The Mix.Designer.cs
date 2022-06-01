﻿// <auto-generated />
using EF_test_01.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_test_01.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220531072540_LanguagesAddedTo The Mix")]
    partial class LanguagesAddedToTheMix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF_test_01.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Bucharest"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Brasov"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Timisoara"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Warsaw"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Krakow"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 2,
                            Name = "Bolowitze"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 3,
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 3,
                            Name = "Göteborg"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 3,
                            Name = "Malmö"
                        });
                });

            modelBuilder.Entity("EF_test_01.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Romania"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Polen"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("EF_test_01.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Romanian"
                        },
                        new
                        {
                            Id = 2,
                            Name = "French"
                        },
                        new
                        {
                            Id = 3,
                            Name = "German"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Swedish"
                        },
                        new
                        {
                            Id = 5,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("EF_test_01.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Josh Gomez",
                            PhoneNumber = "123 456"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Miguel Alonso",
                            PhoneNumber = "234 567"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "Andreas Kvarnblom",
                            PhoneNumber = "345 678"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Name = "Tore Kindwall",
                            PhoneNumber = "456 789"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 2,
                            Name = "Helena Danielsson",
                            PhoneNumber = "567 890"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 2,
                            Name = "Maria Persson",
                            PhoneNumber = "678 901"
                        });
                });

            modelBuilder.Entity("EF_test_01.Models.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 1,
                            LanguageId = 2
                        },
                        new
                        {
                            PersonId = 1,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 2,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 2,
                            LanguageId = 4
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 5
                        },
                        new
                        {
                            PersonId = 4,
                            LanguageId = 4
                        },
                        new
                        {
                            PersonId = 5,
                            LanguageId = 4
                        },
                        new
                        {
                            PersonId = 6,
                            LanguageId = 4
                        });
                });

            modelBuilder.Entity("EF_test_01.Models.City", b =>
                {
                    b.HasOne("EF_test_01.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_test_01.Models.Person", b =>
                {
                    b.HasOne("EF_test_01.Models.City", "City")
                        .WithMany("Residents")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_test_01.Models.PersonLanguage", b =>
                {
                    b.HasOne("EF_test_01.Models.Language", "Langauge")
                        .WithMany("PersonLanguage")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_test_01.Models.Person", "Person")
                        .WithMany("PersonLanguage")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
