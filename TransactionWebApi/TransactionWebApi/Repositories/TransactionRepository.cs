using System;
using System.Collections.Generic;
using System.Linq;
using TransactionWebApi.Models;

namespace TransactionWebApi.Repositories {
	public class TransactionRepository : ITransactionRepository {
		private TransactionDbContext _context;

		public TransactionRepository(TransactionDbContext context) {
			_context = context;
		}

		public void Add(Transaction transaction) {
			transaction.CreatedDate = DateTime.Now;
			transaction.ModifiedDate = DateTime.Now;
			_context.Transactions.Add(transaction);
			SaveChanges();
		}

		public void Delete(int transactionId) {
			Transaction transaction =_context.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
			if (transaction != null) {
				_context.Transactions.Remove(transaction);
			}
			SaveChanges();
		}

		public Transaction Get(int transactionId) {
			return _context.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
		}

		public IEnumerable<Transaction> GetAll() {
			return _context.Transactions;
		}

		public bool Update(int id, Transaction updatedTransaction) {
			Transaction transactionFromDb = Get(id);
			if (transactionFromDb == null) {
				return false;
			}
			transactionFromDb.ModifiedDate = DateTime.Now;
			transactionFromDb.TransactionAmount = updatedTransaction.TransactionAmount;
			transactionFromDb.TransactionDate = updatedTransaction.TransactionDate;
			transactionFromDb.TransactionAmount = updatedTransaction.TransactionAmount;
			transactionFromDb.Merchant = updatedTransaction.Merchant;
			transactionFromDb.Description = updatedTransaction.Description;
			transactionFromDb.CurrencyCode = updatedTransaction.CurrencyCode;
			SaveChanges();
			return true;
		}

		private void SaveChanges() {
			_context.SaveChanges();
		}
	}
}
