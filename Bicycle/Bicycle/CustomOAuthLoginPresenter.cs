using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Bicycle
{
    public class CustomOAuthLoginPresenter
    {
        //May require a new package to be installed the 
        //    xamarin.auth seems to be out of date or limited
        //  AuthenticatorCompletedEventArgs has an additional
        //      constructor that takes a parameter (Account)
        //#if region also
        public event EventHandler<AuthenticatorCompletedEventArgs> Completed;

        public static Action<Authenticator> PlatformLogin;

        public void Login(Authenticator authenticator)
        {
            authenticator.Completed += OnAuthCompleted;

            PlatformLogin(authenticator);
        }

        void OnAuthCompleted(object sender, global::Xamarin.Auth.AuthenticatorCompletedEventArgs e)
        {
            if (Completed != null)
            {
                Completed(sender, e);
            }

            ((Authenticator)sender).Completed -= OnAuthCompleted;
        }
    }
}
