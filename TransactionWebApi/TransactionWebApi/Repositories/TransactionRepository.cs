﻿using System;
using System.Collections.Generic;
using System.Linq;
using TransactionWebApi.Models;

namespace TransactionWebApi.Repositories {
	public class TransactionRepository : ITransactionRepository {
		private TransactionDbContext _context;

		public TransactionRepository(TransactionDbContext context) {
			_context = context;
		}

		public Transaction Add(Transaction transaction) {
			transaction.CreatedDate = DateTime.Now;
			transaction.ModifiedDate = DateTime.Now;
			_context.Transactions.Add(transaction);
			SaveChanges();
			return transaction;
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
			transactionFromDb.UpdateFromTransaction(updatedTransaction);
			SaveChanges();
			return true;
		}

		private void SaveChanges() {
			_context.SaveChanges();
		}
	}
}
