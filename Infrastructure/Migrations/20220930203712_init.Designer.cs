// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BookingMicroServiceDbContext))]
    [Migration("20220930203712_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payment", (string)null);

                    b.HasData(
                        new
                        {
                            PaymentId = 1,
                            Type = "EFECTIVO"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Request", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Aprove")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("RequestId");

                    b.ToTable("Request", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Reserve", b =>
                {
                    b.Property<Guid>("ReserveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DayTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.HasKey("ReserveId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("Reserve", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.HasKey("TicketId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Reserve", b =>
                {
                    b.HasOne("Domain.Entities.Payment", "Payment")
                        .WithMany("Reserves")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Request", "Request")
                        .WithOne("Reserve")
                        .HasForeignKey("Domain.Entities.Reserve", "RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Payment", "Payment")
                        .WithMany("Tickets")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.Navigation("Reserves");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Request", b =>
                {
                    b.Navigation("Reserve")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
