using System;
using System.Linq;

namespace Logic
{
    public class MasterService : IMasterService
    {
        private readonly IAlgoService _algoService;

        private readonly IDataService _dataService;
        
        public MasterService(IAlgoService algo, IDataService data)
        {
            _algoService = algo;
            _dataService = data;
        }

        public int GetDoubleSum()
        {
            var data = _dataService.GetAllData();
            if (data == null || !data.Any())
            {
                throw new InvalidOperationException("We have no data to process");
            }

            return _algoService.DoubleSum(data);;
        }

        //TODO: Make more methods

        public double GetAverage()
        {
            var data = _dataService.GetAllData();
            return _algoService.GetAverage(data);
        }

        public double GetMaxSquare()
        {
            var data = _dataService.GetMax();
            return _algoService.Sqr(data);
        }
    }
}