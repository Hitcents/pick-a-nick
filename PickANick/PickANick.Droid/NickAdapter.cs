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
using PickANick.Core;

namespace PickANick.Droid
{
    public class NickAdapter : BaseAdapter<Nick>
    {
        private Nick[] _nicks;
        private Activity _context;

        public NickAdapter(Activity context, Nick[] nicks)
        {
            _context = context;
            _nicks = nicks;
        }

        public override Nick this[int position]
        {
            get { return _nicks[position]; }
        }

        public override int Count
        {
            get { return _nicks.Length; }
        }

        public override long GetItemId(int position)
        {
            return _nicks[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var nick = _nicks[position];
            View view = convertView;

            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.NickRow, null);
                convertView = view;
            }

            var text = view.FindViewById<TextView>(Resource.Id.nickName);
            text.Text = nick.Name;

            return view;
        }
    }
}