using System;
using System.Collections.Generic;
using MVA.Models;
using MVA.Models.ProjectModel;

using Xamarin.Forms;

namespace MVA
{
    public partial class ProjectVarablesPage : ContentPage
    {
        private NewProjectCritera _projectData;
        public ProjectVarablesPage()
        {
            InitializeComponent();
        }
        
        public ProjectVarablesPage(NewProjectCritera newProjectCritera)
        {
            Title = "Other Information";
            NavigationPage.SetBackButtonTitle(this, "Back");
            InitializeComponent();
            _projectData = newProjectCritera;

        }

        void btnVarablesNext_Clicked(System.Object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDependentVarable.Text))
            {
                DisplayAlert("Error", "Dependent variable is required", "OK");

            }
            else if(string.IsNullOrEmpty(txtUpperLimit.Text))
            {
                DisplayAlert("Error", "Upper Limit is required", "OK");
            }
            else
            {
                NewProjectVarables projectVarables = new NewProjectVarables();
                projectVarables.critera = _projectData;
                projectVarables.dependentVarable = txtDependentVarable.Text;
                projectVarables.upperLimit = Convert.ToInt32(txtUpperLimit.Text);
                Navigation.PushAsync(new NewParticpantPage(projectVarables));
            }
        }
    }
}
