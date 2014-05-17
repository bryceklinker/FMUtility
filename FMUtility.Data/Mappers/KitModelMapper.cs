using System.Collections.Generic;
using System.Linq;
using FMEditorLive.FMObjects;
using FMUtility.Data.Extensions;
using FMUtility.Models;

namespace FMUtility.Data.Mappers
{
    public interface IKitModelMapper
    {
        List<KitModel> Map(IEnumerable<Kit> kits);
        KitModel Map(Kit kit);
    }

    public class KitModelMapper : IKitModelMapper
    {
        public List<KitModel> Map(IEnumerable<Kit> kits)
        {
            return kits.Select(Map).ToList();
        }

        public KitModel Map(Kit k)
        {
            return new KitModel
            {
                Background = k.Background.AsColorModel(),
                Foreground = k.Foreground.AsColorModel(),
                IsOutfieldPlayer = k.OutfieldPlayer,
                KitType = k.KitType.AsKitType(),
                NumberColor = k.NumberColor.AsColorModel(),
                Outline = k.Outline.AsColorModel(),
                OutlineNumberColor = k.OutlineNumberColor.AsColorModel(),
                RecordType = k.RecordType.AsRecordType(),
                Style = k.Style
            };
        }
    }
}