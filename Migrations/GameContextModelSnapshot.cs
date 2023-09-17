﻿// <auto-generated />
using System;
using Microgame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace microgame.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Microgame.Models.Enemy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttackPoint")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentHealthPoint")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefensePoint")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxHealthPoint")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("Microgame.Models.Equipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttackPoint")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefensePoint")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Microgame.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ArmorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttackPoint")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentHealthPoint")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefensePoint")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxHealthPoint")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long?>("WeaponId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Microgame.Models.Player", b =>
                {
                    b.HasOne("Microgame.Models.Equipment", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId");

                    b.HasOne("Microgame.Models.Equipment", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Armor");

                    b.Navigation("Weapon");
                });
#pragma warning restore 612, 618
        }
    }
}
