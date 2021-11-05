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
    public class LancheService
    {
        FirebaseClient firebase;       

        public LancheService()
        {
            firebase = new FirebaseClient("https://barbearialumberjack-249aa-default-rtdb.firebaseio.com/");
        }
        
        public async Task<List<Hamburger>> RetornaHamburgers()
        {
            return (await firebase.Child("Lanches")
                .OnceAsync<Hamburger>()).Select(item => new Hamburger
                {
                    NomeHamburger = item.Object.NomeHamburger,
                    Ingredientes = item.Object.Ingredientes,
                    Preco = item.Object.Preco,
                    CaminhoImagem = item.Object.CaminhoImagem,
                    Promocao = item.Object.Promocao
                }).ToList();
        }

        public async Task<List<Hamburger>> RetornaHamburgerPromocao()
        {            
            var hamburgersPromocao = await RetornaHamburgers();
            await firebase
                .Child("Lanches")
                .OnceAsync<Hamburger>();                

            return hamburgersPromocao.Where(a => a.Promocao).ToList();
        }

        public async Task<bool> EnviarLanche(string nomeHamburger, string ingredientesHamburger, string precoHamburger, string referenciaImage)
        {           
            await firebase.Child("Lanches")
                    .PostAsync(new Hamburger()
                    {
                        NomeHamburger = nomeHamburger,
                        Ingredientes = ingredientesHamburger,
                        Preco = precoHamburger,
                        CaminhoImagem = referenciaImage,
                        Promocao = false
                    });

            return true;
        }
    }
}
