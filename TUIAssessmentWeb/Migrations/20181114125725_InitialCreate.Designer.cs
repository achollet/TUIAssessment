﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TUIAssessment.DAL;

namespace TUIAssessment.Web.Migrations
{
    [DbContext(typeof(TUIAssessmentDALContext))]
    [Migration("20181114125725_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("TUIAssessment.DAL.Entities.AirportEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .HasName("IDX_Airport_Code");

                    b.HasIndex("Id")
                        .HasName("IDX_Airport_Id");

                    b.ToTable("Airports");

                    b.HasData(
                        new { Id = 1, Code = "CDG", Latitude = 49.009642, Longitude = 2.547885, Name = "Paris-Charles De Gaulle" },
                        new { Id = 2, Code = "MXP", Latitude = 45.629646, Longitude = 8.724174, Name = "Milan-Malpensa" },
                        new { Id = 3, Code = "LHR", Latitude = 51.472401, Longitude = -0.467262, Name = "London-Heathrow" },
                        new { Id = 4, Code = "AMS", Latitude = 52.31488, Longitude = 4.757767, Name = "Amsterdam-Schipol" },
                        new { Id = 5, Code = "FRA", Latitude = 50.035313, Longitude = 8.559723, Name = "Frankfurt-Airport" },
                        new { Id = 6, Code = "JFK", Latitude = 40.64444, Longitude = -73.778, Name = "New-York-John F. Kennedy" },
                        new { Id = 7, Code = "LAX", Latitude = 33.941154, Longitude = -118.409447, Name = "Los Angeles International Airport" },
                        new { Id = 8, Code = "ATL", Latitude = 33.635899, Longitude = -84.428719, Name = "Atlanta-Hartsfield-Jackson" },
                        new { Id = 9, Code = "YUL", Latitude = 45.470604, Longitude = -73.744354, Name = "Montreal-Trudeau" },
                        new { Id = 10, Code = "YVR", Latitude = 49.192398, Longitude = -123.179596, Name = "Vancouver Airport" },
                        new { Id = 11, Code = "EZE", Latitude = -34.812111, Longitude = -58.539619, Name = "Buenos Aires-Pistarini" },
                        new { Id = 12, Code = "SJO", Latitude = 9.957228, Longitude = -84.139236, Name = "San Jose Airport" },
                        new { Id = 13, Code = "GIG", Latitude = -22.910809, Longitude = -43.163223, Name = "Rio De Janeiro International Airport" },
                        new { Id = 14, Code = "RUH", Latitude = 24.954332, Longitude = 46.700993, Name = "Riyad King Kahild International Airport" },
                        new { Id = 15, Code = "DOH", Latitude = 25.261309, Longitude = 51.562614, Name = "Doha International Airport" },
                        new { Id = 16, Code = "PVG", Latitude = 31.144997, Longitude = 121.811371, Name = "Shanghai Pudong International Airport" },
                        new { Id = 17, Code = "ICN", Latitude = 37.471603, Longitude = 126.455666, Name = "Seoul Incheon Airport" },
                        new { Id = 18, Code = "HND", Latitude = 35.554993, Longitude = 139.780258, Name = "Tokyo Haneda Airport" },
                        new { Id = 19, Code = "SYD", Latitude = -33.94997, Longitude = 151.178482, Name = "Sydney Airport" },
                        new { Id = 20, Code = "JNB", Latitude = -26.12314, Longitude = 28.243365, Name = "Johanesburg- OR Tambo International Airport" }
                    );
                });

            modelBuilder.Entity("TUIAssessment.DAL.Entities.FlightEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArrivalAirportId");

                    b.Property<DateTime>("Creation");

                    b.Property<int>("DepartureAirportId");

                    b.Property<double>("Distance");

                    b.Property<double>("FuelQuantity");

                    b.Property<double>("TimeOfFlight");

                    b.Property<DateTime>("Update");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("IDX_Flight_ID");

                    b.HasIndex("DepartureAirportId", "ArrivalAirportId")
                        .HasName("IDX_Flight_Departure_Arrival");

                    b.ToTable("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
