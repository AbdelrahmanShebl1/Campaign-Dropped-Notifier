﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Notifier
{
    public partial class LBA_PortalContext : DbContext
    {
        public LBA_PortalContext()
        {
        }

        public LBA_PortalContext(DbContextOptions<LBA_PortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RunningCampaignsView> RunningCampaignsViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LBA_Portal;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RunningCampaignsView>(entity =>
            {
                entity.ToView("RunningCampaignsView");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}