using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using MVA.Models;
using MVA.Models.ProjectModel;
using Xamarin.Forms;

namespace MVA.Helper
{
    
    public class ProjectHelper
    {
        private static string url = "https://localhost:5001/projects/";


        public static bool AddProject(NewProjectParticpants projectData)
        {
            bool isSucessful = false;
            Project project = new Project();
            project.ProjectName = projectData.newProjectVarables.critera.ProojectData.ProjectName;
            project.ProjectCreator = Application.Current.Properties["User"].ToString();
            project.ProjectCreateDate = DateTime.Now;
            project.DependentVariable = projectData.newProjectVarables.dependentVarable;
            project.RoleFk = projectData.newProjectVarables.critera.ProojectData.RoleFK;
            project.TypeFk = projectData.newProjectVarables.critera.ProojectData.ResearchTypeFK;
            project.OutputTypeFk = projectData.newProjectVarables.critera.ProojectData.OutputTypeFK;
            project.UpperLimit = projectData.newProjectVarables.upperLimit;
            project.InterventionCode = projectData.InterventionstCode;
            project.AnalystCode = projectData.AnaylystCode;
            project.Participants = projectData.Particpants;

            Critera critera = new Critera();
            critera.BaselinePoints = projectData.newProjectVarables.critera.numofBaselinePoints;
            critera.InterventionPoints = projectData.newProjectVarables.critera.numofinterventionPoints;
            critera.MinStaggerPoints = projectData.newProjectVarables.critera.numOfMinStaggerPoints;
            critera.NumofParticipants = projectData.newProjectVarables.critera.numofParticpants;
            if(projectData.newProjectVarables.critera.outlierFK == 0)
            {
                critera.OutlierFk = null;
            }
            else
            {
                critera.OutlierFk = projectData.newProjectVarables.critera.outlierFK.GetValueOrDefault();
            }
            
            NewProjectRequest projectRequest = new NewProjectRequest();
            projectRequest.critera = critera;
            projectRequest.project = project;

            var clinet = new RestClient(url + "create");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(projectRequest);
            var respose = clinet.Execute(request);

            if (respose.IsSuccessful)
            {
                isSucessful = true;
            }
            else
            {
                isSucessful = false;
            }

            return isSucessful;

        }
    }
}
