using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using MVA.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace MVA.Helper
{
    public class Utilities
    {
        private static string url = "https://localhost:5001/projects/";
        public static List<Degree> GetDegrees()
        {
            var clinet = new RestClient(url + "degree");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.GET);
            var response = clinet.Execute(request);

            if(response.IsSuccessful)
            {
                var degrees = JsonConvert.DeserializeObject<Degree.DegreeRoot>(response.Content);

                Degree select = new Degree();
                select.codeDegreePk = 0;
                select.degreeName = "--SELECT--";
                degrees.degrees.Insert(0, select);
                return degrees.degrees;
            }
            else
            {
                return null;
            }
        }

        public static List<Industry> GetIndustries()
        {
            var clinet = new RestClient(url + "industry");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.GET);
            var response = clinet.Execute(request);

            if(response.IsSuccessful)
            {
                Industry select = new Industry();
                select.codeIndustryPk = 0;
                select.industryName = "--SELECT--";

                var industries = JsonConvert.DeserializeObject<IndustryRoot>(response.Content);
                industries.industry.Insert(0, select);
                return industries.industry;
            }
            else
            {
                return null;
            }
        }

        public static List<Roles> GetRoles()
        {
            var clinet = new RestClient(url + "roles");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.GET);
            var respose = clinet.Execute(request);

            if(respose.IsSuccessful)
            {
                Roles select = new Roles();
                select.codeRolePk = 0;
                select.roleName = "--SELECT--";
                var roles = JsonConvert.DeserializeObject<RootRoles>(respose.Content);
                roles.rolesobj.Insert(0, select);
                return roles.rolesobj;

            }
            else
            {
                return null;
            }

        }

        public static List<ResearchTypes> GetResearchTypes()
        {
            var clinet = new RestClient(url + "researchtypes");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.GET);
            var respose = clinet.Execute(request);

            if (respose.IsSuccessful)
            {
                ResearchTypes select = new ResearchTypes();
                select.idcodeResearchTypePk = 0;
                select.researchType = "--SELECT--";
                var types = JsonConvert.DeserializeObject<ResearchTypesRoot>(respose.Content);
                types.types.Insert(0, select);
                return types.types;

            }
            else
            {
                return null;
            }

        }


        public static List<OutputTypes> GetOutputTypes()
        {
            var clinet = new RestClient(url + "output");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.GET);
            var respose = clinet.Execute(request);

            if (respose.IsSuccessful)
            {
                OutputTypes select = new OutputTypes();
                select.idcodeOutputTypePk = 0;
                select.outputType = "--SELECT--";
                var outputTypes = JsonConvert.DeserializeObject<OutputTypesRoot>(respose.Content);
                outputTypes.outputtypes.Insert(0, select);
                return outputTypes.outputtypes;

            }
            else
            {
                return null;
            }

        }

        public static List<Outlier> GetOutliers()
        {
            var clinet = new RestClient(url + "outlier");
            clinet.RemoteCertificateValidationCallback = (xsender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.GET);
            var respose = clinet.Execute(request);

            if (respose.IsSuccessful)
            {
                Outlier select = new Outlier();
                select.codeOutlierPk = 0;
                select.outlierType = "--SELECT--";
                var outlier = JsonConvert.DeserializeObject<OutlierRoot>(respose.Content);
                outlier.outliersobj.Insert(0, select);
                return outlier.outliersobj;
            }
            else
            {
                return null;
            }
        }


    }
}

