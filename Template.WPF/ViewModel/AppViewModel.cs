using System;
using System.Diagnostics;
using Template.WPF.Models;
using Template.WPF.ViewModel.Command;

namespace Template.WPF.ViewModel
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
