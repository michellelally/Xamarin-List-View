using PhotosListView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotosListView.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotoDetailsPage : ContentPage
	{
        PhotosViewModel _photo;

        public PhotoDetailsPage() { }

        public PhotoDetailsPage(PhotosViewModel photo)
		{
			InitializeComponent ();
            _photo = photo;
            this.Title = _photo.Caption;

		}
	}
}