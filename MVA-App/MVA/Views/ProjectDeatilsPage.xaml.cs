using System;
using System.Collections.Generic;
using MVA.Helper;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MVA.Models;
namespace MVA
{
    public partial class ProjectDeatilsPage : ContentPage
    {
        private int _ProjectPK = 0;
        public ProjectDeatilsPage()
        {
            InitializeComponent();
        }

        public ProjectDeatilsPage(int ProjectPK)
        {
            InitializeComponent();
            _ProjectPK = ProjectPK;
           // Title = "Project Details";
            StatusRequest statusRequest = new StatusRequest();
            statusRequest.ProjectPK = ProjectPK;

            var projectstatus = Utilities.GetStatus(statusRequest);

            if(!string.IsNullOrEmpty(projectstatus))
            {
                lblstatus.Text = projectstatus;
            }
            else
            {
                lblstatus.Text = "";
            }


            var particpantsresp = ProjectHelper.GetParticpants(ProjectPK);

           if(particpantsresp.Count != 0)
            {
                particpantsListView.ItemsSource = particpantsresp;
            }


        }

        void btnDetails_Clicked(System.Object sender, System.EventArgs e)
        {
            string outlierType = "";
            var details = ProjectHelper.GetCrierta(_ProjectPK);

            if(details.outlierFkNavigation != null)
            {
                outlierType = details.outlierFkNavigation.outlierType;
            }
            else
            {
                outlierType = "N/A";
            }

            DisplayAlert("Details", string.Format("Baseline Points: {0}" + Environment.NewLine + "Stagger Points: {1}" + Environment.NewLine + "Number of Partiipants: {2}" + Environment.NewLine
                + "Number of Intervenion points : {3}" + Environment.NewLine + "Outliter: {4}",
                details.baselinePoints.ToString(), details.minStaggerPoints.ToString(), details.numofParticipants.ToString(), details.interventionPoints.ToString(), outlierType),"OK");


        }
    }
}
