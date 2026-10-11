using Microsoft.EntityFrameworkCore;

namespace Bai_1.Models;

public partial class TriThucBooksContext
{
    public TriThucBooksContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-LCI2GJQI;Database=TriThucBooks;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
        }
    }
}