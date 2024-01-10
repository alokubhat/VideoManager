using System.Configuration;
using System.Data;
using System.Windows;
using Video_Manager_UI.Model;
using Video_Manager_UI.View;
using Video_Manager_UI.ViewModel;

namespace Video_Manager_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            VideoManagerView window = new VideoManagerView();
            VideoManagerViewModel VM = new VideoManagerViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }

}
