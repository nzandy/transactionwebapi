using System.Collections.Generic;
using TransactionWebApi.Models;

namespace TransactionWebApi.Repositories {
	public interface ITransactionRepository {
		IEnumerable<Transaction> GetAll();
		Transaction Get(int transactionId);
		void Add(Transaction transaction);
		void Delete(int transactionId);
		bool Update(Transaction updatedTransaction);
	}

}
