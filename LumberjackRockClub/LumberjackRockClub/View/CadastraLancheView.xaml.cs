using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using LumberjackRockClub.Model;
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

namespace LumberjackRockClub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastraLancheView : ContentPage
    {       
        public CadastraLancheView()
        {
            InitializeComponent();
        }
        //private async void SalvarLanche(object sender, EventArgs e)
        //{
        //    //await CrossMedia.Current.Initialize();
        //    //try
        //    //{
        //    //    file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
        //    //    {
        //    //        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
        //    //    });
        //    //    if (file == null)
        //    //        return;
        //    //    imgChoosed.Source = ImageSource.FromStream(() =>
        //    //    {
        //    //        var imageStram = file.GetStream();
        //    //        return imageStram;
        //    //    });
        //    //    await StoreImages(file.GetStream());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Debug.WriteLine(ex.Message);
        //    //}
        //}

        //private async Task<string> StoreImages(Stream imageStream)
        //{
        //    string nomeLanche = lblNomeLanche.Text;
        //    string imgurl = null;
        //    string storageImage = null;
        //    if (nomeLanche != null)
        //    {
        //        storageImage = await new FirebaseStorage("barbearialumberjack-249aa.appspot.com")
        //      .Child("Lanches")
        //      .Child(nomeLanche + ".jpg")
        //      .PutAsync(imageStream);
        //        imgurl = storageImage;

        //    }
        //    return imgurl;
        //}

        //private async void EnviarLanche(object sender, EventArgs e)
        //{

        //    var imagemURL = await StoreImages(file.GetStream());

        //    firebase = new FirebaseClient("https://barbearialumberjack-249aa-default-rtdb.firebaseio.com/");
        //    await firebase.Child("Lanches")
        //            .PostAsync(new Hamburger()
        //            {
        //                NomeHamburger = lblNomeLanche.Text,
        //                Ingredientes = lblIngredientes.Text,
        //                Preco = lblPreco.Text,
        //                CaminhoImagem = imagemURL.ToString()
        //            });
        //}
    }
}