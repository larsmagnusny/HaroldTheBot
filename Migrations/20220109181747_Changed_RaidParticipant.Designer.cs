﻿// <auto-generated />
using System;
using HaroldTheBot.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HaroldTheBot.Migrations
{
    [DbContext(typeof(HaroldDbContext))]
    [Migration("20220109181747_Changed_RaidParticipant")]
    partial class Changed_RaidParticipant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("HaroldTheBot.Data.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("HaroldTheBot.Data.Entities.RaidEvent", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ChannelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DPSLimit")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EventStart")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Expired")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HealerLimit")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Notified")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TankLimit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RaidEvents");
                });

            modelBuilder.Entity("HaroldTheBot.Data.Entities.RaidParticipant", b =>
                {
                    b.Property<ulong>("RaidEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("RaidEventId1")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("RaidEventId");

                    b.HasIndex("JobId");

                    b.HasIndex("RaidEventId1");

                    b.ToTable("RaidParticipants");
                });

            modelBuilder.Entity("HaroldTheBot.Data.Entities.RaidParticipant", b =>
                {
                    b.HasOne("HaroldTheBot.Data.Entities.Job", "Role")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HaroldTheBot.Data.Entities.RaidEvent", "RaidEvent")
                        .WithMany("Participants")
                        .HasForeignKey("RaidEventId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaidEvent");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HaroldTheBot.Data.Entities.RaidEvent", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
