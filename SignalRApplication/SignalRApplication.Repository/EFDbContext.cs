using Microsoft.EntityFrameworkCore;
using SignalRApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        //public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("User");
            //    entity.HasKey(e => e.iduser);
            //    entity.Property(e => e.iduser).HasMaxLength(20);
            //    entity.HasIndex(e => e.username).IsUnique();
            //    entity.Property(e => e.username).IsRequired().HasMaxLength(100);
            //    entity.Property(e => e.password).IsRequired().HasMaxLength(255);
            //});

            //modelBuilder.Entity<Message>(entity =>
            //{
            //    entity.ToTable("Message");
            //    entity.HasKey(e => e.idmessage);
            //    entity.Property(e => e.iduser_send).HasMaxLength(20);
            //    entity.Property(e => e.iduser_receive).HasMaxLength(20);
            //});

            //modelBuilder.Entity<Room>(entity =>
            //{
            //    entity.ToTable("Room");
            //    entity.HasKey(e => new { e.idroom, e.iduser });
            //    entity.Property(e => e.idroom).HasMaxLength(32);
            //    entity.Property(e => e.iduser).HasMaxLength(20);
            //    entity.Property(e => e.series).ValueGeneratedOnAdd();
            //    entity.Property(e => e.display_name).IsRequired();
            //});

            //modelBuilder.Entity<MessageRoom>(entity =>
            //{
            //    entity.ToTable("MessageRoom");
            //    entity.HasKey(e => e.idmessage);
            //    entity.Property(e => e.idmessage).ValueGeneratedOnAdd();
            //    entity.Property(e => e.idroom).HasMaxLength(32);
            //    entity.Property(e => e.iduser_send).HasMaxLength(20);
            //});

            //modelBuilder.Entity<FriendShip>(entity =>
            //{
            //    entity.ToTable("FriendShip");
            //    entity.HasKey(e => e.friendship_id);
            //    entity.Property(e => e.friendship_id).ValueGeneratedOnAdd();
            //    entity.Property(e => e.personid_1).HasMaxLength(20);
            //    entity.Property(e => e.personid_2).HasMaxLength(20);
            //});
        }
    }
}
