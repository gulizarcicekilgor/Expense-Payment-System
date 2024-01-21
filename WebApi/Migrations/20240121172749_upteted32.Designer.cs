﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(emsDbContext))]
    [Migration("20240121172749_upteted32")]
    partial class upteted32
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Data.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<double?>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CurrencyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EftTransactionId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("EftTransactionId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebApi.Data.Entities.EftTransaction", b =>
                {
                    b.Property<int>("EftTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EftTransactionId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverIban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EftTransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("WebApi.Data.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExpenseExpenceId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ExpenseExpenceId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApi.Data.Entities.Expense", b =>
                {
                    b.Property<int>("ExpenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenceId"));

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Pending Approval");

                    b.HasKey("ExpenceId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("WebApi.Data.Entities.Account", b =>
                {
                    b.HasOne("WebApi.Data.Entities.EftTransaction", null)
                        .WithMany("Accounts")
                        .HasForeignKey("EftTransactionId");
                });

            modelBuilder.Entity("WebApi.Data.Entities.Employee", b =>
                {
                    b.HasOne("WebApi.Data.Entities.Account", null)
                        .WithMany("Employees")
                        .HasForeignKey("AccountId");

                    b.HasOne("WebApi.Data.Entities.Expense", null)
                        .WithMany("Employees")
                        .HasForeignKey("ExpenseExpenceId");
                });

            modelBuilder.Entity("WebApi.Data.Entities.Account", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WebApi.Data.Entities.EftTransaction", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("WebApi.Data.Entities.Expense", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}