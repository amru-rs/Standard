using System.Collections.Generic;
using System.Net;
using RestSharp;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Standard.Models.Redmine.Issue;
using System.Linq;
using Standard.Models.Redmine.Project;
using Standard.Models.Redmine.User;

namespace Standard.Helpers
{
    public class Redmine
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
        public Issues GetAllIssues()
        {
            //var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            //var request = new RestRequest();
            //request.Method = Method.GET;
            //request.AddHeader("X-Redmine-API-Key", _apiKey);
            //request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            //request.RequestFormat = DataFormat.Json;

            //request.AddParameter("offset", "0");
            //request.AddParameter("limit", "50");

            try
            {
                //var result = client.Get(request);
                //Issues issues = Issues.FromJson(result.Content);

                Issues issues = Issues.FromJson(new Issues().jsonIssuesText);
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
                Issues issues = Issues.FromJson(result.Content);
                Issue issue = issues.IssuesIssues.FirstOrDefault();

                return issue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Issues GetAllIssueByProjectId(string id)
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
                Issues issues = Issues.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Issues GetAllIssueByTrackerId(string id)
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
                Issues issues = Issues.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Issues GetAllIssueByStatusId(string id)
        {
            var client = new RestClient(_redmineUrl + "issues" + _formatApi);
            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("X-Redmine-API-Key", _apiKey);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("status_id", id);

            try
            {
                var result = client.Get(request);
                Issues issues = Issues.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Issues GetAllIssueAssignedId(string id)
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
                Issues issues = Issues.FromJson(result.Content);

                return issues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Projects
        public Project GetAllProjects()
        {
            //var client = new RestClient(_redmineUrl + _project + _formatApi);
            //var request = new RestRequest();
            //request.Method = Method.GET;
            //request.AddHeader("X-Redmine-API-Key", _apiKey);
            //request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            //request.RequestFormat = DataFormat.Json;

            //request.AddParameter("offset", "0");
            //request.AddParameter("limit", "50");

            try
            {
                //var result = client.Get(request);
                //Issues issues = Issues.FromJson(result.Content);

                Project project = Project.FromJson(new Project().jsonIssuesText);
                return project;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Users
        public User GetAllUsers()
        {
            //var client = new RestClient(_redmineUrl + _user + _formatApi);
            //var request = new RestRequest();
            //request.Method = Method.GET;
            //request.AddHeader("X-Redmine-API-Key", _apiKey);
            //request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            //request.RequestFormat = DataFormat.Json;

            //request.AddParameter("offset", "0");
            //request.AddParameter("limit", "50");

            try
            {
                //var result = client.Get(request);
                //Issues issues = Issues.FromJson(result.Content);

                User user = User.FromJson(new User().jsonUsersText);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}