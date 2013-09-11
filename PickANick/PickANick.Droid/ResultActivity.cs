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
using Android.Graphics.Drawables;
using System.IO;
using Android.Graphics;

namespace PickANick.Droid
{
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        private NickViewModel _nickViewModel;
        private TextView _resultText;
        private TextView _greetingsText;

        private ImageView _greetingsImage;
        private ImageView _nicImage;
        private ImageView _itemImage;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _nickViewModel = ServiceContainer.Resolve<NickViewModel>();

            SetContentView(Resource.Layout.ResultLayout);

            Typeface fancy = Typeface.CreateFromAsset(Assets, "Fonts/Snell Roundhand Script.ttf");
            _greetingsText = FindViewById<TextView>(Resource.Id.greetingsText);
            _greetingsText.Text = string.Empty;
            _greetingsText.Typeface = fancy;

            _resultText = FindViewById<TextView>(Resource.Id.resultText);
            _resultText.Text = "Traveling...";

            _greetingsImage = FindViewById<ImageView>(Resource.Id.greetingsImage);
            _nicImage = FindViewById<ImageView>(Resource.Id.nickImage);
            _itemImage = FindViewById<ImageView>(Resource.Id.itemImage);

            _greetingsImage.SetImageBitmap(null);
            _nicImage.SetImageBitmap(null);
            _itemImage.SetImageBitmap(null);

            var adventureButton = FindViewById<Button>(Resource.Id.adventureButton);
            adventureButton.Click += (sender, e) =>
                {
                    StartActivity(typeof(MainActivity));
                };
        }

        protected async override void OnStart()
        {
            base.OnStart();

            await _nickViewModel.GetLocation();
            await _nickViewModel.GetItem();
            _nickViewModel.GetStrings();

            string nick = _nickViewModel.PickedNick.Name;
            string location = _nickViewModel.Location.Name;
            string item = _nickViewModel.Item.Name;

            _greetingsText.Text = _nickViewModel.GreetingString;
            _resultText.Text = _nickViewModel.ResultString;

            string ImageName = System.IO.Path.GetFileNameWithoutExtension(_nickViewModel.PickedNick.ImageName);
            int id = Resources.GetIdentifier(ImageName, "drawable", PackageName);
            _nicImage.SetImageResource(id);

            if (_nickViewModel.Location.Local)
            {
                ImageName = System.IO.Path.GetFileNameWithoutExtension(_nickViewModel.Location.ImageName);
                id = Resources.GetIdentifier(ImageName, "drawable", PackageName);
                _greetingsImage.SetImageResource(id);
            }
            else
            {
                try
                {
                    Java.Net.URL locationUrl = new Java.Net.URL(_nickViewModel.Location.ImageName);
                    Bitmap bitmap = BitmapFactory.DecodeStream(locationUrl.OpenConnection().InputStream);
                    _greetingsImage.SetImageBitmap(bitmap);
                }
                catch ( Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
            }

            ImageName = System.IO.Path.GetFileNameWithoutExtension(_nickViewModel.Item.ImageName);
            id = Resources.GetIdentifier(ImageName, "drawable", PackageName);
            _itemImage.SetImageResource(id);
        }
    }
}