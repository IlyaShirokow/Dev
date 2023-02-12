using Microsoft.EntityFrameworkCore;
using System;

namespace ef_core.Models;

public class BrokerContext: DbContext
{	
    public DbSet<Broker> Brokers { get; set; }
    
    public BrokerContext(DbContextOptions options): base(options) { }
}
