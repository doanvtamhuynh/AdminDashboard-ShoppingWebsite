using AdminDashboard_ShoppingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard_ShoppingWebsite.App_Start
{
    public class Logged : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            User userSession = (User)HttpContext.Current.Session["user"];
            if (userSession != null)
            {
                return;
            }
            else
            {
                filterContext.Result = new RedirectResult("/Security/Login");
            }

        }
    }
}