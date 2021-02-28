using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navpage = new NavigationPage(new Login());
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.SetPrefersLargeTitles(navpage, true);

            MainPage = navpage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
