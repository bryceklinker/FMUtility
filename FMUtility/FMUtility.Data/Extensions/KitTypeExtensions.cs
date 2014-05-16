using System;
using FMUtility.Models;

namespace FMUtility.Data.Extensions
{
    public static class KitTypeExtensions
    {
        public static KitType AsKitType(this FMEditorLive.FMObjects.KitType kitType)
        {
            return (KitType) Enum.Parse(typeof (KitType), kitType.ToString());
        }
    }
}