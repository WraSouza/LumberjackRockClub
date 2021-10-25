using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using Firebase.Storage;
using System.Diagnostics;
using LumberjackRockClub.FirebaseServices;

namespace LumberjackRockClub.ViewModel
{
    public class CadastrarLancheViewModel : BaseViewModel
    {
        private string _nomeLanche;
        private string _precoLanche;
        private string _ingredientesLanche;
        private ImageSource _caminhoImagem;
        MediaFile file;
       

        public Command CadastrarLanche { get; set; }
        public Command SelecionarImagem { get; set; }

        public ImageSource CaminhoImagem
        {
            get { return _caminhoImagem; }
            set { _caminhoImagem = value; OnPropertyChanged(); }
        }

        public string IngredientesLanche
        {
            get { return _ingredientesLanche; }
            set { _ingredientesLanche = value; OnPropertyChanged(); }
        }

        public string NomeHamburger
        {
            get { return _nomeLanche; }
            set { _nomeLanche = value; OnPropertyChanged(); }
        }

        public string PrecoLanche
        {
            get { return _precoLanche; }
            set { _precoLanche = value; OnPropertyChanged(); }
        }

        public CadastrarLancheViewModel()
        {
            CadastrarLanche = new Command(async () => await CadastrarLancheOnLine());
            SelecionarImagem = new Command(async () => await SelecionarImagemGaleria());
        }

        private async Task SelecionarImagemGaleria()
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
                CaminhoImagem = ImageSource.FromStream(() => file.GetStream());
                //CaminhoImagem.Source = ImageSource.FromStream(() =>
                //{
                //    var imageStram = file.GetStream();
                //    return imageStram;
                //});
                await StoreImages(file.GetStream());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task<string> StoreImages(Stream imageStream)
        {
            string nomeLanche = NomeHamburger;
            string imgurl = null;
            string storageImage = null;
            if (nomeLanche != null)
            {
                storageImage = await new FirebaseStorage("barbearialumberjack-249aa.appspot.com")
              .Child("Lanches")
              .Child(nomeLanche + ".jpg")
              .PutAsync(imageStream);
                imgurl = storageImage;

            }
            return imgurl;
        }

        private async Task CadastrarLancheOnLine()
        {
            var imagemURL = await StoreImages(file.GetStream());
            string nomeHamburger = NomeHamburger;
            string ingredientesHamburger = IngredientesLanche;
            string precoHamburger = PrecoLanche;
            string referenciaImagem = imagemURL.ToString();

            LancheService novoLanche = new LancheService();

            bool confirmaCadastroLanche = await novoLanche.EnviarLanche(nomeHamburger, ingredientesHamburger, precoHamburger, referenciaImagem);

            if (confirmaCadastroLanche)
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso", "Lanche Cadastrado Com Sucesso", "OK");
            }
        }
    }
}
