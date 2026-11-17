using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorSchedulerCrud.Models
{
    public partial class ScheduleDataContext : DbContext
    {

        public ScheduleDataContext(DbContextOptions<ScheduleDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> EventsData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
