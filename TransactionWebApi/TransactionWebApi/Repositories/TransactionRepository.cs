using System;
using System.Collections.Generic;
using System.Linq;
using TransactionWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TransactionWebApi.Repositories {
	public class TransactionRepository : ITransactionRepository {
		private TransactionDbContext _context;

		public TransactionRepository(TransactionDbContext context) {
			_context = context;
		}

		public void Add(Transaction transaction) {
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

		public bool Update(Transaction updatedTransaction) {
			Transaction transactionFromDb = Get(updatedTransaction.TransactionId);
			if (transactionFromDb == null) {
				return false;
			}
			_context.Transactions.Attach(updatedTransaction);
			_context.Entry(updatedTransaction).State = EntityState.Modified;
			SaveChanges();
			return true;
		}

		private void SaveChanges() {
			_context.SaveChanges();
		}
	}
}
