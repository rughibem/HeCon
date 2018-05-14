using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase;
using Android.Text;
using System.Runtime.Remoting.Contexts;

namespace HeCon.Droid
{
    [Activity(Label = "HeCon", Icon = "@drawable/icon", Theme = "@style/loginscreen", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AppCompatActivity
    {

        const string TAG = "EmailPassword";

        TextView mStatusTextView;
        TextView mDetailTextView;
        EditText mEmailField;
        EditText mPasswordField;

        // [START declare_auth]
        public static FirebaseApp app;
        private FirebaseAuth mAuth;

        // [END declare_auth]

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);


            // Views

            mEmailField = FindViewById<EditText>(Resource.Id.emailEditText);
            mPasswordField = FindViewById<EditText>(Resource.Id.passwordEditText);

            // Buttons

            FindViewById(Resource.Id.LogInButton).Click += async delegate
            {
                await CreateAccount(mEmailField.Text, mPasswordField.Text);
            };

            InitFirebaseAuth();

            // [START initialize_auth]
            // mAuth = FirebaseAuth.Instance;
            //  try {
            //  FirebaseApp.InitializeApp(this);
            //  FirebaseApp.InitializeApp(this);

           //   mAuth = FirebaseAuth.Instance; //}
           // catch (Exception e) { }
            // [END initialize_auth]
        }
        void AuthStateChanged(object sender, FirebaseAuth.AuthStateEventArgs e)
        {
            var user = e.Auth.CurrentUser;
            if (user != null)
            {
                // User is signed in
                Android.Util.Log.Debug(TAG, "onAuthStateChanged:signed_in:" + user.Uid);
            }
            else
            {
                // User is signed out
                Android.Util.Log.Debug(TAG, "onAuthStateChanged:signed_out");
            }
            // [START_EXCLUDE]
            //UpdateUI(user);
            // [END_EXCLUDE]
        }

        // [START on_start_add_listener]
        protected override void OnStart()
        {
            base.OnStart();
            mAuth.AuthState += AuthStateChanged;
        }
        // [END on_start_add_listener]

        // [START on_stop_remove_listener]
        protected override void OnStop()
        {
            base.OnStop();
            mAuth.AuthState -= AuthStateChanged;
        }
        // [END on_stop_remove_listener]

        async Task CreateAccount(string email, string password)
        {
            Android.Util.Log.Debug(TAG, "createAccount:" + email);
            if (!ValidateForm())
                return;
            // ShowProgressDialog();

            try
            {
                await mAuth.CreateUserWithEmailAndPasswordAsync(email, password);
            }
            catch
            {
                Toast.MakeText(this, "Authentication failed.", ToastLength.Short).Show();
            }

            // [START_EXCLUDE]
            //HideProgressDialog();
            // [END_EXCLUDE]
        }
        bool ValidateForm()
        {
            var valid = true;

            var email = mEmailField.Text;
            if (TextUtils.IsEmpty(email))
            {
                mEmailField.Error = "Required.";
                valid = false;
            }
            else
            {
                mEmailField.Error = null;
            }

            var password = mPasswordField.Text;
            if (TextUtils.IsEmpty(password))
            {
                mPasswordField.Error = "Required.";
                valid = false;
            }
            else
            {
                mPasswordField.Error = null;
            }

            return valid;
        }

        /* void UpdateUI(FirebaseUser user)
         {
             //HideProgressDialog();
             if (user != null)
             {
                 mStatusTextView.Text = GetString(Resource.String.emailpassword_status_fmt, user.Email);
                 mDetailTextView.Text = GetString(Resource.String.firebase_status_fmt, user.Uid);

                // FindViewById(Resource.Id.email_password_buttons).Visibility = ViewStates.Gone;
                // FindViewById(Resource.Id.email_password_fields).Visibility = ViewStates.Gone;
                // FindViewById(Resource.Id.sign_out_button).Visibility = ViewStates.Visible;
             }
             else
             {
                 mStatusTextView.SetText(Resource.String.signed_out);
                 mDetailTextView.Text = null;

                 FindViewById(Resource.Id.email_password_buttons).Visibility = ViewStates.Visible;
                 FindViewById(Resource.Id.email_password_fields).Visibility = ViewStates.Visible;
                 FindViewById(Resource.Id.sign_out_button).Visibility = ViewStates.Gone;
             }
         }*/



        /*protected override void OnCreate(Bundle bundle)
         {
             TabLayoutResource = Resource.Layout.Tabbar;
             ToolbarResource = Resource.Layout.Toolbar;

             base.OnCreate(bundle);

             global::Xamarin.Forms.Forms.Init(this, bundle);
             LoadApplication(new App());
         }*/

        private void InitFirebaseAuth()
        {
            // Codurile de mai jos sunt luate din Firebase
            var options = new FirebaseOptions.Builder()
            .SetApplicationId("1:201771064556:android:113c2ec3195cec6f")
            .SetApiKey("AIzaSyC3jUl2EuxiyZfl7XHZezRO3Gr7Wsx9dt4")
            .Build();

            /* Celalalt ApiKey: AIzaSyC3jUl2EuxiyZfl7XHZezRO3Gr7Wsx9dt4 */

            if (app == null ){
                app = FirebaseApp.InitializeApp(this, options);
            }
            mAuth = FirebaseAuth.GetInstance(app);
        }

}
}
