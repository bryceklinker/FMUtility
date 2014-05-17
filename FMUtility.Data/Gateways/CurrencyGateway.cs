using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMUtility.Core.Threading;
using FMUtility.Models;
using TaskFactory = FMUtility.Core.Threading.TaskFactory;

namespace FMUtility.Data.Gateways
{
    public interface ICurrencyGateway
    {
        Task<List<CurrencyModel>> Get();
        Task Set(CurrencyModel currency);
        Task Set(WageType wageType);
        Task<CurrencyModel> GetCurrentCurrency();
        Task<WageType> GetCurrentWageType();
    }

    public class CurrencyGateway : ICurrencyGateway
    {
        private readonly ICurrencyManager _currencyManager;
        private readonly ITaskFactory _taskFactory;

        public CurrencyGateway() : this(CurrencyManager.Instance, TaskFactory.Instance)
        {

        }

        public CurrencyGateway(ICurrencyManager currencyManager, ITaskFactory taskFactory)
        {
            _currencyManager = currencyManager;
            _taskFactory = taskFactory;
        }

        public Task<List<CurrencyModel>> Get()
        {
            return _taskFactory.StartNew(() => _currencyManager.AvailableCurrencies.ToList(), "Loading currencies...");
        }

        public Task Set(CurrencyModel currencyModel)
        {
            return _taskFactory.StartNew(() => _currencyManager.SelectedCurrency = currencyModel);
        }

        public Task Set(WageType wageType)
        {
            return _taskFactory.StartNew(() => _currencyManager.SelectedWageType = wageType);
        }

        public Task<CurrencyModel> GetCurrentCurrency()
        {
            return _taskFactory.StartNew(() => _currencyManager.SelectedCurrency);
        }

        public Task<WageType> GetCurrentWageType()
        {
            return _taskFactory.StartNew(() => _currencyManager.SelectedWageType);
        }
    }
}
