using System;
using System.Collections.Generic;
using MVA.Helper;
using MVA.Models;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace MVA
{
    public partial class SignUp : ContentPage
    {
        private static string url = "https://localhost:5001/users/createuser";
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
            var highestdegree = pickerHighestDegree.SelectedItem as Degree;
            var industry = pickerIndustry.SelectedItem as Industry;

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                DisplayAlert("Error", "Email Address is required", "OK");
            }
            else if(string.IsNullOrEmpty(txtPassword.Text))
            {
                DisplayAlert("Error", "Password is required", "OK");
            }
            else if(string.IsNullOrEmpty(txtUserName.Text))
            {
                DisplayAlert("Error", "UserName is required", "OK");
            }
            else if(industry.codeIndustryPk == 0)
            {
                DisplayAlert("Error", "Industry is required", "OK");
            }
            else if(highestdegree.codeDegreePk == 0)
            {
                DisplayAlert("Error", "Highest Degree is required", "OK");
            }
            else
            {
                CreateUserModel createUserModel = new CreateUserModel();


                createUserModel.emailaddress = txtEmail.Text;
                createUserModel.HighestDegree = highestdegree.codeDegreePk;
                createUserModel.Industry = industry.codeIndustryPk;
                createUserModel.username = txtUserName.Text.ToLower();
                createUserModel.password = txtPassword.Text;
                var clinet = new RestClient(url);
                clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
                var request = new RestRequest(Method.POST);
                request.AddJsonBody(createUserModel);
                var response = clinet.Execute(request);

                if (response.IsSuccessful)
                {
                    DisplayAlert("Account Created", "The account has been created successfully." +
                        " You can now login using the username and password that was entered. ", "OK");

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "There was a error creating the account. Please try again", "OK");
                }
            }
           


        }
    }
}
