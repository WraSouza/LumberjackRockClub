using LumberjackRockClub.FirebaseServices;
using LumberjackRockClub.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LumberjackRockClub.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private string email;
        private bool _Result;
        private bool _IsBusy;
        public Command LoginCommand { get; set; }

        public string Name
        {
            get {  return username; }
            set { username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get {  return password; }
            set {  password = value; OnPropertyChanged();}
        }

        public string Email
        {
            get {  return email; }
            set {  email = value; OnPropertyChanged();}
        }

        //Método para verificar se o login foi realizado com sucesso
        public bool Result
        {
            get
            {
                return this._IsBusy;
            }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        //Método para verificar se o login está sendo realizado para evitar concorrência
        public bool IsBusy
        {
            get
            {
                return this._Result;
            }
            set
            {
                _Result = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OpenPrincipalView());
        }

        private async Task OpenPrincipalView()
        {
            if (IsBusy)
                return;

            try
            {
                bool verificaConexaoInternet = Conectividade.VerificaConectividade();
                var _userservices = new UsuarioServices();

                if (verificaConexaoInternet)
                {
                    IsBusy = true;
                    Result = await _userservices.LoginUser(Email, Password);
                    if (Result)
                    {
                        Application.Current.MainPage = new View.AppShell();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Erro", "E-mail ou Senha Incorretos", "OK");
                    }

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Sem Conexão de Rede.Verifique Sua Conexão de Internet e Tente Novamente", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
            
        }

    }
}
