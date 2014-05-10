using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FMUtility.AttachedProperties
{
    public static class DataGridProperties
    {
        public static readonly DependencyProperty DoubleClickCommandProperty = 
            DependencyProperty.RegisterAttached(
                "DoubleClickCommand", 
                typeof(ICommand), 
                typeof(DataGridProperties),
                new PropertyMetadata(HandleDoubleClickCommandChanged));

        public static ICommand GetDoubleClickCommand(DependencyObject dependencyObject)
        {
            return (ICommand) dependencyObject.GetValue(DoubleClickCommandProperty);
        }

        public static void SetDoubleClickCommand(DependencyObject dependencyObject, ICommand command)
        {
            dependencyObject.SetValue(DoubleClickCommandProperty, command);
        }

        private static void HandleDoubleClickCommandChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var dataGrid = dependencyObject as DataGrid;
            if (dataGrid == null)
                return;
            
            if (args.OldValue != null)
                dataGrid.MouseDoubleClick -= HandleMouseDoubleClick;

            if (args.NewValue != null)
                dataGrid.MouseDoubleClick += HandleMouseDoubleClick;
        }

        private static void HandleMouseDoubleClick(object sender, MouseButtonEventArgs args)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null)
                return;

            var command = dataGrid.GetValue(DoubleClickCommandProperty) as ICommand;
            if (command == null)
                return;

            if (command.CanExecute(dataGrid.SelectedItem))
                command.Execute(dataGrid.SelectedItem);
        }
    }
}
