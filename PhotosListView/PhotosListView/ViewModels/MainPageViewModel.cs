using PhotosListView.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhotosListView.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        #region == private fields ==
        private ObservableCollection<PhotosViewModel> photosList;
        private PhotosViewModel selectedPhoto;
        #endregion

        #region == Public Properties ==
        public ObservableCollection<PhotosViewModel> PhotosList
        {
            get { return photosList; }
            set { SetValue(ref photosList, value); }
        }
        public PhotosViewModel SelectedPhoto
        {
            get { return selectedPhoto; }
            set
            {
                SetValue(ref selectedPhoto, value);

            }
        }
        #endregion


        #region == Command Properties ==
        // ICommand is an interface with two methods
        // can execute and execute
        public ICommand ReadListCommand { get; private set; }
        public ICommand SaveListCommand { get; private set; }
        public ICommand DeleteFromListCommand { get; private set; }
        #endregion

        #region == public events ==
        private readonly IPageService _pageService;
        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadList();
            ReadListCommand = new Command(ReadList);
            SaveListCommand = new Command(SaveList);
            DeleteFromListCommand = new Command<PhotosViewModel>(DeleteFromList);
        }

        private void SaveList()
        {
            PhotosViewModel.SavePhotosListData(PhotosList);
        }

        private void ReadList()
        {
            PhotosList = PhotosViewModel.ReadPhotoListData();
        }

        private void DeleteFromList(PhotosViewModel p)
        {
            PhotosList.Remove(p);
            SelectedPhoto = null;
        }

        public async Task SelectOnePhoto(PhotosViewModel photo)
        {
            // can't use a command directly as there is only a commandRefresh
            // attribute

            if (photosList == null)
                return;
            //await Navigation.PushAsync(new photoDetailsPage(photo));
            /*
             * select a photo, go to the page
             * no Navigation property in the view model
             * member of the page class - same as the DisplayAlert
             * Use an interface
             */
            await _pageService.PushAsnyc(new PhotoDetailsPage(photo));

        }

        #endregion
    }
}
