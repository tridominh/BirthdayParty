/*using System;
using System.Collections.Generic;
using BirthdayParty.Models;
using BirthdayParty.Models.OnlineImages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BirthdayParty.DAL;

public partial class BookingPartyOnlineContext :IdentityDbContext<User, Role, int>
{
    public BookingPartyOnlineContext()
    {
    }

    public BookingPartyOnlineContext(DbContextOptions<BookingPartyContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingService> BookingServices { get; set; }
    public virtual DbSet<Packages> Packages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<PackageImageOnline> PackageImages { get; set; }

    public virtual DbSet<ServiceImageOnline> ServiceImages { get; set; }

    public virtual DbSet<RoomImageOnline> RoomImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Database=BookingParty;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BookingService>()
            .HasOne(f => f.Service)
            .WithMany(u => u.BookingServices)
            .HasForeignKey(f => f.ServiceId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Payment>()
           .HasOne(f => f.Booking)
           .WithMany(u => u.Payments)
           .HasForeignKey(f => f.BookingId)
           .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Booking>()
           .HasOne(f => f.Room)
           .WithMany(u => u.Bookings)
           .HasForeignKey(f => f.RoomId)
           .OnDelete(DeleteBehavior.NoAction);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}*/
