using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Firebase.Auth;

namespace HeCon.Droid
{
    [Activity(Label = "HeCon", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AppCompatActivity
    {

        const string TAG = "EmailPassword";

        TextView mStatusTextView;
        TextView mDetailTextView;
        EditText mEmailField;
        EditText mPasswordField;

        // [START declare_auth]
        //private FirebaseAuth mAuth;
        
        // [END declare_auth]

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            // Views
          
            mEmailField = FindViewById<EditText>(Resource.Id.emailEditText);
            mPasswordField = FindViewById<EditText>(Resource.Id.passwordEditText);

            // Buttons
            
            FindViewById(Resource.Id.LogInButton).Click += async delegate {
               // await CreateAccount(mEmailField.Text, mPasswordField.Text);
            };
            

            // [START initialize_auth]
            //mAuth =Firebase.FirebaseOptions.
            // [END initialize_auth]
        }



        /*protected override void OnCreate(Bundle bundle)
         {
             TabLayoutResource = Resource.Layout.Tabbar;
             ToolbarResource = Resource.Layout.Toolbar;

             base.OnCreate(bundle);

             global::Xamarin.Forms.Forms.Init(this, bundle);
             LoadApplication(new App());
         }*/


    }
}

