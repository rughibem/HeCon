using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HeCon.Droid
{
    class ListViewLogin:BaseAdapter
    {
        Activity activity;
        List<Account> lstAccounts;
        LayoutInflater inflater;

        public ListViewLogin(Activity activity, List<Account> lstAccounts)
        {
            this.activity = activity;
            this.lstAccounts = lstAccounts;
        }
        public override int Count
        {
            get { return lstAccounts.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            inflater = (LayoutInflater)activity.BaseContext.GetSystemService(Context.LayoutInflaterService);
            View itemView = inflater.Inflate(Resource.Layout.login, null);
            var email = itemView.FindViewById<TextView>(Resource.Id.emailEditText);
            var password = itemView.FindViewById<TextView>(Resource.Id.passwordEditText);
            if (lstAccounts.Count > 0)
            {
                email.Text = lstAccounts[position].Email;
               password.Text = lstAccounts[position].Password;
            }
            return itemView;
        }
    }
}