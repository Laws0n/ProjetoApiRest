using Clientes.Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Crud.Data;

public class ClienteContext : DbContext

{
    public ClienteContext(DbContextOptions<ClienteContext> opts)
        : base(opts)
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
}
