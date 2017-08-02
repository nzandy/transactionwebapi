using System;

namespace TransactionWebApi.Models {
	public class Transaction {
		public int TransactionId { get; set; }
		public string Description { get; set; }
		public Decimal TransactionAmount { get; set; }
		// Note: CurrencyCode would be better as Enum or seperate class - maybe correspodning to ISO standard?
		public int CurrencyCode { get; set; }
		// Note: In real world this would most likely be an object with it's own table in DB for referential integrity.
		public string Merchant { get; set; }
		public DateTime TransactionDate { get; set; }
		// Nullable as they are not set until saved to DB.
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
