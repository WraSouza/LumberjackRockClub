using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumberjackRockClub.View.TabbedPageRestaurante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarView : ContentPage
    {
        MediaFile file;
        public BarView()
        {
            InitializeComponent();
        }

        private async void SalvarLanche(object sender, EventArgs e)
        {
            
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                    return;
                imgChoosed.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
                await StoreImages(file.GetStream(), lblIngredientes.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task<string> StoreImages(Stream imageStream, string descricao)
        {
            string nomeLanche = lblNomeLanche.Text;
            var storageImage = await new FirebaseStorage("barbearialumberjack-249aa.appspot.com")
               .Child("Lanches")
               .Child(nomeLanche + ".jpg")
               .PutAsync(imageStream);
            string imgurl = storageImage;
            return imgurl;
            
        }

        private async void EnviarLanche(object sender, EventArgs e)
        {
            
            await StoreImages(file.GetStream(), lblIngredientes.Text);
        }
    }
}