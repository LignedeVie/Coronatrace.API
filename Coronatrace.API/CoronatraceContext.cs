using Coronatrace.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Coronatrace.API
{
    public class CoronatraceContext : DbContext
    {
        public CoronatraceContext(DbContextOptions<CoronatraceContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<GeoTimeRecord> GeoTimeRecords { get; set; }
        public DbSet<VerificationFile> Files { get; set; }

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "modelBuilder won't be null")]
        protected override void OnModelCreating([NotNull]ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<VerificationFile>()
                .HasIndex(x => x.UserId);

            modelBuilder.Entity<GeoTimeRecord>()
                .HasIndex(x => x.UserId);

            modelBuilder.Entity<GeoTimeRecord>()
                .HasIndex(x => new { x.IsVerified, x.VerifiedDateTime });
        }
    }
}
