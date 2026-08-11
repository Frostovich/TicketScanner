namespace TicketScanner.Infrastructure;
using Domain.LogsAndScans;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    public DbSet<DataOfScans> Scans { get; set; }
    
}