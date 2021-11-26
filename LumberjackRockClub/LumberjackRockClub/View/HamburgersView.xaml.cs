using LumberjackRockClub.FirebaseServices;
using LumberjackRockClub.Model;
using LumberjackRockClub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumberjackRockClub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgersView : ContentPage
    {
        public HamburgersView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            //base.OnAppearing();
            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                LancheService lanche = new LancheService();
                collectionview.ItemsSource = await lanche.RetornaHamburgers();
            }
            else
            {
                await DisplayAlert("Erro", "Sem Conexão de Rede.Verifique Sua Conexão de Internet e Tente Novamente", "OK");
            }


        }

        private void itemselecionado(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
            
            //hamburgerSelecionado(e.CurrentSelection.);
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedContact)
        {
            var selectedContact = currentSelectedContact.FirstOrDefault() as Hamburger;
           // HamburgerDetailPage hamburger = new HamburgerDetailPage();
            Preferences.Set("NomeHamburger",selectedContact.NomeHamburger);
           Application.Current.MainPage = new View.HamburgerDetailPage();
        }
    }
}