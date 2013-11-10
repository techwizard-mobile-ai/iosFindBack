using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FindBack.Core.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FindBack.Phone.Views
{
    public partial class DetailItemView : MvxPhonePage
    {
        public DetailItemView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var locationKnown = ((DetailItemViewModel)ViewModel).Item.LocationKnown;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = locationKnown;
        }

        private void AppBarDeleteButton_OnClick(object sender, EventArgs e)
        {
            ((DetailItemViewModel)ViewModel).DeleteCommand.Execute(null);
        }

        private void AppBarMapButton_OnClick(object sender, EventArgs e)
        {
            ((DetailItemViewModel)ViewModel).MapCommand.Execute(null);
        }
    }
}