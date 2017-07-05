using Microsoft.EntityFrameworkCore;
using DanielWambura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielWambura.Data
{
    public class DawaDbContext : DbContext
    {
        public DawaDbContext(DbContextOptions<DawaDbContext> options) : base(options)
        {

        }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<VisitorMessage> VisitorMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactMessage>().ToTable("TblContactMessage");
            modelBuilder.Entity<Feedback>().ToTable("TblFeedback");
            modelBuilder.Entity<VisitorMessage>().ToTable("TblVisitorMessage");
        }
    }
}
