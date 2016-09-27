using Android.App;
using Android.OS;

namespace EixemX.Droid.Activities.Splash
{
    [Activity(Theme = "@style/Theme.Splash",
         MainLauncher = true,
         NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.SetTitleBarVisibility(Xamarin.Forms.AndroidTitleBarVisibility.Never);
            StartActivity(typeof(MainActivity));
        }
    }
}