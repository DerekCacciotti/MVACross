using System;
using System.Collections.Generic;
using Syncfusion.XForms.Cards;

using Xamarin.Forms;

namespace MVA
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            Title = "Single Case Design MVA";
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetBackButtonTitle(this, "Back");



        }

        void btnAdd_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewProjectPage());
        }

        void btnSettings_Clicked(System.Object sender, System.EventArgs e)
        {
        }

    }
}
