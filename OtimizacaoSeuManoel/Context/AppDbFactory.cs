using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OtimizacaoSeuManoel.Context;

public class AppDbFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        const string connectionString = "Server=localhost;Database=SeuManoel;Integrated Security=True;TrustServerCertificate=True;";

        var construtor = new DbContextOptionsBuilder<AppDbContext>();
        construtor.UseSqlServer(connectionString);

        return new AppDbContext(construtor.Options);
    }
}
