using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TesteBancoMaster.AppWPF.Api;

namespace TesteBancoMaster.AppWPF
{
    /// <summary>
    /// Lógica interna para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {

        Task task;
        DispatcherTimer timer;
        public SplashScreen()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (task.IsCompleted)
            {
                timer.Stop();
                MainWindow m = new MainWindow();
                m.Show();
                
                this.Hide();
            }
        }

        private void Iniciar()
        {
            var rotaService = new RotaService();
            rotaService.ObterTodos();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            task = Task.Run(() => Iniciar());
            timer.Start();
        }
    }
}
