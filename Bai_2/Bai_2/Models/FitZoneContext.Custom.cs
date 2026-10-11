using Microsoft.EntityFrameworkCore;

namespace Bai_2.Models;

public partial class FitZoneContext
{
    public FitZoneContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-LCI2GJQI;Database=FitZone;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
        }
    }
}