using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMEditorLive.Framework;
using FMUtility.Models;

namespace FMUtility.Data.Extensions
{
    public static class WageTypeExtensions
    {
        public static SalaryView AsSalaryView(this WageType wageType)
        {
            switch (wageType)
            {
                case WageType.Weekly:
                    return SalaryView.Weekly;
                case WageType.Monthly:
                    return SalaryView.Monthly;
                case WageType.Yearly:
                    return SalaryView.Yearly;
                default:
                    throw new ArgumentOutOfRangeException("wageType");
            }
        }
    }
}
