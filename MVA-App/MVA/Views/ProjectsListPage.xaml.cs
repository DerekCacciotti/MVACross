using System;
using System.Collections.Generic;
using MVA.Helper;
using Xamarin.Forms;
using MVA.Models;
namespace MVA
{
    public partial class ProjectsListPage : ContentPage
    {
        private string mode = "";
        private int UserPK = 0;
        private int RoleFK = 0;

        public ProjectsListPage()
        {
            InitializeComponent();
        }

        public ProjectsListPage(string type)
        {
            Title = "Projects";
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Back");
            mode = type;

            if(Application.Current.Properties["UserPK"] != null)
            {
                UserPK = Convert.ToInt32(Application.Current.Properties["UserPK"].ToString());
            }

            RoleFK = GetRole(mode);

            ProjectsListRequest projectsListRequest = new ProjectsListRequest();
            projectsListRequest.UserFK = UserPK;
            projectsListRequest.RoleFK = RoleFK;

            var projects = ProjectHelper.GetProjects(projectsListRequest);

            ProjectsListView.ItemsSource = projects;

            

           
        }

        void btnAddProject_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProjectCodePage(mode));
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

        void ProjectsListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selecteditem = e.SelectedItem as Project;
            Navigation.PushAsync(new ProjectDeatilsPage(selecteditem.ProjectPk));
        }
    }
}
