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

        // interventionst
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProjectsListPage("interventionst"));
        }
        // analyst 
        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProjectsListPage("analyst"));
        }
    }
}
