using System;
using System.Linq;
using Red.Models.Redmine.Issue;
using Red.Models.Redmine;
using Red.Models.Redmine.User;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Red.Models.Redmine.Project;

namespace Redmine.Helpers
{
    public class ApiRedmine
    {
        #region static parameter
        string _redmineUrl = "http://dxproject.citilink.co.id:8044/redmine/";
        string _formatApi = ".json";
        string _apiKey = "84e65b88806063ba165b1135e05df7e184df3a83";

        static string _issue = "issues";
        static string _project = "projects";
        static string _user = "users";
        #endregion

        #region Issues
        public ModelsIssue GetAllOpenIssues()
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("offset", "0");
            request.AddParameter("limit", "50");

            try
            {
                var result = client.Get(request);

                ModelsIssue issues = ModelsIssue.FromJson(result.Content);
                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Issue GetIssueById(string id)
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("issue_id", id);

            try
            {
                var result = client.Get(request);
                ModelsIssue issues = ModelsIssue.FromJson(result.Content);
                Issue issue = issues.Issues.FirstOrDefault();

                return issue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelsIssue GetAllIssueByProjectId(string id)
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("project_id", id);

            try
            {
                var result = client.Get(request);
                ModelsIssue issues = ModelsIssue.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelsIssue GetAllIssueByTrackerId(string id)
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("tracker_id", id);

            try
            {
                var result = client.Get(request);
                ModelsIssue issues = ModelsIssue.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelsIssue GetAllIssueByStatusId(IssueStatus issueStatus)
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("status_id", (int)issueStatus);

            try
            {
                var result = client.Get(request);
                ModelsIssue issues = ModelsIssue.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelsIssue GetAllIssueAssignedId(string id)
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("assigned_to_id", id);

            try
            {
                var result = client.Get(request);
                ModelsIssue issues = ModelsIssue.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelsIssue GetAllIssue()
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("status_id", "*");

            try
            {
                var result = client.Get(request);
                ModelsIssue issues = ModelsIssue.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Projects
        public ModelsProject GetAllProjects()
        {
            var client = new RestClient(_redmineUrl + _project + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("offset", "0");
            request.AddParameter("limit", "50");

            try
            {
                var result = client.Get(request);

                //Project project = Project.FromJson(new Project().jsonIssuesText);
                ModelsProject project = ModelsProject.FromJson(result.Content);
                return project;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Users
        public ModelsUser GetAllUsers()
        {
            var client = new RestClient(_redmineUrl + _user + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("offset", "0");
            request.AddParameter("limit", "50");

            try
            {
                var result = client.Get(request);

                //ModelsUser user = ModelsUser.FromJson(new ModelsUser().jsonUsersText);
                ModelsUser user = ModelsUser.FromJson(result.Content);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ModelsUser GetAllUsersByGroupId(GroupsType groupType)
        {
            var client = new RestClient(_redmineUrl + _user + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("group_id", (int)groupType);
            request.AddParameter("offset", "0");
            request.AddParameter("limit", "50");

            try
            {
                var result = client.Get(request);

                ModelsUser user = ModelsUser.FromJson(result.Content);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region sample get from DB
        //public ActionResult Index()
        //{
        //    List<Employee> employee = new List<Employee>();
        //    // ConfigurationManager.AppSettings[paramName];
        //    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ITProject"].ConnectionString))
        //    {
        //        employee = db.Query<Employee>("Select top 10 * from Employee").ToList();
        //    }

        //    return View(employee);
        //}
        #endregion
    }
}