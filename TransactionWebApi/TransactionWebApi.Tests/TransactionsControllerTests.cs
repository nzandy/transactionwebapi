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
	}
}
