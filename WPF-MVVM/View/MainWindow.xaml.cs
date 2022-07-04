using System.Windows;
using System.Windows.Data;
using WPF_MVVM.ViewModel;

namespace WPF_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AppViewModel AppView = new AppViewModel();
            
            // View와 ViewModel 바인딩
            DataContext = AppView;

            // XAML 파일이 손상되어 바인딩 정보가 날아가는 것을 방지하기 위해 코드 바인딩 사용
            // Target : View, Source : ViewModel
            Binding bind = new Binding();
            bind.Source = DataContext;
            // Source : ViewModel.Property
            bind.Path = new PropertyPath("TitleContent");
            bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            bind.Mode = BindingMode.TwoWay;
            // Target : View.Control
            LblTitle.SetBinding(ContentProperty, bind);

            BtnActionEvent.Command = AppView.AppCmd;
        }
    }
}
