using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Redmine.Helpers;
using Red.Models.Redmine.User;
using Red.Models.Redmine.Project;
using Red.Models.Redmine.Issue;

namespace Standard.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ApiRedmine apiRedmine = new ApiRedmine();

            ModelsIssue allIssues = apiRedmine.GetAllIssue();
            ModelsIssue openIssues = apiRedmine.GetAllOpenIssues();
            ModelsProject projects = apiRedmine.GetAllProjects();
            ModelsUser users = apiRedmine.GetAllUsersByGroupId(GroupsType.Developers);

            ViewBag.allIssues = allIssues;
            ViewBag.openIssues = openIssues;
            ViewBag.projects = projects;
            ViewBag.users = users;

            return View();
        }

    }
}
