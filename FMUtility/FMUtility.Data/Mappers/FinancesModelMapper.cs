using FMEditorLive.FMObjects;
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
                Balance = finances.Balance,
                CorpFacilities = finances.CorpFacilities,
                IsActive = finances.ActiveFinances,
                MaximumWage = finances.MaxWage,
                PayrollBudget = finances.PayrollBudget,
                TransferBudget = finances.TransferBudget,
                TransferBudgetRemaining = finances.TransferBudgetRemain
            };
        }
    }
}