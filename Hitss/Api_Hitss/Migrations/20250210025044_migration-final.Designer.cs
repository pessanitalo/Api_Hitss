﻿// <auto-generated />
using Api_Hitss.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_Hitss.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250210025044_migration-final")]
    partial class migrationfinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api_Hitss.Model.PaymentFlowSummary", b =>
                {
                    b.Property<int>("PaymentFlowSummary_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentFlowSummary_Id"));

                    b.Property<decimal>("MonthlyPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalInterest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPayment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PaymentFlowSummary_Id");

                    b.ToTable("PaymentFlowSummary", (string)null);
                });

            modelBuilder.Entity("Api_Hitss.Model.PaymentSchedule", b =>
                {
                    b.Property<int>("PaymentSchedule_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentSchedule_Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("PaymentFlowSummary_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Principal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PaymentSchedule_Id");

                    b.HasIndex("PaymentFlowSummary_Id");

                    b.ToTable("PaymentSchedule");
                });

            modelBuilder.Entity("Api_Hitss.Model.Proposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AnnualInterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberOfMonths")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Proposta");
                });

            modelBuilder.Entity("Api_Hitss.Model.PaymentSchedule", b =>
                {
                    b.HasOne("Api_Hitss.Model.PaymentFlowSummary", "PaymentFlowSummary")
                        .WithMany("PaymentSchedule")
                        .HasForeignKey("PaymentFlowSummary_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentFlowSummary");
                });

            modelBuilder.Entity("Api_Hitss.Model.PaymentFlowSummary", b =>
                {
                    b.Navigation("PaymentSchedule");
                });
#pragma warning restore 612, 618
        }
    }
}
