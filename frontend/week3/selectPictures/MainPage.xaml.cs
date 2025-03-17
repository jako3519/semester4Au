using Microsoft.Maui.Storage;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using selectPictures.Models;

namespace selectPictures
{
    public partial class MainPage : ContentPage
    {
        private string _imagePath;
        public ObservableCollection<ImageInfo> Images { get; set; } = new();

        public ObservableCollection<ImageInfo> Images_db // til db
        {
            get => Images;
            set
            {
                Images = value;
                OnPropertyChanged(nameof(Images)); // notifier at der er sket en ændring
            }
        }

        private readonly Database _database;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            _database = new Database(); // til db
            _ = Initialize();
        }

        private async Task Initialize() // alt dette bruges til db
        {
            var imagesfromdb = await _database.GetImageInfos();
            Images_db.Clear();

            foreach (var image in imagesfromdb)
            {
                Images_db.Add(image);
            }
        }

        async void ChosePictureClicked(object sender, EventArgs e)
        {
            var image = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Image",
                FileTypes = FilePickerFileType.Images
            });

            if (image != null)
            {
                _imagePath = image.FullPath.ToString();
                selectedImage.Source = _imagePath;
            }
        }

        async void OnAddPictureClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_imagePath) &&
                !string.IsNullOrWhiteSpace(titel.Text) &&
                !string.IsNullOrWhiteSpace(beskrivelse.Text))
            {
                var newImageInfo = new ImageInfo
                {
                    FilePath = _imagePath,
                    Title = titel.Text,
                    Description = beskrivelse.Text
                };

                Images.Add(newImageInfo);
                await _database.AddImageInfo(newImageInfo);
                
                //Images.Add(new ImageInfo
                //{
                 //   FilePath = _imagePath,
                  //  Title = titel.Text,
                  //  Description = beskrivelse.Text hey hvis vi ikke skulle bruge databasen skal vi bruge dette istedet.
                //});

                _imagePath = string.Empty;
                selectedImage.Source = null;
                titel.Text = string.Empty;
                beskrivelse.Text = string.Empty;
            }
        }
    }
}
