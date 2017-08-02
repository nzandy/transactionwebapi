using System;
using System.Collections.Generic;
using TransactionWebApi.Models;
using TransactionWebApi.Repositories;
using System.Linq;

namespace TransactionWebApi.Tests.Mocks {
	public class MockTransactionRepository : ITransactionRepository {
		private List<Transaction> _transactions;
		private int _idCount = 1;
		public static string FIRST_TRANS_DESCRIPTION = "First Transaction";
		public static string SECOND_TRANS_DESCRIPTION = "Second Transaction";

		public MockTransactionRepository() {
			_transactions = new List<Transaction> {
				new Transaction {
					TransactionId = 1,
					Description = FIRST_TRANS_DESCRIPTION,
					CreatedDate = DateTime.Now,
					ModifiedDate = DateTime.Now,
					CurrencyCode = 999,
					Merchant = "Test Merchant",
					TransactionAmount = 50.19m
				},
				new Transaction {
					TransactionId = 2,
					Description = SECOND_TRANS_DESCRIPTION,
					CreatedDate = DateTime.Now,
					ModifiedDate = DateTime.Now,
					CurrencyCode = 888,
					Merchant = "Test Merchant 2",
					TransactionAmount = 79.19m
				}
			};
	}

		public Transaction Add(Transaction transaction) {
			transaction.TransactionId = _idCount;
			transaction.ModifiedDate = DateTime.Now;
			transaction.CreatedDate = DateTime.Now;
			_transactions.Add(transaction);
			_idCount++;
			return transaction;
		}

		public void Delete(int transactionId) {
			Transaction transactionToRemove = _transactions.FirstOrDefault(t => t.TransactionId == transactionId);
			if (transactionToRemove != null) {
				_transactions.Remove(transactionToRemove);
			}
		}

		public Transaction Get(int transactionId) {
			return _transactions.FirstOrDefault(t => t.TransactionId == transactionId);
		}

		public IEnumerable<Transaction> GetAll() {
			return _transactions;
		}

		public bool Update(int id, Transaction updatedTransaction) {
			Transaction transactionToUpdate = _transactions.FirstOrDefault(t => t.TransactionId == id);
			if (transactionToUpdate == null) {
				return false;
			}
			transactionToUpdate.UpdateFromTransaction(updatedTransaction);
			return true;
		}
	}
}
