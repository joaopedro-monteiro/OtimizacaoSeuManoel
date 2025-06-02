using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OtimizacaoSeuManoel.Modules.Pedido.Entities;
using OtimizacaoSeuManoel.Modules.Produto.Entities;

namespace OtimizacaoSeuManoel.Context;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    private static readonly object Locker = new();
    private static bool _migrated;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        //MigrateLocked();
    }

    public DbSet<PedidoEntity> Pedidos { get; set; }
    public DbSet<ProdutoEntity> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        var loggerFactory = LoggerFactory.Create(builder => builder
            .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information));

        optionsBuilder.UseLoggerFactory(loggerFactory);
#endif

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(AppDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }

    private void MigrateLocked()
    {
        if (!Database.IsRelational() || _migrated)
            return;

        lock (Locker)
        {
            Database.Migrate();
            _migrated = true;
        }
    }
}
