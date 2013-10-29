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
    public partial class ItemsView : MvxPhonePage
    {
        public ItemsView()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ((ItemsViewModel)ViewModel).ShowDetailCommand.Execute(e.AddedItems[0]);
                ((ListBox)sender).SelectedIndex = -1;
            }
        }

        private void AppBarAddItemButton_OnClick(object sender, EventArgs e)
        {
            ((ItemsViewModel)ViewModel).AddItemCommand.Execute(null);
        }
    }
}