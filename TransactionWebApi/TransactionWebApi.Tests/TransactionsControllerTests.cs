using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionWebApi.Repositories;
using TransactionWebApi.Controllers;
using TransactionWebApi.Tests.Mocks;
using TransactionWebApi.Models;
using System.Linq;

namespace TransactionWebApi.Tests {
	[TestClass]
	public class TransactionsControllerTests {

		private TransactionsController _controller;

		[TestInitialize]
		public void Setup() {
			ITransactionRepository _repository = new MockTransactionRepository();
			_controller = new TransactionsController(_repository);

		}
	}
}
