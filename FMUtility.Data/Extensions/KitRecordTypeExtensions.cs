using System;
using FMEditorLive.FMObjects;
using FMUtility.Models;

namespace FMUtility.Data.Extensions
{
    public static class KitRecordTypeExtensions
    {
        public static RecordType AsRecordType(this KitRecordType recordType)
        {
            return (RecordType) Enum.Parse(typeof (RecordType), recordType.ToString());
        }
    }
}