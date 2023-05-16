using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace UtilityPaymentManager.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Counter> Counters { get; set; }
		public DbSet<PaidCounter> PaidCounters { get; set; }

	}
}
