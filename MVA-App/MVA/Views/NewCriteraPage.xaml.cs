using System;
using System.Collections.Generic;
using MVA.Models;
using MVA.Models.ProjectModel;
using System.Linq;
using MVA.Helper;

using Xamarin.Forms;

namespace MVA
{
    public partial class NewCriteraPage : ContentPage
    {
        private NewProjectInit _initdata;
        public NewCriteraPage()
        {
            InitializeComponent();
        }

        public NewCriteraPage(NewProjectInit newProjectInit)
        {
            InitializeComponent();
            _initdata = newProjectInit;
            Title = "Add Criteria";
            pickerOutlier.ItemsSource = Utilities.GetOutliers();
            pickerOutlier.SelectedIndex = 0;
            NavigationPage.SetBackButtonTitle(this, "Back");

        }

        void btncriteraNext_Clicked(System.Object sender, System.EventArgs e)
        {
            var outlier = pickerOutlier.SelectedItem as Outlier;

            if(string.IsNullOrEmpty(txtNumofParticpants.Text) || txtNumofParticpants.Text == "0")
            {
                DisplayAlert("Error", "Number of Particpants is required", "OK");
            }
            else if(string.IsNullOrEmpty(txtNumofBaselinepoints.Text) || txtNumofBaselinepoints.Text == "0")
            {
                DisplayAlert("Error", "Number of baseline points is required", "OK");
            }
            else if(string.IsNullOrEmpty(txtnumOfInterventionPoints.Text) || txtnumOfInterventionPoints.Text == "0")
            {
                DisplayAlert("Error", "Number of intervention points is required", "OK");
            }
            else if(string.IsNullOrEmpty(txtnumofmininiumStaggerPoints.Text) || txtnumofmininiumStaggerPoints.Text == "0")
            {
                DisplayAlert("Error", "Number of Mininium Stagger Points is required", "OK");
            }
            else
            {
                NewProjectCritera projectCritera = new NewProjectCritera();
                projectCritera.ProojectData = _initdata;
                projectCritera.numofBaselinePoints = Convert.ToInt32(txtNumofParticpants.Text);
                projectCritera.numofinterventionPoints = Convert.ToInt32(txtnumOfInterventionPoints.Text);
                projectCritera.numOfMinStaggerPoints = Convert.ToInt32(txtnumofmininiumStaggerPoints.Text);
                projectCritera.numofParticpants = Convert.ToInt32(txtNumofParticpants.Text);

                if(outlier.codeOutlierPk == 0)
                {
                    projectCritera.outlierFK = null;
                }
                else
                {
                    projectCritera.outlierFK = outlier.codeOutlierPk;
                }

                Navigation.PushAsync(new ProjectVarablesPage(projectCritera));

            }
        }
    }
}
