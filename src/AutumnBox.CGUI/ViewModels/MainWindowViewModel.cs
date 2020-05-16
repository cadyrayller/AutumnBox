using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutumnBox.CGUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        public void R()
        {
            this.RaisePropertyChanged();
        }
    }
}
