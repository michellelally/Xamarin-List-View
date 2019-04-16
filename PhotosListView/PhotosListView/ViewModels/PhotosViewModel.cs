using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;


namespace PhotosListView.ViewModels
{
    public class PhotosViewModel : BaseViewModel
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        public static ObservableCollection<PhotosViewModel> ReadPhotoListData()
        {
            ObservableCollection<PhotosViewModel> myList = new ObservableCollection<PhotosViewModel>();
            string jsonText;

            try  // reading the localApplicationFolder first
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, Utils.JSON_PHOTOS_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    // need json library
                }
            }
            catch // fallback is to read the default file
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(
                                                typeof(MainPage)).Assembly;
                // create the stream
                Stream stream = assembly.GetManifestResourceStream(
                                    "PhotosListView.Data.data.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    // include JSON library now
                }
            }

            myList = JsonConvert.DeserializeObject<ObservableCollection<PhotosViewModel>>(jsonText);

            return myList;
        }

        public static void SavePhotosListData(ObservableCollection<PhotosViewModel> saveList)
        {
            // need the path to the file
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, Utils.JSON_PHOTOS_FILE);
            // use a stream writer to write the list
            using (var writer = new StreamWriter(filename, false))
            {
                // stringify equivalent
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }


    }
}
