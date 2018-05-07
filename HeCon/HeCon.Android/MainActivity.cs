using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
//using Firebase.js;
using Android.Support.V7.App;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
//using Firebase.Xamarin;

namespace HeCon.Droid
{
    [Activity(Label = "HeCon", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AppCompatActivity
    {

        private EditText input_email, input_password;
        private ListView list_data;
        private ProgressBar circular_progress;
        private List<Account> list_users = new List<Account>();
        private ListViewLogin adapter;
        private Account selectedAccount;
        private const string FirebaseURL = "hhttps://hecon-e36fa.firebaseio.com/"; //Firebase Database URL  


         /*protected override void OnCreate(Bundle bundle)
          {
              TabLayoutResource = Resource.Layout.Tabbar;
              ToolbarResource = Resource.Layout.Toolbar;

              base.OnCreate(bundle);

              global::Xamarin.Forms.Forms.Init(this, bundle);
              LoadApplication(new App());
          }*/

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
          //  SetContentView(Resource.Layout.Main);

         
           // input_email = FindViewById<EditText>(Resource.Id.Email);
           // input_password = FindViewById<EditText>(Resource.Id.Password);
           // list_data = FindViewById<ListView>(Resource.Id.login);
            list_data.ItemClick += (s, e) =>
            {
                Account account = list_users[e.Position];
                selectedAccount = account;
                input_email.Text = account.Email;
                input_password.Text = account.Password;
            };
            await LoadData();
        }
        private async Task LoadData()
        {
          
            list_data.Visibility = ViewStates.Invisible;
            //var firebase = new FirebaseClient(FirebaseURL);
           /* var items = await firebase
                .Child("users")
                .OnceAsync<Account>();
            list_users.Clear();
           // adapter = null;
/*foreach (var item in items)
            {
                Account account = new Account();
                account.Uid = item.Key;
                account.Email = item.Object.Email;
                account.Password = item.Object.Password;
                list_users.Add(account);
            }*/
         //   adapter = new ListViewAdapter(this, list_users);
           // adapter.NotifyDataSetChanged();
          //  list_data.Adapter = adapter;
            list_data.Visibility = ViewStates.Visible;
        }
    }
}

