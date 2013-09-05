using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PickANick.Core;
using PickANick.Core.ViewModels;

namespace PickANick.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            ServiceContainer.Register<NickViewModel>();
            ServiceContainer.Register<INickServer>(() => new FakeNickServer());

            return true;
        }
    }
}

