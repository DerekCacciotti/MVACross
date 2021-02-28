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

    }
    }

