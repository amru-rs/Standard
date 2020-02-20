using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Red.Models.Redmine.Issue;
using Red.Models.Redmine.User;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Redmine.Helpers;
using System.Web.Script.Serialization;
using Red.Models.Redmine;
using Red.Models.Redmine.Project;

namespace Redmine.Controllers
{
    // [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        #region static parameter
        ApiRedmine ApiRedmine = new ApiRedmine();
        #endregion

        #region Projects
        [Route("api/Project/GetAllProjects")]
        [HttpGet]
        public HttpResponseMessage GetAllProjects()
        {
            try
            {
                ModelsProject project = ApiRedmine.GetAllProjects();
                return Request.CreateResponse<ModelsProject>(HttpStatusCode.OK, project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Users
        [Route("api/Project/GetAllUsers")]
        [HttpGet]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                ModelsUser user = ApiRedmine.GetAllUsers();
                return Request.CreateResponse<ModelsUser>(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/Project/GetAllUsersByGroupId")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetAllUsersByGroupId(GroupsType groupType)
        {
            try
            {
                ModelsUser user = ApiRedmine.GetAllUsersByGroupId(groupType);
                return Request.CreateResponse<ModelsUser>(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Issues
        [Route("api/Project/GetAllOpenIssues")]
        [HttpGet]
        public HttpResponseMessage GetAllOpenIssues()
        {
            try
            {
                ModelsIssue issue = ApiRedmine.GetAllOpenIssues();
                return Request.CreateResponse<ModelsIssue>(HttpStatusCode.OK, issue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/Project/GetAllIssueByStatusId")]
        [HttpGet]
        public HttpResponseMessage GetAllIssueByStatusId(IssueStatus issueStatus)
        {
            try
            {
                ModelsIssue issue = ApiRedmine.GetAllIssueByStatusId(issueStatus);
                return Request.CreateResponse<ModelsIssue>(HttpStatusCode.OK, issue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/Project/GetAllIssue")]
        [HttpGet]
        public HttpResponseMessage GetAllIssue()
        {
            try
            {
                ModelsIssue issue = ApiRedmine.GetAllIssue();
                return Request.CreateResponse<ModelsIssue>(HttpStatusCode.OK, issue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
