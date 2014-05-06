using System.Windows;
using System.Windows.Controls;

namespace FMUtility.Styles
{
    public class PaneStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var style = Application.Current.TryFindResource(container.GetType()) as Style;
            if (style != null)
                return style;
            return base.SelectStyle(item, container);
        }
    }
}
