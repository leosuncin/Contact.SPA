﻿// <auto-generated />
using System;
using Contact.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Contact.SPA.Migrations
{
    [DbContext(typeof(ContactContext))]
    partial class ContactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Contact.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("state")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnName("street_address")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Suite")
                        .HasColumnName("suite")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id")
                        .HasName("pk_addresses");

                    b.HasIndex("PersonId")
                        .HasName("ix_addresses_person_id");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("Contact.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_emails");

                    b.HasIndex("PersonId")
                        .HasName("ix_emails_person_id");

                    b.ToTable("emails");
                });

            modelBuilder.Entity("Contact.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnName("age")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_people");

                    b.ToTable("people");
                });

            modelBuilder.Entity("Contact.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PersonId")
                        .HasColumnName("person_id")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("phone_number")
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.HasKey("Id")
                        .HasName("pk_phone_numbers");

                    b.HasIndex("PersonId")
                        .HasName("ix_phone_numbers_person_id");

                    b.ToTable("phone_numbers");
                });

            modelBuilder.Entity("Contact.Models.Address", b =>
                {
                    b.HasOne("Contact.Models.Person", null)
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("fk_addresses_people_person_id");
                });

            modelBuilder.Entity("Contact.Models.Email", b =>
                {
                    b.HasOne("Contact.Models.Person", null)
                        .WithMany("EmailAddresses")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("fk_emails_people_person_id");
                });

            modelBuilder.Entity("Contact.Models.Phone", b =>
                {
                    b.HasOne("Contact.Models.Person", null)
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("fk_phone_numbers_people_person_id");
                });
#pragma warning restore 612, 618
        }
    }
}
