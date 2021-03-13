using System;
using System.Collections.Generic;
using MVA.Models;
using MVA.Helper;

using Xamarin.Forms;

namespace MVA
{
    public partial class ProjectCodePage : ContentPage
    {
        private string mode = "";
        public ProjectCodePage()
        {
            InitializeComponent();
        }

        public ProjectCodePage(string Type)
        {
            Title = "Enter Code";
            InitializeComponent();
            mode = Type;

            if (Type == "interventionst")
            {
                lblheader.Text = "Please enter your interventionst code";
            }
            else
            {
                lblheader.Text = "Please enter your analyst code";
            }
           
        }

        void btnSubmit_Clicked(System.Object sender, System.EventArgs e)
        {
            int userpk = Convert.ToInt32(Application.Current.Properties["UserPK"].ToString());
            int rolefk = GetRole(mode);
            string code = txtcode.Text;
            VeifyCodeRequest codeRequest = new VeifyCodeRequest();
            codeRequest.RoleFK = rolefk;
            codeRequest.UserFK = userpk;
            codeRequest.Code = code;
            ProjectHelper.VerifyandAddProject(codeRequest);

        }

        private int GetRole(string role)
        {
            if (role == "interventionst")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

    }
}
