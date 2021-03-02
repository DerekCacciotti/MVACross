using System;
using System.Collections.Generic;
using System.Linq;
using MVA.Helper;
using MVA.Models;
using MVA.Models.ProjectModel;
using Xamarin.Forms;

namespace MVA
{
    public partial class NewProjectPage : ContentPage
    {
        public NewProjectPage()
        {
            InitializeComponent();
            Title = "New Project";
            pickerRole.ItemsSource = Utilities.GetRoles();
            pickerRole.SelectedIndex = 0;

            pickerOutputType.ItemsSource = Utilities.GetOutputTypes();
            pickerOutputType.SelectedIndex = 0;

            pickerResearchType.ItemsSource = Utilities.GetResearchTypes();
            pickerResearchType.SelectedIndex = 0;
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        void btnNewProjectNext_Clicked(System.Object sender, System.EventArgs e)
        {
            var role = pickerRole.SelectedItem as Roles;
            var outputType = pickerOutputType.SelectedItem as OutputTypes;
            var resarchTypes = pickerResearchType.SelectedItem as ResearchTypes;

            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                DisplayAlert("Error", "Project Name is reuired", "OK");
            }
            else if (role.codeRolePk == 0)
            {
                DisplayAlert("Error", "Role is required is reuired", "OK");
            }
            else if (outputType.idcodeOutputTypePk == 0)
            {
                DisplayAlert("Error", "OutputType is required", "OK");
            }
            else if(resarchTypes.idcodeResearchTypePk == 0)
            {
                DisplayAlert("Error", "Research Type is reuired", "OK");
            }
            else
            {
                NewProjectInit projectInit = new NewProjectInit();
                projectInit.ProjectName = txtProjectName.Text;
                projectInit.RoleFK = role.codeRolePk;
                projectInit.OutputTypeFK = outputType.idcodeOutputTypePk;
                projectInit.ResearchTypeFK = resarchTypes.idcodeResearchTypePk;
                Navigation.PushAsync(new NewCriteraPage(projectInit));
            }
        }

      
    }
}
