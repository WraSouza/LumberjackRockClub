using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumberjackRockClub.FirebaseServices
{
    internal class UsuarioServices
    {
        FirebaseClient firebase;

        public UsuarioServices()
        {
            firebase = new FirebaseClient("https://barbearialumberjack-249aa-default-rtdb.firebaseio.com/");
        }
    }
}
