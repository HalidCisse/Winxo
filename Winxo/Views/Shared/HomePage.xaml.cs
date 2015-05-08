using System;
using System.Threading.Tasks;
using System.Windows;

namespace Winxo.Views.Shared
{
    
    public partial class HomePage 
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void _CLIENT_BUTTON_OnClick(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
               => { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();
        

        private void _JOURNAL_BUTTON_OnClick(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
               => { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void _CARBURANT_BUTTON_OnClick(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
               => { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void _OIL_BUTTON_OnClick(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
               => { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void _STAFF_BUTTON_OnClick(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
               => { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();

        private void _POMPS_BUTTON_OnClick(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
               => { NavigationService?.Navigate(new ComingSoon(), UriKind.Relative); }));
        }).Start();
    }
}
