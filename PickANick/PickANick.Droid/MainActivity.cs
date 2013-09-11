using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PickANick.Core.ViewModels;
using PickANick.Core;
using Android.Content.PM;

namespace PickANick.Droid
{
    [Activity(Label = "PickANick.Droid", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private NickViewModel _nickViewModel;
        private Nick[] _nicks;

        protected async override void OnCreate(Bundle bundle)
        {           
            base.OnCreate(bundle);

            ServiceContainer.Register<NickViewModel>();
            ServiceContainer.Register<INickServer>(() => new FakeNickServer());

            _nickViewModel = ServiceContainer.Resolve<NickViewModel>();

            await _nickViewModel.GetNicks();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _nicks = _nickViewModel.Nicks;

            var nickList = FindViewById<ListView>(Resource.Id.nickList);
            nickList.Adapter = new NickAdapter(this, _nicks);
            nickList.ItemClick += OnItemClick;
        }
        
        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            _nickViewModel.PickedNick = _nicks[e.Position];
            StartActivity(typeof(LocationActivity));
        }
    }
}

