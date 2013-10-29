using System;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FindBack.Core.ViewModels;

namespace FindBack.Phone.Views
{
    public partial class AddItemView : MvxPhonePage
    {
        public AddItemView()
        {
            InitializeComponent();
        }

        private void AppBarSaveButton_OnClick(object sender, EventArgs e)
        {
            ((AddItemViewModel)ViewModel).SaveCommand.Execute(null);
        }

        private void AppBarTakePictureButton_OnClick(object sender, EventArgs e)
        {
            ((AddItemViewModel)ViewModel).TakePictureCommand.Execute(null);
        }

        private void AppBarSelectPictureButton_OnClick(object sender, EventArgs e)
        {
            ((AddItemViewModel)ViewModel).ChoosePictureCommand.Execute(null);
        }
    }
}