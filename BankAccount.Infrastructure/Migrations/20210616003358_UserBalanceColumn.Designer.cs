﻿// <auto-generated />
using System;
using BankAccount.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankAccount.Infrastructure.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20210616003358_UserBalanceColumn")]
    partial class UserBalanceColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("BankAccount.Domain.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("BankAccount.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Destination")
                        .HasColumnType("longtext");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BankAccount.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankAccount.Domain.Entities.Withdraw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("Withdrawals");
                });

            modelBuilder.Entity("BankAccount.Domain.Entities.Deposit", b =>
                {
                    b.HasOne("BankAccount.Domain.Entities.User", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId");

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("BankAccount.Domain.Entities.Payment", b =>
                {
                    b.HasOne("BankAccount.Domain.Entities.User", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("BankAccount.Domain.Entities.Withdraw", b =>
                {
                    b.HasOne("BankAccount.Domain.Entities.User", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.Navigation("Source");
                });
#pragma warning restore 612, 618
        }
    }
}
