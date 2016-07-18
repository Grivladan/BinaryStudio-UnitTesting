using System;
using System.Collections.Generic;
using NUnit.Framework;
using FakeItEasy;

namespace Logic.Tests
{
    [TestFixture]
    public class LogicTests
    {
        private readonly IAlgoService _algoService;
        private readonly IDataService _dataService;

        public LogicTests()
        {
            _algoService = new AlgoService();
            _dataService = new DataService(10);
        }

        [SetUp]
        public void TestSetup()
        {
            for (int i = 1; i <= 9; i++)
                _dataService.AddItem(i);
        }

        [TearDown]
        public void TestTearDown()
        {
            _dataService.ClearAll();
        }

        [Test]
        public void Get_average_When_dataService_contains_some_numbers_Then_return_correct_average()
        {
            var service = new MasterService(_algoService,_dataService);

            var average = service.GetAverage();

            Assert.That(average, Is.EqualTo(5));
        }

        [Test]
        public void Get_square_When_dataService_contains_some_numbers_Then_return_correct_square()
        {
            var service = new MasterService(_algoService, _dataService);

            var square = service.GetMaxSquare();

            Assert.That(square,Is.EqualTo(81));
        }

        [Test]
        public void Get_square_When_dataService_contains_some_numbers_Then_GetMax_of_DataService_called()
        {
            var dataService = A.Fake<IDataService>();
            List<int> nums = new List<int> { 1, 4, 6, 7, 3 };
            A.CallTo(() => dataService.GetAllData()).Returns(nums);
            var service = new MasterService(_algoService, dataService);

            var square = service.GetMaxSquare();

            A.CallTo(() => dataService.GetMax()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Get_double_sum_When_data_service_contains_some_numbers_using_FakeItEasy_Then_return_correct_sum()
        {
            var dataService = A.Fake<IDataService>();
            List<int> nums = new List<int> {1,4,6,7,3};
            A.CallTo(() => dataService.GetAllData()).Returns(nums);

            var service = new MasterService(_algoService, dataService);

            var doubleSum = service.GetDoubleSum();

            Assert.That(doubleSum, Is.EqualTo(42));
        }

        [Test]
        public void Get_double_sum_When_dataService_contains_some_numbers_Then_GetAllData_of_DataService_called()
        {
            var dataService = A.Fake<IDataService>();
            List<int> nums = new List<int> { 1, 4, 6, 7, 3 };
            A.CallTo(() => dataService.GetAllData()).Returns(nums);
            var service = new MasterService(_algoService, dataService);

            var square = service.GetDoubleSum();

            A.CallTo(() => dataService.GetAllData()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        [TestCase(null)]
        public void Get_double_sum_When_data_isNull_Then_throw_exception(List<int> data)
        {
            var dataService = A.Fake<IDataService>();
            A.CallTo(() => dataService.GetAllData()).Returns(data);

            var service = new MasterService(_algoService, dataService);

            Assert.Throws<InvalidOperationException>(() => service.GetDoubleSum());
        }

        [Test]
        public void Get_double_sum_When_data_isEmpty_Then_throw_exception()
        {
            var dataService = A.Fake<IDataService>();
            List<int> data = new List<int>();
            A.CallTo(() => dataService.GetAllData()).Returns(data);

            var service = new MasterService(_algoService, dataService);

            Assert.Throws<InvalidOperationException>(() => service.GetDoubleSum());
        }
    }
}
