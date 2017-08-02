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
		public IActionResult Get() {
			return Ok(_transactionRepository.GetAll());
		}

		// GET api/transactions/5
		[HttpGet("{id}")]
		public IActionResult Get(int id) {
			Transaction foundTransaction = _transactionRepository.Get(id);
			if (foundTransaction == null) {
				return NotFound(id);
			}

			return Ok(foundTransaction);
		}

		// POST api/transactions
		[HttpPost]
		public IActionResult Post([FromBody]Transaction transaction) {
			if (transaction == null) {
				return BadRequest(transaction);
			}
			Transaction addedTransaction = _transactionRepository.Add(transaction);

			// Return the created object included generated ID and Date fields.
			return Ok(addedTransaction);
		}

		// PUT api/transactions/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]Transaction transaction) {
			
			if (transaction == null) {
				return BadRequest(transaction);
			}

			Transaction transactionToUpdate = _transactionRepository.Get(id);
			if (transactionToUpdate == null) {
				return NotFound(transaction);
			}

			_transactionRepository.Update(id, transaction);
			return Ok();
		}

		// DELETE api/transactions/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id) {
			Transaction transactionToDelete = _transactionRepository.Get(id);
			if (transactionToDelete == null) {
				return NotFound(id);
			}
			_transactionRepository.Delete(id);
			return Ok();
		}
	}
}
