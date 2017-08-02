using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TransactionWebApi.Models {
	public class TransactionDbContext : DbContext {

		public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
		: base(options) { }

		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// Make non plural table name in SQL Server.
			modelBuilder.Entity<Transaction>().ToTable("Transaction");
		}
	}
}
