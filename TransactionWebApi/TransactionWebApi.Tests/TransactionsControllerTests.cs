using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionWebApi.Repositories;
using TransactionWebApi.Controllers;
using TransactionWebApi.Tests.Mocks;
using TransactionWebApi.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TransactionWebApi.Tests {
	[TestClass]
	public class TransactionsControllerTests {

		private TransactionsController _controller;

		[TestInitialize]
		public void Setup() {
			ITransactionRepository _repository = new MockTransactionRepository();
			_controller = new TransactionsController(_repository);
		}

		[TestMethod]
		public void GetAllReturnsAllTransactions() {
			IActionResult result = _controller.Get();
			OkObjectResult objectResult = result as OkObjectResult;
			Assert.IsNotNull(objectResult);
			List<Transaction> responseTransactions = objectResult.Value as List<Transaction>;
			Assert.IsNotNull(responseTransactions);
			Assert.AreEqual(2, responseTransactions.Count);
		}

		[TestMethod]
		public void GetById() {
			IActionResult result = _controller.Get(1);
			OkObjectResult objectResult = result as OkObjectResult;
			Assert.IsNotNull(objectResult);
			Transaction responseTransaction = objectResult.Value as Transaction;
			Assert.IsNotNull(responseTransaction);
			Assert.AreEqual(responseTransaction.Description, MockTransactionRepository.FIRST_TRANS_DESCRIPTION);
		}

		[TestMethod]
		public void GetByNonExistantIdReturnsNotFound() {
			IActionResult result = _controller.Get(99);
			NotFoundObjectResult objectResult = result as NotFoundObjectResult;
			Assert.IsNotNull(objectResult);
		}
	}
}
