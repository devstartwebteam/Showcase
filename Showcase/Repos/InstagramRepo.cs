using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using log4net;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json;
using RestSharp;
using Showcase.Interfaces;
using Showcase.Models;
using Showcase.ViewModels;

namespace Showcase.Repos
{
    public class InstagramRepo : IInstagramRepo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Post));
        private RestClient client;
        private string baseUrl = ConfigurationManager.AppSettings["InstagramBaseUrl"];

        public InstagramRepo()
        {
            client = new RestClient(baseUrl);
        }

        public List<InstagramImage> GetInstagramImages()
        {
            List<InstagramImage> images = new List<InstagramImage>();

            try
            {
                RestRequest request = new RestRequest("URL", Method.GET);
                request.AddParameter("grant_type", "password");
                request.AddParameter("username", "user");
                request.AddParameter("password", "pass");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                    images = JsonConvert.DeserializeObject<List<InstagramImage>>(response.Content);

                return images;
            }
            catch (Exception e)
            {
                Logger.Error("Error getting post for home location", e);
            }

            return images;
        }
    }
}