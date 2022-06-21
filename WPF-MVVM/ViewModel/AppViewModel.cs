using System;
using System.Diagnostics;
using WPF_MVVM.Models;
using WPF_MVVM.ViewModel.Command;

namespace WPF_MVVM.ViewModel
{
    public class AppViewModel : AppNotify
    {
        Context Context = new Context();

        public AppCommand AppCmd { get; set; }

        public AppViewModel()
        {
            AppCmd = new AppCommand(ActionApp);
        }

        private void ActionApp()
        {
            TitleContent = "Welcome To WPF World! " + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss:FFFFFFF");
            Debug.WriteLine(TitleContent);
        }
    }
}
