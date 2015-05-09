﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Core.Model.Security.Enums;
using FirstFloor.ModernUI.Windows.Controls;
using Winxo.Views.Clients;

namespace Winxo.Views.Shared
{
    
    public partial class HomePage 
    {
        public HomePage()
        {
            if (App.CurrentUser.UserSpaces.All(s => (UserSpace)s.Value != UserSpace.AdminSpace))
            {
                ModernDialog.ShowMessage("Permission Refusée", "ERREUR", MessageBoxButton.OK);
                new Task(() => { Dispatcher.BeginInvoke(new Action(() => { NavigationService?.Navigate(new Login(), UriKind.Relative); })); }).Start();
                return;
            }

            InitializeComponent();

            new Task(() =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    if (mainWindow == null) return;
                    //mainWindow._SETTING_BUTTON.Visibility = Visibility.Visible;
                    mainWindow._USER_NAME_LABEL.Visibility = Visibility.Visible;
                    mainWindow._POPUP_BUTTON.Visibility = Visibility.Visible;
                    mainWindow._USER_NAME_LABEL.Content = App.CurrentUser?.UserName;
                }));
            }).Start();
        }

        private void _CLIENT_BUTTON_OnClick(object sender, RoutedEventArgs e) => new Task(() => {
            Dispatcher.BeginInvoke(new Action(()
               => { NavigationService?.Navigate(new ClientsView(), UriKind.Relative); }));
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
