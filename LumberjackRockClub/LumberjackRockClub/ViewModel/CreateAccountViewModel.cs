using LumberjackRockClub.FirebaseServices;
using LumberjackRockClub.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LumberjackRockClub.ViewModel
{
    internal class CreateAccountViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private string _userName;
        public Command CreateUser { get; set; }

        public CreateAccountViewModel()
        {
            CreateUser = new Command(async () => await CriarUsuario());
        }

        public string Email
        {
            get {  return _email; }
            set {  _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get {  return _password; }  
            set {  _password = value; OnPropertyChanged();}
        }

        public string Name
        {
            get {  return _userName; }
            set {  _userName = value; OnPropertyChanged();}
        }

        private async Task CriarUsuario()
        {
            bool verificaConexaoInternet = Conectividade.VerificaConectividade();

            var novoUsuario = new UsuarioServices();
            string perfiltype;            

            DateTime createDay = DateTime.Now;

            if (verificaConexaoInternet)
            {
                bool verificaSeusuarioExiste = await novoUsuario.IsUSerExists(Name);

                if (verificaSeusuarioExiste)
                {
                    await App.Current.MainPage.DisplayAlert("Info", "Usuário Já Cadastrado", "OK");
                }
                else
                {
                    if (Name != "Demetrius")
                    {
                        perfiltype = "usuario";
                    }
                    else
                    {
                        perfiltype = "proprietario";
                    }
                   
                    try
                    {
                        bool confirmaUsuarioCriado = await novoUsuario.RegisterUser(Name, Password, Email, createDay, createDay, perfiltype);

                        if (confirmaUsuarioCriado)
                        {
                            await Application.Current.MainPage.DisplayAlert("Sucesso", "Usuário Criado Com Sucesso", "OK");

                            Application.Current.MainPage = new View.AppShell();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Erro", "Não Foi Possível Criar Usuário", "OK");
                        }
                    }
                    catch(Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro",ex.Message.ToString() , "OK");
                    }
                   
                }
                
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Sem Conexão de Rede.Verifique Sua Conexão de Internet e Tente Novamente", "OK");
            }

            
        }
        
    }
}
