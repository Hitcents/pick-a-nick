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
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        private NickViewModel _nickViewModel;
        private TextView _resultText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _nickViewModel = ServiceContainer.Resolve<NickViewModel>();

            SetContentView(Resource.Layout.ResultLayout);

            _resultText = FindViewById(Resource.Id.resultText) as TextView;

            _resultText.Text = "Traveling...";
        }

        protected async override void OnStart()
        {
            base.OnStart();

            await _nickViewModel.GetLocation();
            await _nickViewModel.GetItem();

            string nick = _nickViewModel.PickedNick.Name;
            string location = _nickViewModel.Location.Name;
            string item = _nickViewModel.Item.Name;

            _resultText.Text = nick + " went to " + location + "and brought back " + item;
        }
    }
}