using LumberjackRockClub.FirebaseServices;
using LumberjackRockClub.Services;
using LumberjackRockClub.ViewModel;
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
    public partial class VisitorsView : ContentPage
    {
        public VisitorsView()
        {
            InitializeComponent();

            BindingContext = new VisitorsViewModel(Navigation);
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