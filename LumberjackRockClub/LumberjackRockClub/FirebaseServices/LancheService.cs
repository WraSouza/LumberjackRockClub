using Firebase.Database;
using Firebase.Database.Query;
using LumberjackRockClub.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LumberjackRockClub.FirebaseServices
{
    public class LancheService
    {
        FirebaseClient firebase;       

        public LancheService()
        {
            firebase = new FirebaseClient("https://barbearialumberjack-249aa-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> EnviarLanche(string nomeHamburger, string ingredientesHamburger, string precoHamburger, string referenciaImage)
        {           
            await firebase.Child("Lanches")
                    .PostAsync(new Hamburger()
                    {
                        NomeHamburger = nomeHamburger,
                        Ingredientes = ingredientesHamburger,
                        Preco = precoHamburger,
                        CaminhoImagem = referenciaImage
                    });

            return true;
        }
    }
}
