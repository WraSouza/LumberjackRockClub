using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumberjackRockClub.FirebaseServices
{
    internal class BarService
    {
        FirebaseClient firebase;

        public BarService()
        {
            firebase = new FirebaseClient("https://barbearialumberjack-249aa-default-rtdb.firebaseio.com/");
        }
    }
}
