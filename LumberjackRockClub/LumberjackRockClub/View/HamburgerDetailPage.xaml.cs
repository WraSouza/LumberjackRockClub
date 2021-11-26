using LumberjackRockClub.FirebaseServices;
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
    public partial class HamburgerDetailPage : ContentPage
    {
        public HamburgerDetailPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                string nomeHamburger = Preferences.Get("NomeHamburger", "default_value");
                LancheService lanche = new LancheService();
                collectionview.ItemsSource = await lanche.RetornaHamburgerPorNome(nomeHamburger);
            }
            else
            {
                await DisplayAlert("Erro", "Sem Conexão de Rede.Verifique Sua Conexão de Internet e Tente Novamente", "OK");
            }
        }

        //public async Task BuscaHamburger()
        //{
        //    bool verificaConexao = Conectividade.VerificaConectividade();

        //    if (verificaConexao)
        //    {
        //        string nomeHamburger = Preferences.Get("NomeHamburger", "default_value");
        //        LancheService lanche = new LancheService();
        //        collectionview.ItemsSource = await lanche.RetornaHamburgerPorNome(nomeHamburger);
        //    }
        //    else
        //    {
        //        await DisplayAlert("Erro", "Sem Conexão de Rede.Verifique Sua Conexão de Internet e Tente Novamente", "OK");
        //    }
        //}


    }
}