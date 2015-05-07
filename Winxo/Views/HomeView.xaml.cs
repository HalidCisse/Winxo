using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;



namespace Winxo.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home 
    {
        public Home()
        {
            InitializeComponent();
        }

        #region Home Buttons Commandes

        private void StudentButton_Click(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
=> { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void PedagogieButton_Click(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
=> { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void StaffButton_Click(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
=> { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void AgendaButton_Click(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
=> { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void EconomatButton_Click(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
=> { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void StatisticButton_Click(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
=> { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        #endregion
    }
}
