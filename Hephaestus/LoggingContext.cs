using Hephaestus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hephaestus
{
    public class LoggingContext : DbContext
    {
        public DbSet<LogEntry> Logs { get; set; }

        public LoggingContext(DbContextOptions options) : base(options)
        {}
    }
}
