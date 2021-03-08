using System;
using System.Collections.Generic;
using MVA.Models;
using MVA.Models.ProjectModel;
using MVA.Helper;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MVA
{
    public partial class NewParticpantPage : ContentPage
    {
        private NewProjectVarables _projectData;
        public NewParticpantPage()
        {
            InitializeComponent();
        }

        public NewParticpantPage(NewProjectVarables newProjectVarables)
        {
            InitializeComponent();
            _projectData = newProjectVarables;
            Title = "Enter Your Participants";

            for(int i = 0; i < newProjectVarables.critera.numofParticpants; i++)
            {
                Entry entrypartipant = new Entry();
                entrypartipant.Placeholder = "Particpant " + (i + 1).ToString();
                stacklayout.Children.Add(entrypartipant);
            }
        }

        async void btnSubmit_Clicked(System.Object sender, System.EventArgs e)
        {
            var isValid = ValidateInput();

            if(!isValid)
            {
                await DisplayAlert("Error", "One or more of the Partipants input boxes is empty. Please review your input and try again", "OK");
            }
            else
            {
                NewProjectParticpants newProjectParticpants = new NewProjectParticpants();
                newProjectParticpants.newProjectVarables = _projectData;
                newProjectParticpants.InterventionstCode = Utilities.GeneratePassword();
                newProjectParticpants.AnaylystCode = Utilities.GeneratePassword();
                newProjectParticpants.Particpants = GetParticipants();

               var success =  ProjectHelper.AddProject(newProjectParticpants);


                if(success)
                {
                    string action = await DisplayActionSheet("Project Saved Successfully ", "Cancel", null, "Share Interventionst Code", "Share Analyst Code", "OK");
                    

                    if(action == "Share Interventionst Code")
                    {
                        await Share.RequestAsync(new ShareTextRequest
                        {
                            Text = newProjectParticpants.InterventionstCode,
                            Title = "Interventionst Code"
                        });
                    }
                    else if(action == "Share Analyst Code")
                    {
                        await Share.RequestAsync(new ShareTextRequest
                        {
                            Text = newProjectParticpants.AnaylystCode,
                            Title = "Analyst Code"
                        });
                    }
                    else
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                }
                else
                {
                   await DisplayAlert("Error", "error adding project", "OK");
                }
            }
        }

        private bool ValidateInput()
        {
            var allInputs = stacklayout.Children.Where(x => x is Entry);
            foreach (var input in allInputs)
            {
                Entry txtbox = (Entry)input;

                if(string.IsNullOrEmpty(txtbox.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }


        private string GetParticipants()
        {
            List<string> names = new List<string>();
            var allInputs = stacklayout.Children.Where(x => x is Entry);
            foreach (var input in allInputs)
            {
                Entry txtbox = (Entry)input;
                names.Add(txtbox.Text);
            }

            if(names.Count >= 1)
            {
                var formattedstring = string.Join(",", names);
                return formattedstring;
            }
            else
            {
                return names.FirstOrDefault();
            }
        }

       
    }
}
