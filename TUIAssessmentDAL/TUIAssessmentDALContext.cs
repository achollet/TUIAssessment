using Microsoft.EntityFrameworkCore;
using TUIAssessment.DAL.Entities;

namespace TUIAssessment.DAL
{
    public class TUIAssessmentDALContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource = tuiassessment.db");
        }
        public DbSet<AirportEntity> Airports { get; set; }
        public DbSet<FlightEntity> Flights { get; set; }
    }
}