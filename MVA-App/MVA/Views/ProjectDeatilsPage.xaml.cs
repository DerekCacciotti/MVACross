using System;
using System.Collections.Generic;
using MVA.Helper;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            Title = "Project Details";
        }

        void btnDetails_Clicked(System.Object sender, System.EventArgs e)
        {
            var details = ProjectHelper.GetCrierta(_ProjectPK);

            DisplayAlert("Details", details.baselinePoints.ToString(),"OK");


        }
    }
}
