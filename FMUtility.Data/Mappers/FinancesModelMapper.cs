using FMEditorLive.FMObjects;
using FMUtility.Data.Extensions;
using FMUtility.Models;

namespace FMUtility.Data.Mappers
{
    public interface IFinancesModelMapper
    {
        FinancesModel Map(Finances finances);
    }

    public class FinancesModelMapper : IFinancesModelMapper
    {
        public FinancesModel Map(Finances finances)
        {
            return new FinancesModel
            {
                Balance = finances.Balance.AsCurrencyValue(),
                CorpFacilities = finances.CorpFacilities,
                IsActive = finances.ActiveFinances,
                MaximumWage = finances.MaxWage.AsWageModel(),
                PayrollBudget = finances.PayrollBudget.AsWageModel(),
                TransferBudget = finances.TransferBudget.AsCurrencyValue(),
                TransferBudgetRemaining = finances.TransferBudgetRemain.AsCurrencyValue()
            };
        }
    }
}