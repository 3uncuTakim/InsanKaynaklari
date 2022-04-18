﻿// <auto-generated />
using System;
using InsanKaynaklari.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsanKaynaklari.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220418120246_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.AdvancePayment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonelID");

                    b.ToTable("AdvancePayments");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activation")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountOfPersonel")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Debit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DebitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonelID");

                    b.ToTable("Debits");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Expense", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("CheckDocument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpenseTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ExpenseTypeID");

                    b.HasIndex("PersonelID");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.ExpenseType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpenseTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ExpenseTypes");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Leave", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndLeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveDocument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveTypeID")
                        .HasColumnType("int");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartLeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.Property<int>("TotalDaysOff")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LeaveTypeID");

                    b.HasIndex("PersonelID");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.LeaveType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("LeaveTypes");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Personel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activation")
                        .HasColumnType("bit");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.PersonelDetail", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Wage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WorkStyle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PersonelDetails");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Shift", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndOfShift")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShiftDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartOfShift")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("PersonelID");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.AdvancePayment", b =>
                {
                    b.HasOne("InsanKaynaklari.Entities.Concrete.Personel", "Personel")
                        .WithMany("AdvancePayments")
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Debit", b =>
                {
                    b.HasOne("InsanKaynaklari.Entities.Concrete.Personel", "Personel")
                        .WithMany("Debits")
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Expense", b =>
                {
                    b.HasOne("InsanKaynaklari.Entities.Concrete.ExpenseType", "ExpenseType")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsanKaynaklari.Entities.Concrete.Personel", "Personel")
                        .WithMany("Expenses")
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseType");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Leave", b =>
                {
                    b.HasOne("InsanKaynaklari.Entities.Concrete.LeaveType", "LeaveType")
                        .WithMany("Leaves")
                        .HasForeignKey("LeaveTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsanKaynaklari.Entities.Concrete.Personel", "Personel")
                        .WithMany("Leaves")
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveType");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Personel", b =>
                {
                    b.HasOne("InsanKaynaklari.Entities.Concrete.Company", "Company")
                        .WithMany("Personels")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.PersonelDetail", b =>
                {
                    b.HasOne("InsanKaynaklari.Entities.Concrete.Personel", "Personel")
                        .WithOne("PersonelDetail")
                        .HasForeignKey("InsanKaynaklari.Entities.Concrete.PersonelDetail", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Shift", b =>
                {
                    b.HasOne("InsanKaynaklari.Entities.Concrete.Personel", "Personel")
                        .WithMany("Shifts")
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Company", b =>
                {
                    b.Navigation("Personels");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.ExpenseType", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.LeaveType", b =>
                {
                    b.Navigation("Leaves");
                });

            modelBuilder.Entity("InsanKaynaklari.Entities.Concrete.Personel", b =>
                {
                    b.Navigation("AdvancePayments");

                    b.Navigation("Debits");

                    b.Navigation("Expenses");

                    b.Navigation("Leaves");

                    b.Navigation("PersonelDetail");

                    b.Navigation("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
