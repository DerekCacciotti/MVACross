using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using MVA.Models;
using MVA.Models.ProjectModel;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public static bool VerifyandAddProject(VeifyCodeRequest veifyCodeRequest)
        {
            bool isSuccessfull = false;
            var clinet = new RestClient(url + "verifycode");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(veifyCodeRequest);
            var response = clinet.Execute(request);

            if(response.IsSuccessful)
            {
                isSuccessfull = true;
            }
            else
            {
                isSuccessfull = false;
            }

            return isSuccessfull;

        }

        public static List<Project> GetProjects(ProjectsListRequest projectsList)
        {
            List<Project> projects = new List<Project>();

            var clinet = new RestClient(url + "allprojects");
             clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(projectsList);
            var response = clinet.Execute(request);
            projects = JsonConvert.DeserializeObject<List<Project>>(response.Content);

            if (response.IsSuccessful)
            {
                return projects;
            }
            else
            {
                return null;
            }
        }


        public static ProjectsDetailsModel GetCrierta(int ProjectPK)
        {
            var clinet = new RestClient(url + "getcritera");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.POST);
            CiretaRequest ciretaRequest = new CiretaRequest();
            ciretaRequest.ProjectFK = ProjectPK;
            request.AddJsonBody(ciretaRequest);
            var response = clinet.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<ProjectsDetailsModel>(response.Content);
            }
            else
            {
                return null;
            }
            

        }

        public static List<Particpant> GetParticpants(int ProjectPK)
        {
            List<Particpant> particpants = new List<Particpant>();
            var clinet = new RestClient(url + "getparticpants");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.POST);
            ParticpantsRequest particpantsRequest = new ParticpantsRequest();
            particpantsRequest.ProjectPK = ProjectPK;
            request.AddJsonBody(particpantsRequest);
            var response = clinet.Execute(request);
            if(response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<ParticpantResponse>(response.Content);

                foreach(var person in data.particpants)
                {
                    Particpant particpant = new Particpant();
                    particpant.Name = person;
                    particpants.Add(particpant);
                }

                return particpants;


            }
            else
            {
                return null;
            }
        }
    }
}
