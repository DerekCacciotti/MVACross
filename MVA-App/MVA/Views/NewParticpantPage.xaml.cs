using System;
using System.Collections.Generic;
using MVA.Models;
using MVA.Models.ProjectModel;
using MVA.Helper;

using Xamarin.Forms;

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
                entrypartipant.Placeholder = "Particpant " + i.ToString();
                stacklayout.Children.Add(entrypartipant);
            }
        }
    }
}
