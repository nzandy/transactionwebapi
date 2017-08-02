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
	public class TransactionsControllerDeleteRequestTests {
		private TransactionsController _controller;

		[TestInitialize]
		public void Setup() {
			ITransactionRepository _repository = new MockTransactionRepository();
			_controller = new TransactionsController(_repository);
		}

		[TestMethod]
		public void DeleteRemovesItem() {
			IActionResult result = _controller.Get(1);
			OkObjectResult objectResult = result as OkObjectResult;
			Transaction responseTransaction = objectResult.Value as Transaction;
			Assert.IsNotNull(responseTransaction);
			_controller.Delete(1);
			IActionResult resultAfterDelete = _controller.Get(1);
			NotFoundObjectResult objectResultAfterDelete = resultAfterDelete as NotFoundObjectResult;
			Assert.IsNotNull(objectResultAfterDelete);
		}
	}
}
