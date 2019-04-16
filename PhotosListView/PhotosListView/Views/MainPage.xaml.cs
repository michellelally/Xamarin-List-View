using PhotosListView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotosListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        private void DeleteContext_Clicked(object sender, EventArgs e)
        {
            PhotosViewModel photo = (sender as MenuItem).CommandParameter as PhotosViewModel;
            (BindingContext as MainPageViewModel).DeleteFromListCommand.Execute(photo);
        }

        private async void ListViewPhotoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await (BindingContext as MainPageViewModel).SelectOnePhoto(e.SelectedItem as PhotosViewModel);
            // could do this even smarter by using the setter on the SelectedItem
            // property in the view model. Can then avoid this method altogether

        }
    }
}
