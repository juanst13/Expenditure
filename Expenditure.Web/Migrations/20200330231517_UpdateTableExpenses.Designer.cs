﻿// <auto-generated />
using System;
using Expenditure.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Expenditure.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200330231517_UpdateTableExpenses")]
    partial class UpdateTableExpenses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Expenditure.Web.Data.Entities.EmployeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhotoPath")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Expenditure.Web.Data.Entities.ExpenditureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpenditureDate");

                    b.Property<string>("ExpenseType")
                        .IsRequired();

                    b.Property<int>("ExpenseValue");

                    b.Property<string>("PhotoPath");

                    b.Property<int?>("TravelsId");

                    b.HasKey("Id");

                    b.HasIndex("TravelsId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Expenditure.Web.Data.Entities.TravelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<int?>("EmployeesId");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Observation");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("City");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Expenditure.Web.Data.Entities.ExpenditureEntity", b =>
                {
                    b.HasOne("Expenditure.Web.Data.Entities.TravelEntity", "Travels")
                        .WithMany("Expenses")
                        .HasForeignKey("TravelsId");
                });

            modelBuilder.Entity("Expenditure.Web.Data.Entities.TravelEntity", b =>
                {
                    b.HasOne("Expenditure.Web.Data.Entities.EmployeeEntity", "Employees")
                        .WithMany("Travels")
                        .HasForeignKey("EmployeesId");
                });
#pragma warning restore 612, 618
        }
    }
}
