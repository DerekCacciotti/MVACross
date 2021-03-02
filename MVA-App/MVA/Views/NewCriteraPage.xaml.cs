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
           
        }

        void btncriteraNext_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
