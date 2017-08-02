using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionWebApi.Models;
using TransactionWebApi.Repositories;

namespace TransactionWebApi.Controllers {
	[Route("api/[controller]")]
	public class TransactionsController : Controller {
		private ITransactionRepository _transactionRepository;

		public TransactionsController(ITransactionRepository transactionRepository) {
			_transactionRepository = transactionRepository;
		}
		// GET api/transactions
		[HttpGet]
		public IEnumerable<Transaction> Get() {
			return _transactionRepository.GetAll();
		}

		// GET api/transactions/5
		[HttpGet("{id}")]
		public Transaction Get(int id) {
			return _transactionRepository.Get(id);
		}

		// POST api/transactions
		[HttpPost]
		public void Post([FromBody]Transaction transaction) {
			_transactionRepository.Add(transaction);
		}

		// PUT api/transactions/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/transactions/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
			_transactionRepository.Delete(id);
		}
	}
}
