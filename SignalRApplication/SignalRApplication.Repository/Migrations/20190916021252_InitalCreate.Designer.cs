﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalRApplication.Repository;

namespace SignalRApplication.Repository.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20190916021252_InitalCreate")]
    partial class InitalCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("SignalRApplication.DTO.FriendShip", b =>
                {
                    b.Property<int>("friendship_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("create_at");

                    b.Property<DateTime>("delete_at");

                    b.Property<DateTime>("established_date");

                    b.Property<string>("personid_1")
                        .HasMaxLength(20);

                    b.Property<string>("personid_2")
                        .HasMaxLength(20);

                    b.HasKey("friendship_id");

                    b.ToTable("FriendShip");
                });

            modelBuilder.Entity("SignalRApplication.DTO.Message", b =>
                {
                    b.Property<int>("idmessage")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("create_at");

                    b.Property<DateTime?>("delete_at");

                    b.Property<string>("iduser_receive")
                        .HasMaxLength(20);

                    b.Property<string>("iduser_send")
                        .HasMaxLength(20);

                    b.Property<string>("message");

                    b.HasKey("idmessage");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("SignalRApplication.DTO.MessageRoom", b =>
                {
                    b.Property<int>("idmessage")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("create_at");

                    b.Property<DateTime?>("delete_at");

                    b.Property<string>("idroom")
                        .HasMaxLength(32);

                    b.Property<string>("iduser_send")
                        .HasMaxLength(20);

                    b.Property<string>("message");

                    b.HasKey("idmessage");

                    b.ToTable("MessageRoom");
                });

            modelBuilder.Entity("SignalRApplication.DTO.Room", b =>
                {
                    b.Property<string>("idroom")
                        .HasMaxLength(32);

                    b.Property<string>("iduser")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("create_at");

                    b.Property<DateTime?>("delete_at");

                    b.Property<string>("display_name")
                        .IsRequired();

                    b.Property<int>("series")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("update_at");

                    b.HasKey("idroom", "iduser");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("SignalRApplication.DTO.User", b =>
                {
                    b.Property<string>("iduser")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("active");

                    b.Property<DateTime?>("create_at");

                    b.Property<DateTime?>("delete_at");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime?>("update_at");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("iduser");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}