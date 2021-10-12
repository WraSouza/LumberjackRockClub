﻿using LumberjackRockClub.Services;
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

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OpenPrincipalView());
        }

        private async Task OpenPrincipalView()
        {
            bool verificaConexaoInternet = Conectividade.VerificaConectividade();

            if (verificaConexaoInternet)
            {
                App.Current.MainPage = new View.PrincipalView();                
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Sem Conexão de Rede.Verifique Sua Conexão de Internet e Tente Novamente", "OK");
            }
        }

    }
}