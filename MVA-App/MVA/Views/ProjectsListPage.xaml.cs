using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MVA
{
    public partial class ProjectsListPage : ContentPage
    {
        private string mode = "";
        public ProjectsListPage()
        {
            InitializeComponent();
        }

        public ProjectsListPage(string type)
        {
            Title = "Projects";
            InitializeComponent();
            mode = type;

           
        }

        void btnAddProject_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProjectCodePage(mode));
        }
    }
}
