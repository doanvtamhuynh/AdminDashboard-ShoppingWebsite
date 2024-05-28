using AdminDashboard_ShoppingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard_ShoppingWebsite.App_Start
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            User adminSession = (User)HttpContext.Current.Session["user"];
            if (adminSession != null)
            {
                if (adminSession.roleID == 1)
                {
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Security/Login");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("/Security/Login");
            }

        }
    }
}