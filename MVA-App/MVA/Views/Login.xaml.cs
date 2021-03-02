using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MVA.Models;

using Xamarin.Forms;

namespace MVA
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            Title = "Log in";
           
        }

        void loginButton_Clicked(System.Object sender, System.EventArgs e)
        {


            var loginmodel = new UserLoginModel();

            if (string.IsNullOrEmpty(txtUserName.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                DisplayAlert("Error", "Username and Password is required", "OK");
            }

            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                DisplayAlert("Error", "Username is required", "OK");
            }

            else if(string.IsNullOrEmpty(txtPassword.Text))
            {
                DisplayAlert("Error", "Password is Required", "OK");
            }
            else
            {
                loginmodel.username = txtUserName.Text.ToLower();
                loginmodel.password = txtPassword.Text;
                var jsonstr = JsonConvert.SerializeObject(loginmodel);
                var clinet = new RestClient("https://localhost:5001/users/authenticate");
                clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
                var request = new RestRequest(Method.POST);
                request.AddJsonBody(loginmodel);
                var response = clinet.Execute(request);

                if (response.IsSuccessful)
                {
                    var loginresponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);
                    Application.Current.Properties["Token"] = loginresponse.Token;
                    Application.Current.Properties["User"] = loginresponse.Username;
                    DisplayAlert("Yay", "Login successfull", "OK");
                    Navigation.PushAsync(new HomePage());
                }
               
            }

            

            
        }

        void createAccountButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }

    }
}
