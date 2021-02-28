using System;
using System.Collections.Generic;
using MVA.Helper;

using Xamarin.Forms;

namespace MVA
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            Title = "Create Account";
            pickerHighestDegree.ItemsSource = Utilities.GetDegrees();
            pickerHighestDegree.SelectedIndex = 0;
            pickerIndustry.ItemsSource = Utilities.GetIndustries();
            pickerIndustry.SelectedIndex = 0;
            

        }

        void createAccountButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
