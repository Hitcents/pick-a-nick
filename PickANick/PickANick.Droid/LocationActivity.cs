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
using PickANick.Core.ViewModels;
using PickANick.Core;

namespace PickANick.Droid
{
    [Activity(Label = "LocationActivity")]
    public class LocationActivity : Activity
    {
        private NickViewModel _nickViewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _nickViewModel = ServiceContainer.Resolve<NickViewModel>();

            SetContentView(Resource.Layout.LocationLayout);

            EditText locationText = FindViewById(Resource.Id.locationField) as EditText;
            Button submitButton = FindViewById(Resource.Id.submitButton) as Button;

            submitButton.Click += (sender, e) =>
                {
                    _nickViewModel.LocationSearch = locationText.Text;
                    StartActivity(typeof(ResultActivity));
                };

        }
    }
}