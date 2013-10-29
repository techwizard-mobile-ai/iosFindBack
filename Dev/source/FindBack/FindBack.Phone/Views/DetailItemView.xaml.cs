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

        private void AppBarDeleteButton_OnClick(object sender, EventArgs e)
        {
            ((DetailItemViewModel)ViewModel).DeleteCommand.Execute(null);
        }
    }
}