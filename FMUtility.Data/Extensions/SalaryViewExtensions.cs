using System;
using FMEditorLive.Framework;
using FMUtility.Models;

namespace FMUtility.Data.Extensions
{
    public static class SalaryViewExtensions
    {
        public static WageType AsWageType(this SalaryView salaryView)
        {
            switch (salaryView)
            {
                case SalaryView.Weekly:
                    return WageType.Weekly;
                case SalaryView.Monthly:
                    return WageType.Monthly;
                case SalaryView.Yearly:
                    return WageType.Yearly;
                default:
                    throw new ArgumentOutOfRangeException("salaryView");
            }
        }
    }
}
