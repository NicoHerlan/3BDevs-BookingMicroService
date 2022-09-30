using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class BookingMicroServiceDbContext : DbContext
    {
        //ENTITIES
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        
        //constructor
        public BookingMicroServiceDbContext(DbContextOptions<BookingMicroServiceDbContext> options) : base(options) { }

        //MODELADO -> FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PAYMENT
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");
                entity.HasKey(p => p.PaymentId);
                entity.Property(p => p.PaymentId).ValueGeneratedOnAdd();
                entity.HasData(
                    new Payment
                    {
                        PaymentId = 1,
                        Type = "EFECTIVO",
                    });

                //RELACION: Ticket
            });
            
            //TICKET
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");
                entity.HasKey(t => t.TicketId);

                //RELACION: Payment
                entity
                    .HasOne<Payment>(t => t.Payment)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(t => t.PaymentId);
            });

            //REQUEST
            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");
                entity.HasKey(r => r.RequestId);

                //RELACION: Reserve
            });

            //RESERVE
            modelBuilder.Entity<Reserve>(entity =>
            {
                entity.ToTable("Reserve");
                entity.HasKey(r => r.ReserveId);

                //RELACION: Payment-Request
                entity
                    .HasOne<Payment>(r => r.Payment)
                    .WithMany(p => p.Reserves);
                entity
                    .HasOne<Request>(r => r.Request)
                    .WithOne(r => r.Reserve)
                    .HasForeignKey<Request>(r => r.RequestId);
            });
        }
    }
}
