﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBudget.Models.DatabaseContexts;

namespace MyBudget.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190709120650_BoolFields")]
    partial class BoolFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBudget.Models.BankAccount", b =>
                {
                    b.Property<int>("BankAccountID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<decimal>("Balance");

                    b.Property<string>("BankName");

                    b.Property<decimal>("DebitLimit");

                    b.HasKey("BankAccountID");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("MyBudget.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Type");

                    b.HasKey("ExpenseID");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("MyBudget.Models.Income", b =>
                {
                    b.Property<int>("IncomeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Received");

                    b.Property<string>("Type");

                    b.HasKey("IncomeID");

                    b.ToTable("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
