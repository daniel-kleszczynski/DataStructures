using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DataStructures.UI.Behaviors
{
    public static class LoadedEvent
    {
        public static ICommand GetOnLoaded(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(OnLoadedProperty);
        }

        public static void SetOnLoaded(DependencyObject obj, ICommand value)
        {
            obj.SetValue(OnLoadedProperty, value);
        }

        // Using a DependencyProperty as the backing store for OnLoaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnLoadedProperty =
            DependencyProperty.RegisterAttached("OnLoaded", typeof(ICommand), typeof(LoadedEvent), new PropertyMetadata(PropertyChanged));

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
                return;

            var frameworkElement = d as FrameworkElement;

            if (frameworkElement?.DataContext == null)
                return;

            frameworkElement.Loaded += (sender, args) => 
            {
                var command = e.NewValue as ICommand;

                if ((bool)command?.CanExecute(null))
                    command.Execute(null);
            };
        }
    }
}
