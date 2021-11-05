using LumberjackRockClub.FirebaseServices;
using LumberjackRockClub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumberjackRockClub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PromocaoLanchesView : ContentPage
    {
        public PromocaoLanchesView()
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
                collectionview.ItemsSource = await lanche.RetornaHamburgerPromocao();
            }
            else
            {
                await DisplayAlert("Erro", "Sem Conexão de Rede.Verifique Sua Conexão de Internet e Tente Novamente", "OK");
            }


        }
    }
}