using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AutumnBox.CGUI.ViewModels;
using AutumnBox.CGUI.Views;
using AutumnBox.Leafx.Container;
using AutumnBox.Leafx.Container.Support;
using System;
using Avalonia.Controls;

namespace AutumnBox.CGUI
{
    public class App : Application
    {
        public ILake Lake { get; private set; }
        public static new App Current { get; private set; }
        public override void Initialize()
        {
            Lake = new SunsetLake();
            Current = this;
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new Views.Windows.MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
