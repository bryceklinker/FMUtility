namespace FMUtility.Models
{
    public class FinancesModel
    {
        public bool IsActive { get; set; }
        public int Balance { get; set; }
        public int CorpFacilities { get; set; }
        public int MaximumWage { get; set; }
        public int PayrollBudget { get; set; }
        public int TransferBudget { get; set; }
        public int TransferBudgetRemaining { get; set; }
    }
}