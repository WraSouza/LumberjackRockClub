using Firebase.Database;
using Firebase.Database.Query;
using LumberjackRockClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberjackRockClub.FirebaseServices
{
    internal class UsuarioServices
    {
        FirebaseClient firebase;

        public UsuarioServices()
        {
            firebase = new FirebaseClient("https://barbearialumberjack-249aa-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsUSerExists(string email)
        {
            var user = (await firebase.Child("Usuarios")
                .OnceAsync<Usuario>())
                .Where(u => u.Object.Email == email)
                .FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> LoginUser(string email, string passwd)
        {
            //Preferences.Set("Responsabilidade", Responsabilidade);
            var user = (await firebase.Child("Usuarios")
                .OnceAsync<Usuario>())
                .Where(u => u.Object.Email == email)
                .Where(u => u.Object.Password == passwd)
                .FirstOrDefault();


            return (user != null);
        }

        public async Task<bool> RegisterUser(string name, string password, string email,DateTime lastaccessday, DateTime dataCriacao, string perfiltype)
        {
            if (await IsUSerExists(name) == false)
            {
                await firebase.Child("Usuarios")
                    .PostAsync(new Usuario()
                    {
                        Name = name,
                        Password = password,
                        Email = email,
                        LastAccessDay = lastaccessday,
                        CreatedDate = dataCriacao,
                        PerfilType= perfiltype
                    });
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
