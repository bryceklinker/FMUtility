namespace FMUtility.Models
{
    public class FinancesModel
    {
        public bool IsActive { get; set; }
        public CurrencyValueModel Balance { get; set; }
        public int CorpFacilities { get; set; }
        public WageModel MaximumWage { get; set; }
        public WageModel PayrollBudget { get; set; }
        public CurrencyValueModel TransferBudget { get; set; }
        public CurrencyValueModel TransferBudgetRemaining { get; set; }
    }
}